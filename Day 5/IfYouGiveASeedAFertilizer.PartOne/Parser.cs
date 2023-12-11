namespace IfYouGiveASeedAFertilizer.PartOne
{
    internal class Parser
    {
        internal static InputDTO Parse(StreamReader reader)
        {
            string? line = reader.ReadLine();
            var seeds = line?.Split(':')[1]
                             .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                             .Select(long.Parse);

            List<Map> maps = [];
            Map currentMap = null;

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

                currentMap!.AddUnit(new()
                {
                    DestinationRangeStart = long.Parse(lineArray[0]),
                    SourceRangeStart = long.Parse(lineArray[1]),
                    RangeLength = long.Parse(lineArray[2])
                });
            }

            // Add the last map
            if (currentMap is not null) maps.Add(currentMap);

            return new InputDTO(seeds!, maps);
        }
    }

    internal record InputDTO(IEnumerable<long> Seeds, IEnumerable<Map> Maps);
}
