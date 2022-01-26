using Nez;
using System;
using Pinochle.Scenes;

namespace Pinochle
{
    public class Game1 : Core
    {
        public Game1()
        {
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();

            Debug.Log($"game started ({DateTime.Now.ToLongTimeString()})");

            Scene = new TitleScreenScene();
        }
    }
}
