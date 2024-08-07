using Position = (int i, int j);

namespace PipeMaze.PartTwo.Enums
{
    public enum Direction
    {
        North,
        South,
        East,
        West,
    }
    static class DirectionExtensions
    {
        internal static Direction Opposite(this Direction direction)
        {
            return direction switch
            {
                Direction.North => Direction.South,
                Direction.South => Direction.North,
                Direction.East => Direction.West,
                Direction.West => Direction.East,
                _ => throw new Exception($"Direction {direction} is not valid"),
            };
        }

        internal static Position Move(this Direction direction, Position from)
        {
            return direction switch
            {
                Direction.North => (from.i - 1, from.j),
                Direction.South => (from.i + 1, from.j),
                Direction.East => (from.i, from.j + 1),
                Direction.West => (from.i, from.j - 1),
                _ => throw new Exception($"Direction {direction} is not valid"),
            };
        }
    }
}
