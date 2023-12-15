using AdventOfCode.Common.Extensions;

namespace CosmicExpansion.PartTwo
{
    internal record Galaxy(int Id);
    internal record GalaxiesMap
    {
        internal Galaxy?[][] Map { get; init; }

        internal List<(int i, int j)> GalaxiesPosition { get; init; } = [];

        internal int ExpandedSize { get; set; } = 0;
        internal List<int> ExpandedRows { get; set; } = [];
        internal List<int> ExpandedCols { get; set; } = [];

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

        internal GalaxiesMap Expand(int size = 1_000_000)
        {


            List<Galaxy?[]> map = [];


            // Check empty rows
            for (int i = 0; i < Map.Length; i++)
            {
                Galaxy?[] row = Map[i];
                map.Add(row);
                if (row.All(g => g is null))
                {
                    ExpandedRows.Add(i);
                }
            }

            List<Galaxy?[]> resultT = [];

            // Check empty columns
            List<Galaxy?[]> mapT = map.Transpose();
            for (int i = 0; i < mapT.Count; i++)
            {
                Galaxy?[] row = mapT[i];
                resultT.Add(row);
                if (row.All(g => g is null))
                {
                    ExpandedCols.Add(i);
                }
            }

            return new GalaxiesMap([.. resultT.Transpose()])
            {
                ExpandedRows = ExpandedRows,
                ExpandedCols = ExpandedCols,
                ExpandedSize = size
            };
        }

        internal long Distance((int i, int j) a, (int i, int j) b)
        {
            long distance = 0;

            for (int i = System.Math.Min(a.i, b.i); i < System.Math.Max(a.i, b.i); i++)
            {
                if (ExpandedRows.Contains(i)) distance += ExpandedSize;
                else distance++;
            }

            for (int j = System.Math.Min(a.j, b.j); j < System.Math.Max(a.j, b.j); j++)
            {
                if (ExpandedCols.Contains(j)) distance += ExpandedSize;
                else distance++;
            }
            return distance;
        }
    }
}
