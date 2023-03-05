using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FlameShotGame
{
    public class Controller
    {
        private static Controller uniqueInstance = new Controller();
        // attributes
        private static Vector2 _movementDirection;
        public static Vector2 MovementDirection => _movementDirection;

        public static void Update()
        {
            KeyboardState ks = Keyboard.GetState();
            // Switch to using a data structure instead of conditionals.
            if (ks.IsKeyDown(Keys.W))
            {
                _movementDirection.Y--;
            }
            if (ks.IsKeyDown(Keys.S))
            {
                _movementDirection.Y++;
            }  
            if (ks.IsKeyDown(Keys.A))
            {
                _movementDirection.X--;
            }
            if (ks.IsKeyDown(Keys.D))
            {
                _movementDirection.X++;
            }
        }

        public static Controller instance()
        {
            return uniqueInstance;
        }

        private Controller() 
        { 
            _movementDirection = Vector2.Zero;
        }
    }
}
