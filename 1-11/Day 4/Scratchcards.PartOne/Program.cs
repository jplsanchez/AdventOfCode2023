internal class Program
{
    private static void Main(string[] args)
    {
        string? line;
        List<Card> cards = new List<Card>();
        int total = 0;

        StreamReader reader = new StreamReader("C:\\Users\\jpaul\\source\\repos\\AdventOfCode2023\\Day 4\\input.txt");
        while ((line = reader.ReadLine()) is not null)
        {
            cards.Add(new Card(line));
            total += cards.Last().Points;
        }

        Console.WriteLine($"The sum of points is {total}");
    }
}

class Card
{
    public int Id { get; set; }
    public int[] Numbers { get; set; }
    public int[] WinningNumbers { get; set; }
    public int Points
    {
        get
        {
            var count = Numbers.Intersect(WinningNumbers).Count();
            if (count <= 0) return 0;

            return (int)Math.Pow(2, count - 1);
        }
    }

    public Card(string inputText)
    {
        // "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53"
        Id = int.Parse(inputText.Split(":", StringSplitOptions.RemoveEmptyEntries)[0]      // => "Card 1"
                                .Split(" ", StringSplitOptions.RemoveEmptyEntries)[1]);    // => 1

        // "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53"
        string[] values = inputText.Split(": ")[1]   // => "41 48 83 86 17 | 83 86  6 31 17  9 48 53"
                                   .Split(" | ");     // => "41 48 83 86 17", "83 86  6 31 17  9 48 53"


        WinningNumbers = values[0].Split(" ", StringSplitOptions.RemoveEmptyEntries)   // => "41 48 83 86 17"
                                  .Select(int.Parse).ToArray();                         // => [41, 48, 83, 86, 17]

        Numbers = values[1].Split(" ", StringSplitOptions.RemoveEmptyEntries)          // => "83 86  6 31 17  9 48 53"
                           .Select(int.Parse).ToArray();                                // => [83, 86, 6, 31, 17, 9, 48, 53]  
    }




}