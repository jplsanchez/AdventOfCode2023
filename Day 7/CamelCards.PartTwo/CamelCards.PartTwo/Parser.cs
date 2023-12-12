namespace CamelCards.PartTwo
{
    internal static class Parser
    {
        internal static List<Hand> Parse(StreamReader input)
        {
            string? line;
            List<Hand> output = new();
            while ((line = input.ReadLine()) is not null)
            {
                List<Cards> cards = [];
                line.Split(" ")[0].ToCharArray().ToList().ForEach(c => cards.Add(c.ToCardsEnum()));

                var bid = int.Parse(line.Split(" ")[1]);
                output.Add(new(cards, bid));
            }

            return output;
        }
    }
}
