using AdventOfCode.Common.Extensions;
using System.Text.Json.Serialization;

namespace CamelCards.PartTwo
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
            var cardsDict = new Dictionary<Cards, int>();

            foreach (var card in Cards)
            {
                if (!cardsDict.TryAdd(card, 1)) cardsDict[card]++;
            }

            int[] repeatedCards = ToOrderedArray(cardsDict, ExtractJokers(cardsDict));

            return repeatedCards[0] switch
            {
                5 => HandTypes.FiveOfAKind,
                4 => HandTypes.FourOfAKind,
                3 when repeatedCards[1] == 2 => HandTypes.FullHouse,
                3 => HandTypes.ThreeOfAKind,
                2 when repeatedCards[1] == 2 => HandTypes.TwoPair,
                2 => HandTypes.OnePair,
                _ => HandTypes.HighCard
            };


            int ExtractJokers(Dictionary<Cards, int> cardsDict)
            {
                int jokerCount = Cards.Where(c => c == PartTwo.Cards.Joker).Count();
                cardsDict.Remove(PartTwo.Cards.Joker);
                return jokerCount;
            }
            static int[] ToOrderedArray(Dictionary<Cards, int> cardsDict, int jokerCount)
            {
                var repeatedCards = cardsDict.Select(c => c.Value).OrderByDescending(c => c).ToArray();
                if (repeatedCards.Length == 0) repeatedCards = [0];
                repeatedCards[0] += jokerCount;
                return repeatedCards;
            }
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
