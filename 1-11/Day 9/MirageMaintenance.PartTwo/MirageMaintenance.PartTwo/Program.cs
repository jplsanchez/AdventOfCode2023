using AdventOfCode.Common.Utils;
using MirageMaintenance.PartTwo;

internal class Program
{
    private static void Main(string[] args)
    {
        StreamReader reader = AdventOfCode.Common.Utils.FileUtils.Load("input.txt");

        IEnumerable<History> historyList = Parser.Parse(reader);

        int sum = 0;

        foreach (var history in historyList)
        {
            checked
            {
                sum += history.PredictPrevious();
            }
        }

        Console.WriteLine($"The sum of the extrapolated values is {sum}.");
    }
}