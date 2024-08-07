using AdventOfCode.Common.Utils;
using CosmicExpansion.PartTwo;

var reader = FileUtils.Load("input.txt");

GalaxiesMap map = Parser.Parse(reader);
map = map.Expand(1_000_000);

//map.Print(g => g is null ? "." : g.Id.ToString());


long result = 0;
var galaxies = map.GalaxiesPosition;

for (int i = 0; i < galaxies.Count; i++)
{
    var galaxy = galaxies[i];
    foreach (var other in galaxies[i..])
    {
        if (galaxy == other) continue;

        result += map.Distance(galaxy, other);
        //Console.WriteLine($"{map.Map[galaxy.i][galaxy.j]!.Id}->{map.Map[other.i][other.j]!.Id}: {map.Distance(galaxy, other)}");
    }
}


Console.WriteLine($"Sum of distance lenghts is {result}");
