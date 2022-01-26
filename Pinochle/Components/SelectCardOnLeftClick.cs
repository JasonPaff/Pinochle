using Microsoft.Xna.Framework;
using Nez;
using Nez.Tweens;
using Pinochle.Entities;
using Pinochle.Scenes;

namespace Pinochle.Components
{
    public  class SelectCardOnLeftClick : Component, IUpdatable
    {
        private PinochleCardSprite _cardRenderer; // the card we are selecting on
        private TwoPlayerTableScene _scene;
        public override void OnAddedToEntity()
        {
            _cardRenderer = Entity.GetComponent<PinochleCardSprite>();
            _scene = Entity.Scene as TwoPlayerTableScene;
        }

        /// <summary>
        /// Looks for a discard by checking the left mouse button to be released from
        /// a click on a nudged card while the mouse is over the card.
        /// If found the nudge is removed and the render info for the
        /// card is adjusted to account for being discarded
        /// </summary>
        public void Update()
        {
            if (!_scene.IsPlayersTurn) return;
            if (!Input.LeftMouseButtonReleased) return;
            if (!Entity.GetComponent<NudgeOnMouseOver>().IsNudged) return;
            
            Vector2 mouse = new(Input.ScaledMousePosition.X, Input.ScaledMousePosition.Y);
            if (!_cardRenderer.Bounds.Contains(mouse.X, mouse.Y)) return;
            
            RemoveNudge();

            _cardRenderer.SetRenderLayer(_scene.DiscardRenderLayer);
            _cardRenderer.SetLayerDepth(_scene.DiscardLayerDepth -= 0.01f);
            
            StartTween();
            
            var scene = Entity.Scene as TwoPlayerTableScene;
            scene?.PlayCard(Entity as PlayerPinochleCard);
        }
        
        private void StartTween()
        {
            Entity.TweenPositionTo(Screen.Center, 0.2f).Start();
        }
    
        /// <summary>
        /// End the nudge on the card and
        /// disable the card from future activity
        /// </summary>
        private void RemoveNudge()
        {
            var nudgeComp = Entity.GetComponent<NudgeOnMouseOver>();
            nudgeComp.IsNudged = false;
            //nudgeComp.SetEnabled(false);
        }
    }
}