namespace AdventOfCode.Common.Utils
{
    public static class Loader
    {
        public static StreamReader Load(string fileName)
        {
            var path = Path.GetFullPath("..\\..\\..\\..\\..\\");
            return new(Path.Combine(path, fileName));
        }
    }
}
