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
    public class Controller : GameManager
    {
        private static Controller uniqueInstance = new Controller();

        // attributes
        private static Vector2 _movementDirection;
        private static int _playerSpeed;
        private static bool _isShooting;

        public static Vector2 MovementDirection => _movementDirection;
        public static int PlayerSpeed => _playerSpeed;
        public static bool IsShooting => _isShooting;
        
        public override void Update()
        {
            KeyboardState ks = Keyboard.GetState();
            MouseState ms = Mouse.GetState();
            // Switch to using a data structure instead of conditionals.
            if (ks.IsKeyDown(Keys.W))
            {
                _movementDirection.Y -= 1;
            }
            if (ks.IsKeyDown(Keys.S))
            {
                _movementDirection.Y += 1;
            }  
            if (ks.IsKeyDown(Keys.A))
            {
                _movementDirection.X -= 1;
            }
            if (ks.IsKeyDown(Keys.D))
            {
                _movementDirection.X += 1;
            }
            if (ks.IsKeyDown(Keys.LeftShift))
            {
                _playerSpeed = 2; // Use global variables??
            }
            if (ks.IsKeyUp(Keys.LeftShift))
            {
                _playerSpeed = 4; // Use global variables??
            }
            if (ks.IsKeyDown(Keys.Space))
            {
                _isShooting = true;
            }
        }

        public static new Controller Instance()
        {
            return uniqueInstance;
        }

        protected Controller() 
        { 
            _movementDirection = Vector2.Zero;
            _playerSpeed = 200;
            _isShooting = false;
        }
    }
}
