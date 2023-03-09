using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using FlameShotGame.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FlameShotGame.Managers
{
    public class Controller
    {
        private static Controller uniqueInstance = new Controller();

        // attributes
        private static Vector2 _movementDirection;
        private static float _currentPlayerSpeed;
        private static bool _isShooting;

        private static float _defaultPlayerSpeed; // Global attribute for the default player speed.
        private static float _slowPlayerSpeed;    // Global attribute for the slow player speed.

        public static Vector2 MovementDirection => _movementDirection;
        public static float currentPlayerSpeed => _currentPlayerSpeed;
        public static bool IsShooting => _isShooting;
        public static float defaultPlayerSpeed => _defaultPlayerSpeed;
        public static float slowPlayerSpeed => _slowPlayerSpeed;
        
        public void Update()
        {
            KeyboardState ks = Keyboard.GetState();
            MouseState ms = Mouse.GetState();
            // Switch to using a data structure instead of conditionals.
            _movementDirection = Vector2.Zero;
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
            if (ks.IsKeyDown(Keys.LeftShift)) // Check to see if the key is down... then change player speed.
            {
                _currentPlayerSpeed = _slowPlayerSpeed;
            }
            if (ks.IsKeyUp(Keys.LeftShift)) // Check to see if the key is up... then change player speed.
            {
                _currentPlayerSpeed = _defaultPlayerSpeed;
            }
        }

        public static Controller Instance()
        {
            return uniqueInstance;            
        }

        protected Controller() 
        { 
            _movementDirection = Vector2.Zero;
            _defaultPlayerSpeed = 200;
            _slowPlayerSpeed    = 100;
            _currentPlayerSpeed = _defaultPlayerSpeed;
            _isShooting = false;

        }
    }
}
