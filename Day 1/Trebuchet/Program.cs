namespace Trebuchet
{
    internal class Program
    {
        private static readonly string[] _numbers = ["1", "2", "3", "4", "5", "6", "7", "8", "9", "0"];

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
                if (!int.TryParse(line[i].ToString(), out int value)) continue;

                if (firstDigit is null) firstDigit = value;

                lastDigit = value;
            }


            if (firstDigit is null || lastDigit is null) return 0;

            return (int)(firstDigit * 10 + lastDigit);
        }

    }
}
