using WaitForIt.PartTwo;

var path = Path.GetFullPath("..\\..\\..\\..\\..\\");
StreamReader reader = new(Path.Combine(path, "input.txt"));

Race race = Parser.Parse(reader.ReadToEnd());

int result = race.NumberOfWiningRaces();


Console.WriteLine($"The number of ways you could beat the record was: {result}");