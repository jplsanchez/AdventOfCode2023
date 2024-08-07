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

        public static List<T[]> Transpose<T>(this List<T[]> matrix)
        {
            int w = matrix.Count;
            int h = matrix[0].Length;

            List<T[]> result = [];
            for (int i = 0; i < h; i++)
            {
                result.Add(new T[w]);
                for (int j = 0; j < w; j++)
                {
                    result[i][j] = matrix[j][i];
                }
            }

            return result;
        }
    }
}
