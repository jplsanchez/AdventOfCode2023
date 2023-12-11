namespace IfYouGiveASeedAFertilizer.PartOne
{
    internal class Map
    {
        internal MapType Type { get; set; }
        internal List<MapUnit> Units { get; set; } = new();


        public Map() { }
        public Map(MapType type)
        {
            Type = type;
        }


        internal void AddUnit(MapUnit unit)
        {
            Units.Add(unit);
        }

        internal long MapFrom(long value)
        {
            if (Units.Any(Units => Units.IsInRange(value)))
            {
                return Units.First(Units => Units.IsInRange(value)).MapFrom(value);
            }

            return Units.First().MapFrom(value);
        }
    }

    internal class MapUnit
    {
        public long DestinationRangeStart { get; set; }
        public long SourceRangeStart { get; set; }
        public long RangeLength { get; set; }

        internal long MapFrom(long value)
        {
            if (!IsInRange(value)) return value;
            return DestinationRangeStart + (value - SourceRangeStart);
        }

        internal bool IsInRange(long value)
        {
            return value >= SourceRangeStart && value <= SourceRangeStart + RangeLength;
        }
    }

    internal class MapHandler
    {
        private readonly IEnumerable<Map> _maps;

        public MapHandler(IEnumerable<Map> maps)
        {
            _maps = maps;
        }

        internal long MapFromSeedToLocation(long seed)
        {
            long value = seed;
            foreach (var map in _maps)
            {
                value = map.MapFrom(value);
            }

            return value;

        }
    }
}
