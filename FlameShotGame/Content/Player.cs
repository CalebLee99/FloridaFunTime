﻿using Microsoft.VisualBasic.Devices;
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

namespace FlameShotGame.Content
{
    public class Player
    {
        private int _currentHealth;
        private int _maxHealth;
        private Vector2 _position;
        private bool _slow_on;
        private float _regularSpeed;
        private float _slowSpeed;
        private Texture2D _playerTexture;

        public Player()
        {
            this._currentHealth = 3;
            this._maxHealth = 3;
            this._slow_on = false;
            this._regularSpeed = 5;
            this._slowSpeed = 2;
        }

        public void setPlayerTexture(Texture2D playerTexture)
        {
            this._playerTexture = playerTexture;
        }

        public Texture2D getPlayerTexture()
        {
            return this._playerTexture;
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
