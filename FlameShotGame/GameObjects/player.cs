using FlameShotGame.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;
using System;
using System.Diagnostics;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace FlameShotGame.GameObjects
{
    public class Player : Entity
    {
        Globals global = Globals.Instance();

        public int _currentHealth { get; set; }
        private int _maxHealth { get; set; }
        private Texture2D _playerTexture { get; set; }
        private Texture2D _playerInvincibleTexture { get; set; }
        public HealthBar PlayerHealthBar { get; set; }
        public bool playerDamaged = false;
        private bool _shooting { get; set; }
        private bool _invincible { get; set; }
        public bool Invincible => _invincible;
        private int _frameWhereDamageOccurred { get; set; }
        private int _invincibilityFrames { get; set; }
        private readonly Animation _anim;

        public Player(Texture2D texture, Vector2 pos) : base(texture, pos)
        {
            this._currentHealth = 5;
            this._maxHealth = 5;
            this._shooting = Controller.IsShooting;
            this._invincible = false;
            this._frameWhereDamageOccurred = -180;
            this._playerInvincibleTexture = global.Content.Load<Texture2D>("Sprites/player_animation");
            this._anim = new Animation(_playerInvincibleTexture, 2, 0.1f);
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

            if (this._currentHealth < this._maxHealth)
            {
                this.playerDamaged = true;
            }
            else
            {
                this.playerDamaged = false;
            }

            // Invincibility period has run out
            if ((this._frameWhereDamageOccurred + _invincibilityFrames < Globals.FrameCounter) && (this._invincible == true))
            {
                this._invincible = false;
            }
            _anim.Update();
            base.Update();
        }

        public void Draw()
        {
            if (Globals.player.Invincible == true)
            {
                Globals.player._anim.Draw(this.currentPosition);
            }
            else
            {
                global.SpriteBatch.Draw(this.texture, this.currentPosition, Color.White);
            }
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

        public void PlayerTakesDamage(int damage)
        {
            this.UpdateHealth(damage);
            this.currentPosition = new Vector2(350, 300);
            ToggleInvincibility();
            this.SetInvincibilityFrames(150);
            this._frameWhereDamageOccurred = Globals.FrameCounter;
        }

        public void ToggleInvincibility()
        {
            this._invincible = !this._invincible;
        }

        public void SetInvincibilityFrames(int frames)
        {
            this._invincibilityFrames = frames;
        }
    }
}
