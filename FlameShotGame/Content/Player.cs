using Microsoft.Xna.Framework;
using SharpDX.Direct3D9;
using SharpDX.DirectWrite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlameShotGame.Content
{
    internal class Player
    {
        private int _currentHealth;
        private int _maxHealth;
        private Point _position;
        private bool _slow_on;
        private int _regularSpeed;
        private int _slowSpeed;

        public Player()
        {
            this._currentHealth = 3;
            this._maxHealth = 3;
            this._slow_on = false;
            this._regularSpeed = 5;
            this._slowSpeed = 2;
        }

        public void move()
        {
            return;
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
