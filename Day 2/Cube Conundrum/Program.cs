namespace Cube_Conundrum
{
    internal class Program
    {
        const int RED = 12, GREEN = 13, BLUE = 14;

        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("C:\\Users\\jpaul\\source\\repos\\AdventOfCode2023\\Day 2\\input.txt");

            string? line;
            int total = 0;
            while ((line = reader.ReadLine()) != null)
            {
                int gameId = GetGameId(line);
                Bag bag = GetCubesRevealed(line);

                if (bag.RedCubes <= RED && bag.GreenCubes <= GREEN && bag.BlueCubes <= BLUE) total += gameId;
            }

            Console.WriteLine($"The sum of IDs from possible games is: {total}");
        }

        static int GetGameId(string line)
        {
            return int.Parse(line.Split(": ")[0].Split(" ")[1]);
        }

        static Bag GetCubesRevealed(string line)
        {
            Bag bag = new();

            // "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green" => {"3 blue", "4 red", "1 red", "2 green", "6 blue", "2 green"}
            var rounds = line.Split(": ")[1]
                             .Split(new string[] { "; ", ", " }, options: StringSplitOptions.None);

            foreach (var round in rounds)
            {
                // "3 blue" => (3, "blue")
                (int quantity, string color) tuple = round.Split(" ") switch { var value => (int.Parse(value[0]), value[1]) };

                bag.SetHighestCubes(tuple);
            }

            return bag;
        }
    }

    class Bag
    {
        internal int RedCubes = 0, GreenCubes = 0, BlueCubes = 0;

        internal void SetHighestCubes((int quantity, string color) tuple)
        {
            SetHighestCubes(tuple.quantity, tuple.color);
        }

        internal void SetHighestCubes(int quantity, string color)
        {
            _ = color switch
            {
                "red" when quantity > RedCubes => RedCubes = quantity,
                "green" when quantity > GreenCubes => GreenCubes = quantity,
                "blue" when quantity > BlueCubes => BlueCubes = quantity,
                _ => default,
            };
        }
    }
}
