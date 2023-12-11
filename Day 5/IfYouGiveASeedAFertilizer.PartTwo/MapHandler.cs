namespace IfYouGiveASeedAFertilizer.PartTwo
{
    internal class MapHandler(IEnumerable<MapGroup> maps)
    {
        private readonly IEnumerable<MapGroup> _mapGroups = maps;

        internal List<Range> MapFromSeedToLocation(List<Range> seedRange)
        {
            List<Range> ranges = seedRange;

            foreach (var mapGroup in _mapGroups)
            {
                ranges = mapGroup.MapFrom(ranges);
            }

            return ranges;
        }
    }
}
