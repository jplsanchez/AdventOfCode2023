using AdventOfCode.Common.Extensions;
using System.Text.Json.Serialization;

namespace CamelCards.PartOne
{
    internal class Hand
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public HandTypes HandType { get; set; }
        public List<Cards> Cards { get; set; }
        public int Bid { get; set; }

        public Hand(List<Cards> cards, int bid)
        {
            Cards = cards;
            Bid = bid;
            HandType = GetHandType();
        }

        private HandTypes GetHandType()
        {
            var repeatedCards = new Dictionary<Cards, int>();

            foreach (var card in Cards)
            {
                if (!repeatedCards.TryAdd(card, 1)) repeatedCards[card]++;
            }

            return repeatedCards switch
            {
                var cards when cards.Any(c => c.Value == 5) => HandTypes.FiveOfAKind,
                var cards when cards.Any(c => c.Value == 4) => HandTypes.FourOfAKind,
                var cards when cards.Any(c => c.Value == 3) && cards.Any(c => c.Value == 2) => HandTypes.FullHouse,
                var cards when cards.Any(c => c.Value == 3) => HandTypes.ThreeOfAKind,
                var cards when cards.Where(c => c.Value == 2).Count().Equals(2) => HandTypes.TwoPair,
                var cards when cards.Any(c => c.Value == 2) => HandTypes.OnePair,
                _ => HandTypes.HighCard
            };
        }

        public bool IsHigher(Hand other)
        {
            if (HandType > other.HandType) return true;
            if (HandType < other.HandType) return false;
            for (int i = 0; i < Cards.Count; i++)
            {
                if (Cards[i] > other.Cards[i]) return true;
                if (Cards[i] < other.Cards[i]) return false;
            }
            return false;
        }
    }

    internal static class HandListExtension
    {
        internal static List<Hand> OrderByAsc(this List<Hand> list)
        {
            List<Hand>? orderedList = [];

            foreach (var hand in list)
            {
                orderedList.Add(hand);

                for (int i = orderedList.Count - 1; i > 0; i--)
                {
                    if (i - 1 < 0 || !orderedList[i].IsHigher(orderedList[i - 1])) break;

                    orderedList.Swap(i, i - 1);
                }
            }
            return orderedList;
        }
    }
}
