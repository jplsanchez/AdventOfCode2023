namespace PipeMaze.PartTwo
{
    internal static class Parser
    {
        public static Maze Parse(StreamReader input)
        {
            string? line;
            var grid = new List<Tile[]>();
            while ((line = input.ReadLine()) != null)
            {
                grid.Add(line.ToCharArray().Select(ch => (Tile)ch).ToArray());
            }


            Tile[][] gridArray = [.. grid];

            for (int i = 0; i < gridArray.Length; i++)
            {
                for (int j = 0; j < gridArray[i].Length; j++)
                {
                    gridArray[i][j].Position = (i, j);
                }
            }

            return new Maze(gridArray);
        }

    }
}
