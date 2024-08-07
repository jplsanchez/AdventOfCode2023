namespace PartTwo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("C:\\Users\\jpaul\\source\\repos\\AdventOfCode2023\\Day 1\\input.txt");

            string? line;
            int total = 0;
            while ((line = reader.ReadLine()) != null)
            {
                total += GetCalibrationNumber(line);
            }

            Console.WriteLine($"The sum of the calibration values is: {total}");
        }

        private static int GetCalibrationNumber(string line)
        {
            int? firstDigit = null, lastDigit = null;

            for (int i = 0; i < line.Length; i++)
            {
                if (!TryParseIntOrSpelledNumbers(line, i, out int value)) continue;

                if (firstDigit is null) firstDigit = value;

                lastDigit = value;
            }


            if (firstDigit is null || lastDigit is null) return 0;

            return (int)(firstDigit * 10 + lastDigit);
        }

        private static bool TryParseIntOrSpelledNumbers(string line, int index, out int value)
        {
            var numbers = new string[] { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            for (int i = 0; i < numbers.Length; i++)
            {
                if (int.TryParse(line[index].ToString(), out int integer))
                {
                    value = integer;
                    return true;
                }
                if (line[index..].StartsWith(numbers[i]))
                {
                    value = i + 1;
                    return true;
                }
            }
            value = default;
            return false;
        }
    }
}
