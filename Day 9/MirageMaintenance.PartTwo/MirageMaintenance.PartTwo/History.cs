namespace MirageMaintenance.PartTwo
{
    internal class History(IEnumerable<int> values)
    {
        public IEnumerable<int> Values { get; set; } = values;

        internal int PredictPrevious()
        {
            return PredictPrevious(Values.ToArray());
        }

        internal int PredictPrevious(int[] values)
        {
            int[] differences = GetDifferences(values);

            if (differences.All(x => x == 0)) return values.First() - differences.First();

            return values.First() - PredictPrevious(differences);

        }

        private int[] GetDifferences(int[] values)
        {
            int[] differences = new int[values.Length - 1];
            for (int i = 0; i < differences.Length; i++)
            {
                differences[i] = values[i + 1] - values[i]; ;
            }
            return differences;
        }
    }
}
