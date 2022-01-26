using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Nez;
using Pinochle.Entities;
using Pinochle.Helpers;
using Pinochle.Models;

namespace Pinochle.Scenes
{
    public class TwoPlayerTableScene : BaseScene
    {
        private PinochleDeck _deck;
        private List<Card> _opponentHand;
        
        private ushort _updateOrder = 100;
        private float _cardLayerDepth = 0.99f;
        private const int PlayerHandStartingPositionX = 150;
        private const int PlayerHandStartingPositionY = 75;
        private const int PlayerCardSpacing = 50;

        public float DiscardLayerDepth { get; set; }
        public int DiscardRenderLayer { get; private set; }
        public bool IsPlayersTurn { get; private set; }

        public override void Initialize()
        {
            base.Initialize();
            
            _deck = new PinochleDeck();
            _deck.Shuffle();

            // for discard pile
            DiscardLayerDepth = 0.99f;
            DiscardRenderLayer = 90;

            // grab 20 hands for the player and remove them from the deck
            var hand = _deck.PinochleCards.RandomItems(20);
            foreach (var card in hand)
                _deck.PinochleCards.Remove(card);

            // grab 20 hands for the opponent and remove them from the deck
            _opponentHand = _deck.PinochleCards.RandomItems(20);
            foreach (var card in _opponentHand)
                _deck.PinochleCards.Remove(card);

            // create the card entities for the scene
            CreatePlayerCardEntitiesFromHand(hand);

            // flag as players turn
            IsPlayersTurn = true;            
        }
        
        private void CreatePlayerCardEntitiesFromHand(List<Card> hand)
        {
            foreach (var card in hand)
            {
                // create new entity for the card
                PlayerPinochleCard newCard = new(CardHelper.GetNameFromRankAndSuit(card), card, _cardLayerDepth);
                newCard.SetUpdateOrder(_updateOrder);
                newCard.SetScale(2.0f);
                AddEntity(newCard);
                
                // adjust card layer so cards are drawn left to right overlapping
                _cardLayerDepth -= 0.01f;

                // adjust update order so mouse selection behavior selects the top car
                // when mousing over 2 overlapping cards in the hand
                _updateOrder--;
            }

            // adjust the starting positions to be spaced
            // out to form a 'fan' of the cards in the hand
            var cards = EntitiesOfType<PlayerPinochleCard>();
            for (var c = 0; c < cards.Count; c++)
            {
                Vector2 startingPosition = new(PlayerHandStartingPositionX + (PlayerCardSpacing * c), 
                    Screen.Height - PlayerHandStartingPositionY);
                if (cards[c].IsPlayable)
                    cards[c].SetPosition(startingPosition);
            }
        }

        public void PlayCard(PlayerPinochleCard card)
        {
            // flag card as having been played
            card.IsPlayable = false;

            IsPlayersTurn = false;

        }
    }
}