using Microsoft.Xna.Framework.Graphics;
using Nez;
using Pinochle.Components;
using Pinochle.Enums;
using Pinochle.Helpers;
using Pinochle.Models;

namespace Pinochle.Entities
{
    public class PinochleCard : Entity
    {
        protected Card Card { get; set; }

        protected PinochleCard(string name, Card card) : base (name)
        {
            Card = card;
            Tag = (int)EntityTags.PinochleCard;
        }

        /// <summary>
        /// flips the card texture,
        /// true for the front,
        /// false for the back
        /// </summary>
        /// <param name="facing">true for front, false for back</param>
        public void FlipCard(bool facing)
        {
            // implement here maybe, we'll see once we figure it out
        }
    }
}