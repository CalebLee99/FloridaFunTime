using FlameShotGame;
using Microsoft.VisualBasic.Devices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D9;
using SharpDX.DirectWrite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlameShotGame
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
            this.speed = 200;
            this._shooting = false;
        }

        public void InitializePosition(Vector2 initialPosition)
        {
            this.currentPosition = initialPosition;
        }
        public void Speed()
        {
            this.speed = Controller.PlayerSpeed;
        }

        public void Move()
        {
            currentPosition = Controller.MovementDirection;

            if (currentPosition != Vector2.Zero)
            {
                currentPosition = Vector2.Normalize(currentPosition);
                currentPosition += currentPosition * speed * Globals.Time;
            }
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
