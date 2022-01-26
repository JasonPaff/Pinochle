using Microsoft.Xna.Framework.Input;
using Nez;
using System;

namespace Pinochle.Components
{
    public class PressKeyToPerformAction : Component, IUpdatable
    {
        private readonly Keys _key;
        private readonly Action<Entity> _action;

        public PressKeyToPerformAction(Keys key, Action<Entity> action)
        {
            _key = key;
            _action = action;
        }

        void IUpdatable.Update()
        {          
            if (Input.IsKeyPressed(_key))
                _action(Entity);
        }
    }
}
