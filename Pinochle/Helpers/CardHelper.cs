using Nez;
using Pinochle.Components;
using Pinochle.Enums;
using Pinochle.Models;
using System.Collections.Generic;
using System.Linq;

namespace Pinochle.Helpers
{
    public static class CardHelper
    {
        public const string CardBackFileName = "Content/cards/card_back.png";

        public static string GetCardTextureFilename(Card card)
        {
            const string fileName = "Content/cards/card_";
            var suit = "";
            var rank = "";

            suit = card.Suit switch
            {
                Suit.Spade => "spades_",
                Suit.Club => "clubs_",
                Suit.Heart => "hearts_",
                Suit.Diamond => "diamonds_",
                _ => suit
            };

            rank = card.Rank switch
            {
                Rank.Ten => "T",
                Rank.Jack => "J",
                Rank.Queen => "Q",
                Rank.King => "K",
                Rank.Ace => "A",
                _ => rank
            };

            return $"{fileName}{suit}{rank}.png";
        }

        public static string GetCardTextureFilename(Rank rank, Suit suit)
        {
            Card card = new (suit, rank);
            return GetCardTextureFilename(card);
        }
        
        public static string GetNameFromRankAndSuit(Card card)
        {
            var suit = "";
            var rank = "";

            suit = card.Suit switch
            {
                Suit.Spade => "Spades",
                Suit.Club => "Clubs",
                Suit.Heart => "Hearts",
                Suit.Diamond => "Diamonds",
                _ => suit
            };

            rank = card.Rank switch
            {
                Rank.Ten => "Ten",
                Rank.Jack => "Jack",
                Rank.Queen => "Queen",
                Rank.King => "King",
                Rank.Ace => "Ace",
                _ => rank
            };

            return $"{rank}Of{suit}";
        }
    }
}
