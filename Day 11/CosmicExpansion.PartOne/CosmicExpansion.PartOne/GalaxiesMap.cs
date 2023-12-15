using AdventOfCode.Common.Extensions;

namespace CosmicExpansion.PartOne
{
    internal record Galaxy(int Id)
    {
        internal static int Distance((int i, int j) a, (int i, int j) b)
        {
            return System.Math.Abs(a.i - b.i) + System.Math.Abs(a.j - b.j);
        }
    };
    internal record GalaxiesMap
    {
        internal Galaxy?[][] Map { get; init; }

        internal List<(int i, int j)> GalaxiesPosition { get; init; } = [];

        public GalaxiesMap(Galaxy?[][] map)
        {
            Map = map;

            for (int i = 0; i < Map.Length; i++)
            {
                for (int j = 0; j < Map[i].Length; j++)
                {
                    if (Map[i][j] is not null)
                    {
                        GalaxiesPosition.Add((i, j));
                    }
                }
            }
        }

        internal GalaxiesMap Print(Func<Galaxy?, string>? print = null)
        {
            print ??= (galaxy) => galaxy is null ? "." : "#";

            foreach (var row in Map)
            {
                foreach (var galaxy in row)
                {
                    Console.Write(print(galaxy));
                }

                Console.WriteLine();
            }
            return this;
        }

        internal GalaxiesMap Expand()
        {
            List<Galaxy?[]> map = [];

            // Check empty rows
            foreach (Galaxy?[] row in Map)
            {
                map.Add(row);
                if (row.All(g => g is null))
                {
                    map.Add(row);
                }
            }

            List<Galaxy?[]> resultT = [];

            // Check empty columns
            foreach (Galaxy?[] row in map.Transpose())
            {
                resultT.Add(row);
                if (row.All(g => g is null))
                {
                    resultT.Add(row);
                }
            }

            return new GalaxiesMap([.. resultT.Transpose()]);
        }
    }
}
