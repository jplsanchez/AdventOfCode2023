using AdventOfCode.Common.Utils;
using MirageMaintenance.PartOne;

internal class Program
{
    private static void Main(string[] args)
    {
        StreamReader reader = Loader.Load("input.txt");

        IEnumerable<History> historyList = Parser.Parse(reader);

        int sum = 0;

        foreach (var history in historyList)
        {
            checked
            {
                sum += history.PredictNext();
            }
        }

        Console.WriteLine($"The sum of the extrapolated values is {sum}.");
    }
}