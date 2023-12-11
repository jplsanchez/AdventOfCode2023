
using IfYouGiveASeedAFertilizer.PartOne;

StreamReader reader = new("C:\\Users\\jpaul\\source\\repos\\AdventOfCode2023\\Day 5\\input.txt");

var input = Parser.Parse(reader);
var handler = new MapHandler(input.Maps);

long minLocation = long.MaxValue;

foreach (var seed in input.Seeds)
{
    var location = handler.MapFromSeedToLocation(seed);
    if (location < minLocation) minLocation = location;
}


Console.WriteLine($"The minimum location is {minLocation}");