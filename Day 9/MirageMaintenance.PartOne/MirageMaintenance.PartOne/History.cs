
namespace MirageMaintenance.PartOne
{
    internal class History(IEnumerable<int> values)
    {
        public IEnumerable<int> Values { get; set; } = values;

        internal int PredictNext()
        {
            return PredictNext(Values.ToArray());
        }

        private int PredictNext(int[] values)
        {
            int[] differences = GetDifferences(values);

            if (differences.All(x => x == 0)) return values.Last() + differences.Last();

            return values.Last() + PredictNext(differences);
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
