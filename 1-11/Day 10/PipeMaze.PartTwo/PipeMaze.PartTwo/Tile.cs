using PipeMaze.PartTwo.Enums;
using Position = (int i, int j);

namespace PipeMaze.PartTwo
{
    public class Tile
    {
        public TileTypes Type { get; }
        public Position Position { get; set; }
        public EnclosedTypes EnclosedType { get; set; } = EnclosedTypes.None;

        public Tile(TileTypes type)
        {
            Type = type;
        }

        public bool IsConnectedTo(Tile other)
        {
            if (this.IsStart || other.IsStart) return true;
            var dir = GetDirectionTo(other);
            return Directions.Contains(dir) && other.Directions.Contains(dir.Opposite());
        }

        public Direction GetDirectionTo(Tile other)
        {
            return ((Position.i - other.Position.i), (Position.j - other.Position.j)) switch
            {
                (1, 0) => Direction.North,
                (-1, 0) => Direction.South,
                (0, 1) => Direction.West,
                (0, -1) => Direction.East,
                _ => throw new Exception($"Tile {Type} is not connected to {other.Type}"),
            };
        }


        public bool CanEnterPipe(Direction Entrance)
        {
            if (!IsPipe) return false;

            return Type switch
            {
                TileTypes.VerticalPipe => Entrance == Direction.North || Entrance == Direction.South,
                TileTypes.HorizontalPipe => Entrance == Direction.East || Entrance == Direction.West,
                TileTypes.BendNorthEast => Entrance == Direction.North || Entrance == Direction.East,
                TileTypes.BendNorthWest => Entrance == Direction.North || Entrance == Direction.West,
                TileTypes.BendSouthEast => Entrance == Direction.South || Entrance == Direction.East,
                TileTypes.BendSouthWest => Entrance == Direction.South || Entrance == Direction.West,
                _ => throw new Exception($"Tile {Type} is not a pipe"),
            };
        }
        public bool IsPipe => Type switch
        {
            TileTypes.VerticalPipe => true,
            TileTypes.HorizontalPipe => true,
            TileTypes.BendNorthEast => true,
            TileTypes.BendNorthWest => true,
            TileTypes.BendSouthEast => true,
            TileTypes.BendSouthWest => true,
            _ => false,
        };

        public bool IsStart => Type == TileTypes.Start;

        public List<Direction> Directions => Type switch
        {
            TileTypes.VerticalPipe => [Direction.North, Direction.South],
            TileTypes.HorizontalPipe => [Direction.East, Direction.West],
            TileTypes.BendNorthEast => [Direction.North, Direction.East],
            TileTypes.BendNorthWest => [Direction.North, Direction.West],
            TileTypes.BendSouthEast => [Direction.South, Direction.East],
            TileTypes.BendSouthWest => [Direction.South, Direction.West],
            _ => throw new Exception($"Tile {Type} is not a pipe"),
        };


        public static implicit operator Tile(char c) => new(c.ToTileTypes());
    }
}
