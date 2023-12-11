using WaitForIt.PartOne;

var path = Path.GetFullPath("..\\..\\..\\..\\..\\");
StreamReader reader = new(Path.Combine(path, "input.txt"));

List<Race> races = Parser.Parse(reader.ReadToEnd());

int result = 1;
foreach (Race race in races)
{
    result *= race.NumberOfWiningRaces();
}


Console.WriteLine($"The multiplication of the number of ways you could beat the record was: {result}");