using Microsoft.Xna.Framework;
using Pinochle.Components;
using Pinochle.Helpers;
using Pinochle.Models;

namespace Pinochle.Entities
{
    public class PlayerPinochleCard : PinochleCard
    {
        private readonly float _layerDepth;

        public bool IsPlayable { get; set; }
        
        public PlayerPinochleCard(string name, Card card, float layerDepth) : base(name, card)
        {
            Card = card;
            _layerDepth = layerDepth;
            IsPlayable = true;
        }

        /// <summary>
        /// called when the entity is added to the scene
        /// </summary>
        public override void OnAddedToScene()
        {
            var textureFilename = CardHelper.GetCardTextureFilename(Card);
            var cardFrontTexture = Scene.Content.LoadTexture(textureFilename);
            var cardBackTexture = Scene.Content.LoadTexture(CardHelper.CardBackFileName);
                
            AddComponent(new PinochleCardSprite(cardFrontTexture, cardBackTexture, _layerDepth));
            AddComponent(new SelectCardOnLeftClick());
            AddComponent(new NudgeOnMouseOver(new Vector2(0, -30)));
        }
    }
}