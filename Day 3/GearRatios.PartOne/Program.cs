using AdventOfCode.Common.Extensions;
using GearRatios.PartOne;

StreamReader reader = new StreamReader("C:\\Users\\jpaul\\source\\repos\\AdventOfCode2023\\Day 3\\input.txt");

string[][] textArray = reader.To2DArray();

int total = 0;

for (int i = 0; i < textArray.Length; i++)
{
    for (int j = 0; j < textArray[i].Length; j++)
    {
        string digit = textArray[i][j].ToString();
        if (!digit.IsNumber()) continue;

        Sequence sequence = new Sequence(i, j, ref textArray);

        if (sequence.HasAdjacentSymbol())
        {
            total += sequence.Value;

            if (j + sequence.Size >= textArray[i].Length) break;

            j += sequence.Size - 1;
        }
    }
}

Console.WriteLine($"The Final Sum is {total}");


