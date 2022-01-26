using Nez;
using Pinochle.Enums;
using System;
using System.Collections.Generic;

namespace Pinochle.Models
{
    public class PinochleDeck
    {
        public List<Card> PinochleCards { get; set; }

        public PinochleDeck()
        {
            PinochleCards = new List<Card>
            {
                // spades
                new Card(Suit.Spade, Rank.Ten, true),
                new Card(Suit.Spade, Rank.Jack),
                new Card(Suit.Spade, Rank.Queen),
                new Card(Suit.Spade, Rank.King, true),
                new Card(Suit.Spade, Rank.Ace, true),
                new Card(Suit.Spade, Rank.Ten, true),
                new Card(Suit.Spade, Rank.Jack),
                new Card(Suit.Spade, Rank.Queen),
                new Card(Suit.Spade, Rank.King, true),
                new Card(Suit.Spade, Rank.Ace, true),
                new Card(Suit.Spade, Rank.Ten, true),
                new Card(Suit.Spade, Rank.Jack),
                new Card(Suit.Spade, Rank.Queen),
                new Card(Suit.Spade, Rank.King, true),
                new Card(Suit.Spade, Rank.Ace, true),
                new Card(Suit.Spade, Rank.Ten, true),
                new Card(Suit.Spade, Rank.Jack),
                new Card(Suit.Spade, Rank.Queen),
                new Card(Suit.Spade, Rank.King, true),
                new Card(Suit.Spade, Rank.Ace, true),

                // clubs
                new Card(Suit.Club, Rank.Ten, true),
                new Card(Suit.Club, Rank.Jack),
                new Card(Suit.Club, Rank.Queen),
                new Card(Suit.Club, Rank.King, true),
                new Card(Suit.Club, Rank.Ace, true),
                new Card(Suit.Club, Rank.Ten, true),
                new Card(Suit.Club, Rank.Jack),
                new Card(Suit.Club, Rank.Queen),
                new Card(Suit.Club, Rank.King, true),
                new Card(Suit.Club, Rank.Ace, true),
                new Card(Suit.Club, Rank.Ten, true),
                new Card(Suit.Club, Rank.Jack),
                new Card(Suit.Club, Rank.Queen),
                new Card(Suit.Club, Rank.King, true),
                new Card(Suit.Club, Rank.Ace, true),
                new Card(Suit.Club, Rank.Ten, true),
                new Card(Suit.Club, Rank.Jack),
                new Card(Suit.Club, Rank.Queen),
                new Card(Suit.Club, Rank.King, true),
                new Card(Suit.Club, Rank.Ace, true),

                // hearts
                new Card(Suit.Heart, Rank.Ten, true),
                new Card(Suit.Heart, Rank.Jack),
                new Card(Suit.Heart, Rank.Queen),
                new Card(Suit.Heart, Rank.King, true),
                new Card(Suit.Heart, Rank.Ace, true),
                new Card(Suit.Heart, Rank.Ten, true),
                new Card(Suit.Heart, Rank.Jack),
                new Card(Suit.Heart, Rank.Queen),
                new Card(Suit.Heart, Rank.King, true),
                new Card(Suit.Heart, Rank.Ace, true),
                new Card(Suit.Heart, Rank.Ten, true),
                new Card(Suit.Heart, Rank.Jack),
                new Card(Suit.Heart, Rank.Queen),
                new Card(Suit.Heart, Rank.King, true),
                new Card(Suit.Heart, Rank.Ace, true),
                new Card(Suit.Heart, Rank.Ten, true),
                new Card(Suit.Heart, Rank.Jack),
                new Card(Suit.Heart, Rank.Queen),
                new Card(Suit.Heart, Rank.King, true),
                new Card(Suit.Heart, Rank.Ace, true),

                // diamonds
                new Card(Suit.Diamond, Rank.Ten, true),
                new Card(Suit.Diamond, Rank.Jack),
                new Card(Suit.Diamond, Rank.Queen),
                new Card(Suit.Diamond, Rank.King, true),
                new Card(Suit.Diamond, Rank.Ace, true),
                new Card(Suit.Diamond, Rank.Ten, true),
                new Card(Suit.Diamond, Rank.Jack),
                new Card(Suit.Diamond, Rank.Queen),
                new Card(Suit.Diamond, Rank.King, true),
                new Card(Suit.Diamond, Rank.Ace, true),
                new Card(Suit.Diamond, Rank.Ten, true),
                new Card(Suit.Diamond, Rank.Jack),
                new Card(Suit.Diamond, Rank.Queen),
                new Card(Suit.Diamond, Rank.King, true),
                new Card(Suit.Diamond, Rank.Ace, true),
                new Card(Suit.Diamond, Rank.Ten, true),
                new Card(Suit.Diamond, Rank.Jack),
                new Card(Suit.Diamond, Rank.Queen),
                new Card(Suit.Diamond, Rank.King, true),
                new Card(Suit.Diamond, Rank.Ace, true)
            };
        }

        /// <summary>
        /// logs the cards in the deck to the console
        /// </summary>
        public void LogDeck()
        {
            Debug.Log($"logging cards in deck ({DateTime.Now.ToLongTimeString()})");
            for (byte c = 0; c < PinochleCards.Count; c++)
                Debug.Log($"#{c + 1}. {PinochleCards[c].Rank} of {PinochleCards[c].Suit}'s");
        }

        /// <summary>
        /// shuffles the deck of cards
        /// </summary>
        public void Shuffle()
        {
            ListExt.Shuffle(PinochleCards);
            Debug.Log($"deck was shuffled ({DateTime.Now.ToLongTimeString()})");
        }
    }
}