using CamelCards.PartOne;

var path = Path.GetFullPath("..\\..\\..\\..\\..\\");
StreamReader reader = new(Path.Combine(path, "input.txt"));

List<Hand> hands = Parser.Parse(reader);

hands = hands.OrderByAsc();
hands.Reverse();

int result = 0;
List<object> resultObj = new();
for (int i = 0; i < hands.Count; i++)
{
    result += hands[i].Bid * (i + 1);
    resultObj.Add(new { Hand = hands[i], rank = (i + 1) });
}

Console.WriteLine($"The total winnings is: {result}");

//Console.WriteLine(JsonSerializer.Serialize(resultObj, options: new() { WriteIndented = true }));
