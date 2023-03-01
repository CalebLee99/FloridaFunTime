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
        /*public static Vector2 MovementDirection { get; set; }*/
        private static Vector2 MovementDirection;

        public static void Update()
        {
            KeyboardState ks = Keyboard.GetState();
            // Switch to using a data structure instead of conditionals.
            if (ks.IsKeyDown(Keys.W))
            {
                MovementDirection.Y--;
            }
            if (ks.IsKeyDown(Keys.S))
            {
                MovementDirection.Y++;
            }  
            if (ks.IsKeyDown(Keys.A))
            {
                MovementDirection.X--;
            }
            if (ks.IsKeyDown(Keys.D))
            {
                MovementDirection.X++;
            }
        }

        public static Controller instance()
        {
            return uniqueInstance;
        }

        private Controller() 
        { 
            MovementDirection = Vector2.Zero;
        }
    }
}
