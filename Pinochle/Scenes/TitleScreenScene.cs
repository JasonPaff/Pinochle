using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Nez;
using Nez.Sprites;
using Pinochle.Components;

namespace Pinochle.Scenes
{
    public class TitleScreenScene : BaseScene
    {
        public override void Initialize()
        {
            base.Initialize();

            SetDesignResolution(1280, 720, SceneResolutionPolicy.ShowAllPixelPerfect);
            Screen.SetSize(1280, 720);
            
            ClearColor = Color.Black;

            Texture2D titleLogoTexture = Content.LoadTexture("Content/title/title.png");
            Entity titleLogoEntity = CreateEntity("title", new Vector2(Screen.Width / 2f, Screen.Height / 4f));
            titleLogoEntity.AddComponent(new SpriteRenderer(titleLogoTexture));

            Texture2D startButtonTexture = Content.LoadTexture("Content/title/start_button.png");
            Entity startButtonEntity = CreateEntity("startButton", new Vector2(Screen.Width / 2f, Screen.Height / 1.5f));
            startButtonEntity.AddComponent(new SpriteRenderer(startButtonTexture));
            startButtonEntity.AddComponent(new BoxCollider());
            startButtonEntity.Transform.SetScale(0.6f);

            startButtonEntity.AddComponent(new PressKeyToPerformAction(Keys.Enter, e => StartGame()));
        }

        private static void StartGame()
        {
            Debug.Log($"new game started ({DateTime.Now.ToLongTimeString()})");
            Core.StartSceneTransition(new FadeTransition(() => new TwoPlayerTableScene()));
        }
    }
}