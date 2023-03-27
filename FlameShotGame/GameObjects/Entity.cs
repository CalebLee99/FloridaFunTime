using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace FlameShotGame.GameObjects
{
    public abstract class Entity
    {
        protected readonly Texture2D texture;
        protected readonly Vector2 spawn;
        public Vector2 currentPosition { get; set; }
        private Rectangle _hitbox;
        public bool HasShot;
        public float ShootCoolDownValue;
        public float ShootAccumulator;
        
        public Rectangle Hitbox 
        { 
            get => _hitbox;
            set => _hitbox = value;
        }

        public float speed { get; set; }
        Globals globals = Globals.Instance();

        // Constructor
        public Entity(Texture2D texture, Vector2 pos)
        {
            this.texture = texture;
            this.currentPosition = pos;
            this.speed = globals.defaultEntitySpeed; // Change this to a global variable defaultSpeed.
            this.spawn = new(texture.Width / 2, texture.Height / 2); // Also change this to global variable defaultSpawnPoint.

            this._hitbox = new Rectangle((int) pos.X, (int) pos.Y, (int) (texture.Width * 0.8), (int) (texture.Height * .8));

            // Want to change this to be a more global 

            this.ShootCoolDownValue = 2;

            this.ShootAccumulator = 0;

        }
        public void HasShotUpdate()
        {
            this.ShootAccumulator -= this.ShootCoolDownValue;
        }
        public abstract void Move();

        public virtual void Update()
        {
            this._hitbox.X = (int)currentPosition.X;
            this._hitbox.Y = (int)currentPosition.Y;
            this.ShootAccumulator += Globals.Time;
            
        }
        public void Draw()
        {
            globals.SpriteBatch.Draw(this.texture, this.currentPosition, Color.White);
        }
    }    
}
