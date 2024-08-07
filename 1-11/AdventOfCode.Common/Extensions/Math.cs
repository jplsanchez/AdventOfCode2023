namespace AdventOfCode.Common.Extensions
{
    public static class Math
    {
        public static long GreatestCommonDivisor(this long a, long b)
        {
            while (b != 0)
            {
                long temp = b;
                b = a % b;
                a = temp;
            }

            return a;
        }

        public static long GreatestCommonDivisor(this long[] input)
        {
            long result = input[0];

            for (long i = 1; i < input.Length; i++)
            {
                result = result.GreatestCommonDivisor(input[i]);
            }

            return result;
        }

        public static long LeastCommonMultiple(this long a, long b)
        {
            checked
            {
                return a * b / a.GreatestCommonDivisor(b);
            }
        }

        public static long LeastCommonMultiple(this long[] input)
        {
            long result = input[0];

            for (long i = 1; i < input.Length; i++)
            {
                result = result.LeastCommonMultiple(input[i]);
            }

            return result;
        }

        public static long LeastCommonMultiple(this List<long> input)
        {
            return input.ToArray().LeastCommonMultiple();
        }
    }
}
