namespace MirageMaintenance.PartOne
{
    internal static class Parser
    {
        public static IEnumerable<History> Parse(StreamReader input)
        {
            string? line;
            while ((line = input.ReadLine()) != null)
            {
                yield return new History(line.Split(' ').Select(int.Parse));
            }
        }
    }
}
