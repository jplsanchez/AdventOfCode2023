using AdventOfCode.Common.Extensions;
using GearRatios.PartTwo;

StreamReader reader = new StreamReader("C:\\Users\\jpaul\\source\\repos\\AdventOfCode2023\\Day 3\\input.txt");

string[][] textArray = reader.To2DArray();

int total = 0;

for (int i = 0; i < textArray.Length; i++)
{
    for (int j = 0; j < textArray[i].Length; j++)
    {
        string digit = textArray[i][j].ToString();
        if (!digit.IsSymbol()) continue;

        Symbol symbol = new Symbol(i, j, ref textArray);

        symbol.FindAdjacentSequences();

        if (symbol.IsMultiplication && symbol.AdjacentSequences.Count == 2)
        {
            total += symbol.AdjacentSequences[0].Value * symbol.AdjacentSequences[1].Value;
        }
    }
}

Console.WriteLine($"The Final Sum is {total}");


