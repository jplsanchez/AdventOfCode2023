using PipeMaze.PartOne.Enums;
using Position = (int i, int j);

namespace PipeMaze.PartOne
{
    internal record Maze(Tile[][] Grid, List<Direction> StartDirections)
    {
        Position Start => FindTile(TileTypes.Start);
        Tile Tile(Position position) => Grid[position.i][position.j];

        public Maze(Tile[][] Grid) : this(Grid, new List<Direction>())
        {
            StartDirections = FindPaths();

        }

        internal Tile FindFarestTileInPath()
        {
            // Get te minimum distance per tile between both paths
            foreach (var direction in StartDirections)
            {
                int steps = 1;
                WalkThroughMaze(direction, tile => tile.Distance = Math.Min(tile.Distance, steps++));
            }

            // Get the most distant tile
            Tile mostDistant = Tile(Start);

            WalkThroughMaze(StartDirections[0], tile =>
            {
                if (tile.Distance > mostDistant.Distance) mostDistant = tile;
            });

            return mostDistant;
        }

        private void WalkThroughMaze(Direction startDirection, Action<Tile> tileAction)
        {
            var currentPos = Start;
            Direction exit = startDirection;

            currentPos = exit.Move(from: currentPos);
            while (currentPos != Start)
            {
                var tile = Tile(currentPos);

                tileAction(tile);

                // Go to exit where is not the direction we entered
                exit = tile.Directions.Where(d => d != exit.Opposite()).First();
                currentPos = exit.Move(from: currentPos);
            }
        }

        private List<Direction> FindPaths()
        {
            var directions = new List<Direction>();
            foreach (var direction in Enum.GetValues<Direction>())
            {
                Position position = direction.Move(Start);
                if (IsInBounds(position) && Tile(position).CanEnterPipe(direction.Opposite()))
                {
                    directions.Add(direction);
                }
            }
            return directions;
        }

        private Position FindTile(TileTypes tile)
        {
            for (var i = 0; i < Grid.Length; i++)
            {
                for (var j = 0; j < Grid[i].Length; j++)
                {
                    if (Tile((i, j)).Type == tile)
                    {
                        return (i, j);
                    }
                }
            }

            throw new Exception($"Tile {tile} not found");
        }

        private bool IsInBounds(Position position)
        {
            return position.i >= 0 && position.i < Grid.Length && position.j >= 0 && position.j < Grid[position.i].Length;
        }
    }
}
