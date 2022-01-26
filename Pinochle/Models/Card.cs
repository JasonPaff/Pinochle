using Pinochle.Enums;

namespace Pinochle.Models
{
    public class Card
    {
        public bool IsPoint { get; set; }
        public bool IsTrump { get; set; }
        public Rank Rank { get; set; }
        public Suit Suit { get; set; }

        public Card (Suit suit, Rank rank, bool isPoint = false, bool isTrump = false)
        {
            Suit = suit;
            Rank = rank;
            IsPoint = isPoint;
            IsTrump = isTrump;
        }
    }
}
