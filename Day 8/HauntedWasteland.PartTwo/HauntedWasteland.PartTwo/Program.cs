using AdventOfCode.Common.Extensions;
using HauntedWasteland.PartTwo;

var path = Path.GetFullPath("..\\..\\..\\..\\..\\");
StreamReader reader = new(Path.Combine(path, "input.txt"));

Map map = Parser.Parse(reader);

List<string> currentNodes = map.Nodes.Where(n => n.Key.EndsWith('A'))
                                     .Select(n => n.Key)
                                     .ToList();

// frequency that each node hits EndsWith('Z')
List<long> frequencies = [];

foreach (var node in currentNodes)
{
    int step = 0;
    var currentNode = node;
    bool flag = false;

    foreach (char direction in map.Directions)
    {
        step++;

        currentNode = direction switch
        {
            'R' => map.Nodes[currentNode].Right,
            'L' => map.Nodes[currentNode].Left,
            _ => throw new Exception("Unknown direction")
        };

        if (currentNode.EndsWith('Z'))
        {
            if (flag)
            {
                if (frequencies.Last() * 2 != step)
                {
                    Console.WriteLine("Error");
                }
                break;
            }
            frequencies.Add(step);
            flag = true;
        }
    }
}

var frequencyMatch = frequencies.LeastCommonMultiple();



Console.WriteLine($"It was requreds {frequencyMatch} steps to reach ZZZ.");

