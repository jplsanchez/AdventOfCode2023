namespace IfYouGiveASeedAFertilizer.PartTwo
{
    internal class MapGroup(MapType type)
    {
        internal MapType Type { get; set; } = type;
        internal List<Map> Maps { get; set; } = new();

        internal void AddMap(Map Map)
        {
            Maps.Add(Map);
        }

        internal List<Range> MapFrom(List<Range> values)
        {
            List<Range> result = [];
            foreach (var map in Maps)
            {
                var mapped = map.MapFrom(values, out List<Range> notMapped);
                result.AddRange(mapped);
                values = notMapped;
            }
            result.AddRange(values);
            return result;
        }
    }

    internal class Map(long destinationRangeStart, long sourceRangeStart, long rangeLength)
    {
        readonly Range source = new(sourceRangeStart, rangeLength);
        public Range Source => source;

        readonly Range destination = new(destinationRangeStart, rangeLength);
        public Range Destination => destination;

        private long MapValue(long value)
        {
            return Destination.Start + (value - Source.Start);
        }

        internal List<Range> MapFrom(List<Range> values, out List<Range> notMapped)
        {
            var result = new List<Range>();
            notMapped = new List<Range>();

            foreach (var value in values)
            {
                if (Source.TryGetIntersection(value, out var intersection))
                {
                    result.Add(new(MapValue(intersection.Start), intersection.Length));
                }

                notMapped.AddRange(value.GetExclusive(Source));
            }
            return result;
        }
    }
}
