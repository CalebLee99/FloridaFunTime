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

        public override void Move()
        {
            // This needs work...
            currentPosition = Controller.MovementDirection;
            this.Speed();
            if (currentPosition != Vector2.Zero)
            {
                //currentPosition = Vector2.Normalize(currentPosition); //Look into this (RESEARCH)
                Debug.WriteLine("Speed: " + speed);
                Debug.WriteLine("position x " + currentPosition.X);
                Debug.WriteLine("position y " + currentPosition.Y);
                // currentPosition += currentPosition * speed * Globals.Time;
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
