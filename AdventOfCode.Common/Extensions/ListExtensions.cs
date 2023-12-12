namespace AdventOfCode.Common.Extensions
{
    public static class ListExtensions
    {
        public static List<T> Swap<T>(this List<T> list, int indexA, int indexB)
        {
            var aux = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = aux;
            return list;
        }
    }
}
