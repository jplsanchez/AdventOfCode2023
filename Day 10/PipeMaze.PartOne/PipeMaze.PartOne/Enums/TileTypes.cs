namespace PipeMaze.PartOne.Enums
{
    public enum TileTypes
    {
        None = 0,
        VerticalPipe = '|',
        HorizontalPipe = '-',
        BendNorthEast = 'L',
        BendNorthWest = 'J',
        BendSouthEast = 'F',
        BendSouthWest = '7',
        Ground = '.',
        Start = 'S',
    }
    static class TileTypesConverter
    {
        internal static TileTypes ToTileTypes(this char c)
        {
            return c switch
            {
                '|' => TileTypes.VerticalPipe,
                '-' => TileTypes.HorizontalPipe,
                'L' => TileTypes.BendNorthEast,
                'J' => TileTypes.BendNorthWest,
                'F' => TileTypes.BendSouthEast,
                '7' => TileTypes.BendSouthWest,
                '.' => TileTypes.Ground,
                'S' => TileTypes.Start,
                _ => throw new Exception($"Tile type {c} is not valid"),
            };
        }
    }
}
