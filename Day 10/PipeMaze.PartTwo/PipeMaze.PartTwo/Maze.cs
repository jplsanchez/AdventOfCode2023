using PipeMaze.PartTwo.Enums;
using Position = (int i, int j);

namespace PipeMaze.PartTwo
{
    internal record Maze
    {
        Tile[][] Grid { get; }
        List<Direction> StartDirections => FindPaths();


        Position Start => FindTile(TileTypes.Start);
        Tile Tile(Position position) => Grid[position.i][position.j];

        public Maze(Tile[][] grid)
        {
            Grid = grid;
        }

        internal Maze SetLoop()
        {
            WalkThroughMaze(StartDirections[0], tile => tile.EnclosedType = EnclosedTypes.Loop);
            Tile(Start).EnclosedType = EnclosedTypes.Loop;
            return this;
        }

        // Using EvenOddTheorem https://en.wikipedia.org/wiki/Even%E2%80%93odd_rule
        internal Maze SetInsideOutside()
        {
            foreach (var row in Grid)
            {
                foreach (var tile in row)
                {
                    if (tile.EnclosedType != EnclosedTypes.None) continue;

                    var count = 0;
                    var position = tile.Position;
                    while (position.j < Grid[position.i].Length)
                    {
                        if (Tile(position).EnclosedType == EnclosedTypes.Loop)
                        {
                            try
                            {
                                Position nextPos = (position.i, position.j + 1);

                                while (Tile(position).IsConnectedTo(Tile(nextPos)))
                                {
                                    position = nextPos;
                                    nextPos = (position.i, position.j + 1);
                                    if (position.j >= Grid[position.i].Length) break;
                                }
                                count++;
                            }
                            catch
                            {
                                break;
                            }


                        }
                        position.j++;
                    }
                    tile.EnclosedType = count % 2 == 0 ? EnclosedTypes.Outside : EnclosedTypes.Inside;
                }
            }
            return this;
        }

        internal Maze SetOutside()
        {
            for (int i = 0; i < Grid.Length; i++)
            {
                SetOutside(Tile((i, 0)));
                SetOutside(Tile((i, Grid[0].Length - 1)));
            }


            for (int j = 0; j < Grid[0].Length; j++)
            {
                SetOutside(Tile((0, j)));
                SetOutside(Tile((Grid.Length - 1, j)));
            }

            return this;
        }


        internal Maze SetInside(out int count)
        {
            count = 0;
            for (int i = 0; i < Grid.Length; i++)
            {
                for (int j = 0; j < Grid[i].Length; j++)
                {
                    var tile = Tile((i, j));
                    if (tile.EnclosedType != EnclosedTypes.None) continue;

                    tile.EnclosedType = EnclosedTypes.Inside;
                    count++;
                }
            }

            return this;
        }

        private void SetOutside(Tile tile)
        {
            if (tile.EnclosedType != EnclosedTypes.None) return;

            tile.EnclosedType = EnclosedTypes.Outside;
            foreach (var direction in Enum.GetValues<Direction>())
            {
                var nexPosition = direction.Move(tile.Position);
                if (!IsInBounds(nexPosition)) continue;

                var nextTile = Tile(nexPosition);
                if (nextTile.EnclosedType == EnclosedTypes.None) SetOutside(nextTile);
            }
        }

        internal Maze Print()
        {
            foreach (var row in Grid)
            {
                foreach (var tile in row)
                {
                    Console.Write(tile.EnclosedType switch
                    {
                        EnclosedTypes.Loop => '~',
                        EnclosedTypes.Inside => 'I',
                        EnclosedTypes.Outside => 'O',
                        EnclosedTypes.None => '.',
                        _ => throw new Exception($"Unknown enclosed type {tile.EnclosedType}")
                    });
                }
                Console.WriteLine();
            }
            return this;
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
