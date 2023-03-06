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
        private Vector2 _velocity { get; set; }


        public Player(Texture2D texture, Vector2 pos) : base(texture, pos)
        {
            this._currentHealth = 3;
            this._maxHealth = 3;
            this._shooting = false;
            _velocity = Vector2.Zero;
        }

        public void InitializePosition(Vector2 initialPosition)
        {
            this.currentPosition = initialPosition;
        }

        public void Speed()
        {
            this.speed = Controller.PlayerSpeed;
        }

        public override void Move()
        {
            // This needs work...
            _velocity = Controller.MovementDirection;
            Speed();
            Debug.WriteLine("Speed: " + speed);
            Debug.WriteLine("position x " + currentPosition.X);
            Debug.WriteLine("position y " + currentPosition.Y);
            Debug.WriteLine("Velocity " + _velocity);
            if (_velocity != Vector2.Zero)
            {
                _velocity.Normalize();
            }
            currentPosition += _velocity * this.speed;
            _velocity = Vector2.Zero;
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
