using FlameShotGame;
using FlameShotGame.Managers;
using Microsoft.VisualBasic.Devices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D9;
using SharpDX.DirectWrite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlameShotGame.GameObjects
{
    public class Player : Entity
    {
        private int _currentHealth { get; set; }
        private int _maxHealth { get; set; }
        private Texture2D _playerTexture { get; set; }
        private bool _shooting { get; set; }

        public Player(Texture2D texture, Vector2 pos) : base(texture, pos)
        {
            this._currentHealth = 3;
            this._maxHealth = 3;
            this._shooting = Controller.IsShooting;
        }

        public void InitializePosition(Vector2 initialPosition)
        {
            this.currentPosition = initialPosition;
        }

        public override void Move()
        {
            if (Controller.MovementDirection != Vector2.Zero)
            {
                Debug.WriteLine("Moving");
                var currentDirection = Vector2.Normalize(Controller.MovementDirection);
                Debug.WriteLine("CURRENT DIRECTION x " + currentDirection.X);
                Debug.WriteLine("CURRENT DIRECTION y " + currentDirection.Y);

                this.currentPosition += currentDirection * Controller.currentPlayerSpeed * Globals.Time;
                Debug.WriteLine("Speed: " + Controller.currentPlayerSpeed);
                Debug.WriteLine("position x " + currentPosition.X);
                Debug.WriteLine("position y " + currentPosition.Y); 
            }

            
        }

        public override void Update()
        {
            Move();
        }
        public void UpdateHealth()
        {
            return;
        }

        public void Shoot()
        {
            return;
        }

    }
}
