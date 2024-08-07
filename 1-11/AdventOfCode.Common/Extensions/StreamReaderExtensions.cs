namespace AdventOfCode.Common.Extensions
{
    public static class StreamReaderExtensions
    {
        public static string[][] To2DArray(this StreamReader reader)
        {
            string? line;
            List<string[]> result = [];

            for (int i = 0; (line = reader.ReadLine()) != null; i++)
            {
                string[] array = line.ToCharArray().Select(c => c.ToString()).ToArray();
                result.Add(array);
            }

            return [.. result];
        }
    }
}
