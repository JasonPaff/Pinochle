using Microsoft.Xna.Framework.Graphics;
using Nez.Sprites;
using Nez.Textures;

namespace Pinochle.Components
{
    public class PinochleCardSprite : SpriteRenderer
    {
        private bool _isFlippedOver;
        private Texture2D FrontTexture { get; set; }
        private Texture2D BackTexture { get; set; }

        public bool IsFlippedOver
        {
            get => _isFlippedOver;
            set
            {
                if (value == _isFlippedOver) return;

                var past = _isFlippedOver;
                _isFlippedOver = value;

                switch (IsFlippedOver)
                {
                    case true when !past:
                        SetSprite(new Sprite(BackTexture));
                        break;
                    case false when past:
                        SetSprite(new Sprite(FrontTexture));
                        break;
                }
            }
        }
        
        public PinochleCardSprite(Texture2D frontTexture, Texture2D backTexture, float layerDepth)
        {
            FrontTexture = frontTexture;
            BackTexture = backTexture;
            SetSprite(new Sprite(frontTexture));
            LayerDepth = layerDepth;
            RenderLayer = 100;
        }
    }
}
