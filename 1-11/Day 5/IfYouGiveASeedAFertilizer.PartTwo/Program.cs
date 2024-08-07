using IfYouGiveASeedAFertilizer.PartTwo;

var path = Path.GetFullPath("..\\..\\..\\..\\");
StreamReader reader = new(Path.Combine(path, "input.txt"));

InputDTO input = Parser.Parse(reader);
MapHandler handler = new(input.Maps);

long minLocation = long.MaxValue;

var locations = handler.MapFromSeedToLocation(input.SeedsRange.ToList());
foreach (var location in locations)
{
    if (location.Start < minLocation) minLocation = location.Start;
}

Console.WriteLine($"The minimum location is {minLocation}");

using (StreamWriter outputFile = new(Path.Combine(path, "result.txt")))
{
    outputFile.WriteLine($"The minimum location is {minLocation}");
}