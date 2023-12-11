namespace IfYouGiveASeedAFertilizer.PartTwo
{
    internal class Parser
    {
        internal static InputDTO Parse(StreamReader reader)
        {
            string? line = reader.ReadLine();
            var seedsArray = line?.Split(':')[1]
                             .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                             .ToArray();

            List<Range> seeds = [];

            for (int i = 0; i < seedsArray!.Length; i += 2)
            {
                seeds.Add(new(long.Parse(seedsArray[i]), long.Parse(seedsArray[i + 1])));
            }

            List<MapGroup> maps = [];
            MapGroup? currentMap = null;

            while ((line = reader.ReadLine()) is not null)
            {
                var lineArray = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (lineArray.Length == 0) continue;

                if (lineArray[0].IsMapType())
                {
                    if (currentMap is not null) maps.Add(currentMap);
                    currentMap = new(lineArray[0].ParseToMapType());
                    continue;
                }

                currentMap!.AddMap(new(
                    destinationRangeStart: long.Parse(lineArray[0]),
                    sourceRangeStart: long.Parse(lineArray[1]),
                    rangeLength: long.Parse(lineArray[2])
                ));
            }

            // Add the last map
            if (currentMap is not null) maps.Add(currentMap);

            return new InputDTO(seeds, maps);
        }
    }

    internal record InputDTO(IEnumerable<Range> SeedsRange, IEnumerable<MapGroup> Maps);
}
