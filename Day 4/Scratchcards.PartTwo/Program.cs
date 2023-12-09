internal class Program
{
    private static void Main(string[] args)
    {
        string? line;
        int total = 0;
        Dictionary<int, int> copies = new();

        StreamReader reader = new StreamReader("C:\\Users\\jpaul\\source\\repos\\AdventOfCode2023\\Day 4\\input.txt");
        while ((line = reader.ReadLine()) is not null)
        {
            var card = new Card(line);

            // Adding original card
            if (!copies.TryAdd(card.Id, 1))
            {
                copies[card.Id] += 1;
            }

            CalculateScratchcards(card, ref copies);

            total += copies[card.Id];
        }

        Console.WriteLine($"The total number of Scratchcards is {total}");
    }

    public static void CalculateScratchcards(Card card, ref Dictionary<int, int> copies)
    {
        for (int i = card.Id + 1; i <= card.Id + card.MatchingNumbers; i++)
        {
            if (!copies.TryAdd(i, copies[card.Id]))
            {
                copies[i] += copies[card.Id];
            }
        }
    }
}

class Card
{
    public int Id { get; set; }
    public int[] Numbers { get; set; }
    public int[] WinningNumbers { get; set; }
    public int MatchingNumbers => Numbers.Intersect(WinningNumbers).Count();
    public int Points
    {
        get
        {
            if (MatchingNumbers <= 0) return 0;

            return (int)Math.Pow(2, MatchingNumbers - 1);
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