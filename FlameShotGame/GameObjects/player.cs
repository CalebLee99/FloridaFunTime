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
        Globals global = Globals.Instance();

        public int _currentHealth { get; set; }
        private int _maxHealth { get; set; }
        private Texture2D _playerTexture { get; set; }
        public HealthBar PlayerHealthBar { get; set; }
        private bool _shooting { get; set; }
        private bool _invincible { get; set; }

        public Player(Texture2D texture, Vector2 pos) : base(texture, pos)
        {
            this._currentHealth = 5;
            this._maxHealth = 5;
            this._shooting = Controller.IsShooting;
            this._invincible = false;
            this.PlayerHealthBar = new HealthBar(global.Content.Load<Texture2D>("Sprites/health_5"), new Vector2(0, 0));
        }

        public void InitializePosition(Vector2 initialPosition)
        {
            this.currentPosition = initialPosition;
        }

        public override void Move()
        {
            var currentDirection = Controller.MovementDirection;

            this.Update();
            this.PlayerHealthBar.Update();

            //currentDirection = Vector2.Normalize(currentDirection);
            //Debug.WriteLine("CURRENT DIRECTION x " + currentDirection.X);
            //Debug.WriteLine("CURRENT DIRECTION y " + currentDirection.Y);

            this.currentPosition += currentDirection * Controller.currentPlayerSpeed * Globals.Time;
            //Debug.WriteLine("Speed: " + Controller.currentPlayerSpeed);
            //Debug.WriteLine("position x " + currentPosition.X);
            //Debug.WriteLine("position y " + currentPosition.Y);
        }

        public override void Update()
        {
            if (this._currentHealth == 0)
            {
                Environment.Exit(0);
            }
            base.Update();
        }
        public void UpdateHealth(int change)
        {
            this._currentHealth = this._currentHealth + change;
            Debug.WriteLine("PLAYER HEALTH " + this._currentHealth);
        }

        public void Shoot()
        {
            return;
        }

    }
}
