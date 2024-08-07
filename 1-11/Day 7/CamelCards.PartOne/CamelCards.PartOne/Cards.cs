using System.ComponentModel;

namespace CamelCards.PartOne
{
    internal enum Cards
    {
        None = 0,
        [Description("2")]
        Two = 2,
        [Description("3")]
        Three = 3,
        [Description("4")]
        Four = 4,
        [Description("5")]
        Five = 5,
        [Description("6")]
        Six = 6,
        [Description("7")]
        Seven = 7,
        [Description("8")]
        Eight = 8,
        [Description("9")]
        Nine = 9,
        [Description("T")]
        Ten = 10,
        [Description("J")]
        Jack = 11,
        [Description("Q")]
        Queen = 12,
        [Description("K")]
        King = 13,
        [Description("A")]
        Ace = 14
    }

    internal enum HandTypes
    {
        None = 0,
        [Description("High Card")]
        HighCard = 1,
        [Description("One Pair")]
        OnePair = 2,
        [Description("Two Pair")]
        TwoPair = 3,
        [Description("Three of a Kind")]
        ThreeOfAKind = 4,
        [Description("Full House")]
        FullHouse = 5,
        [Description("Four of a Kind")]
        FourOfAKind = 6,
        [Description("Five of a Kind")]
        FiveOfAKind = 7,

    }

    internal static class CardsExtension
    {
        internal static Cards ToCardsEnum(this char cardChar)
        {
            foreach (var field in typeof(Cards).GetFields())
            {
                if (field.GetCustomAttributes(typeof(DescriptionAttribute), false) is DescriptionAttribute[] descriptionAttributes)
                {
                    if (descriptionAttributes.Any() && descriptionAttributes[0].Description == cardChar.ToString())
                    {
                        return (Cards)field.GetValue(null)!;
                    }
                }
            }

            return default;
        }
    }
}
