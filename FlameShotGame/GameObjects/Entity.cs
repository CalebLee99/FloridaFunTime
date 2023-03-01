﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace FlameShotGame
{
    public class Entity
    {
        protected readonly Texture2D texture;
        protected readonly Vector2 spawn;
        public Vector2 currentPosition { get; set; }
        public float speed { get; set; }
        Globals globals = Globals.instance();

        // Constructor
        public Entity(Texture2D texture, Vector2 pos)
        {
            this.texture = texture;
            this.currentPosition = pos;
            this.speed = 100; // Change this to a global variable defaultSpeed.
            this.spawn = new(texture.Width / 2, texture.Height / 2); // Also change this to global variable defaultSpawnPoint.

        }
        public void Draw()
        {
            globals.SpriteBatch.Draw(this.texture, this.currentPosition, null, Color.White, 1, this.spawn, 1, SpriteEffects.None, 1);
        }
    }    
}
