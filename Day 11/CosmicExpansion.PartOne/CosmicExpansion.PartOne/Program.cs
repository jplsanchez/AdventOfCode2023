using AdventOfCode.Common.Utils;
using CosmicExpansion.PartOne;

var reader = FileUtils.Load("input.txt");

GalaxiesMap map = Parser.Parse(reader);
map = map.Expand();

map.Print(g => g is null ? "." : g.Id.ToString());


var result = 0;
var galaxies = map.GalaxiesPosition;

for (int i = 0; i < galaxies.Count; i++)
{
    var galaxy = galaxies[i];
    foreach (var other in galaxies[i..])
    {
        if (galaxy == other) continue;

        result += Galaxy.Distance(galaxy, other);
        //Console.WriteLine($"{map.Map[galaxy.i][galaxy.j]!.Id}->{map.Map[other.i][other.j]!.Id}: {Galaxy.Distance(galaxy, other)}");

    }
}


Console.WriteLine($"Sum of distance lenghts is {result}");
