using AdventOfCode.Common.Collections;

namespace HauntedWasteland.PartOne
{
    internal static class Parser
    {
        public static Map Parse(StreamReader input)
        {
            // Read directions 
            string directionsString = input.ReadLine()!;
            CircularList<char> directions = [.. directionsString.ToCharArray()];

            // Skip empty line
            input.ReadLine();

            // Read nodes
            string? line;
            Dictionary<string, Node> nodes = new();
            while ((line = input.ReadLine()) is not null)
            {
                // "AAA = (BBB, BBB)"
                var array = line.Split([" = ", "(", ", ", ")"], StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
                nodes.Add(array[0], new Node(array[0], array[1], array[2]));
            }

            return new Map(directions, nodes);
        }
    }

    internal record Map(CircularList<char> Directions, Dictionary<string, Node> Nodes);

    internal record Node(string Name, string Left, string Right);
}
