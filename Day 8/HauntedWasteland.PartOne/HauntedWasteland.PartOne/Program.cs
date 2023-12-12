
using HauntedWasteland.PartOne;

var path = Path.GetFullPath("..\\..\\..\\..\\..\\");
StreamReader reader = new(Path.Combine(path, "input.txt"));

Map map = Parser.Parse(reader);

string currentNode = "AAA";
int step = 0;

foreach (char direction in map.Directions)
{
    step++;
    //Console.WriteLine($"{step}: Node: {currentNode}, Direction: {direction}");
    if (step != 0 && step % 100_000_000 == 0) Console.WriteLine(step);

    currentNode = direction switch
    {
        'R' => map.Nodes[currentNode].Right,
        'L' => map.Nodes[currentNode].Left,
        _ => throw new Exception("Unknown direction")
    };

    if (currentNode == "ZZZ") break;
}


Console.WriteLine($"It was requreds {step} steps to reach ZZZ.");

