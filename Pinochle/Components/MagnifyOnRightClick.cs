using Microsoft.Xna.Framework;
using Nez;
using Nez.Sprites;
using Pinochle.Enums;
using System.Linq;

namespace Pinochle.Components
{
    public class MagnifyOnRightClick : Component, IUpdatable
    {
        private bool _magnifyRemovedThisFrame;
        private float _startingLayerDepth;
        private readonly SpriteRenderer _spriteRenderer;
        private Vector2 _startingScale;
        private readonly Vector2 _zoomScale;
        
        private bool IsMagnified { get; set; }

        public MagnifyOnRightClick(SpriteRenderer spriteRenderer)
        {
            _spriteRenderer = spriteRenderer;
            _zoomScale = new Vector2(2.5f);
        }

        /// <summary>
        /// Returns a magnified card to its normal state
        /// </summary>
        private void RemoveMagnify()
        {                    
            _spriteRenderer.Transform.SetScale(_startingScale);
            _spriteRenderer.LayerDepth = _startingLayerDepth;
            IsMagnified = false;
            _magnifyRemovedThisFrame = true;
        }

        /// <summary>
        /// Increases the size of the card for easier viewing
        /// </summary>
        private void Magnify()
        {
            // save starting scale and set new scale and flag
            IsMagnified = true;
            _startingScale = _spriteRenderer.Transform.Scale;
            _startingLayerDepth = _spriteRenderer.LayerDepth;
            _spriteRenderer.LayerDepth = 0;
            _spriteRenderer.Transform.SetScale(_zoomScale);
        }

        public void Update()
        {
            // get mouse position
            float mouseX = Input.MousePosition.X;
            float mouseY = Input.MousePosition.Y;

            // bounding box for sprite
            RectangleF bounds = _spriteRenderer.Bounds;

            // save last frames magnified and click stat
            bool wasMagnifiedLastFrame = IsMagnified;

            // reset tracker
            _magnifyRemovedThisFrame = false;

            // currently magnified
            if (IsMagnified)
            {
                // remove magnification when a click happens or the mouse leaves the card
                if (Input.LeftMouseButtonPressed || Input.RightMouseButtonPressed 
                    || mouseX <= bounds.Left || mouseX >= bounds.Right
                    || mouseY <= bounds.Top || mouseY >= bounds.Bottom)                    
                {
                    RemoveMagnify();
                }
            }

            // bail if we are already magnifying another card
            bool anyMagnified = Entity.Scene.FindEntitiesWithTag((int)EntityTags.PinochleCard)
                .Any(i => i.GetComponent<MagnifyOnRightClick>().IsMagnified);

            // catch a new magnification attempt
            // mouse is over the sprite and right clicked
            // sprite must have been unmagnified last frame
            if (mouseX >= bounds.Left && mouseX <= bounds.Right
                && mouseY >= bounds.Top && mouseY <= bounds.Bottom
                && !wasMagnifiedLastFrame && Input.RightMouseButtonPressed)
            {
                if (anyMagnified || _magnifyRemovedThisFrame) return;

                // disable the other components while we are magnifying
                Magnify();
            }
        }
    }
}
