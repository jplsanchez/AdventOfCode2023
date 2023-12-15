namespace CosmicExpansion.PartOne
{
    internal static class Parser
    {
        internal static GalaxiesMap Parse(StreamReader reader)
        {
            int id = 1;
            var result = new List<Galaxy?[]>();
            string? line;
            while ((line = reader.ReadLine()) is not null)
            {
                result.Add(
                    line.ToCharArray()
                        .Select(c => c == '#' ? new Galaxy(id++) : null)
                        .ToArray());
            }

            return new GalaxiesMap([.. result]);
        }
    }
}
