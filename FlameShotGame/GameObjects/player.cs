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
        private Vector2 _position { get; set; }
        private bool _slow_on { get; set; }
        private float _regularSpeed { get; set; }
        private float _slowSpeed { get; set; }
        private Texture2D _playerTexture { get; set; }


        public Player(Texture2D texture, Vector2 pos) : base(texture, pos)
        {
            this._currentHealth = 3;
            this._maxHealth = 3;
            this._slow_on = false;
            this._regularSpeed = 5;
            this._slowSpeed = 2;
        }

        public void initializePosition(Vector2 initialPosition)
        {
            this._position = initialPosition;
        }

        public void move()
        {
        }

        public void updateHealth()
        {
            return;
        }

        /// <summary>
        /// Switches the speed of the player when this function gets called.
        /// </summary>
        public void switchSpeed()
        {
            this._slow_on = !this._slow_on;
        }

        public void shoot()
        {
            return;
        }

    }
}
