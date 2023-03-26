using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlameShotGame.GameObjects
{
    public class PlayerBullet : Bullet
    {
        Globals global = Globals.Instance();
        private Vector2 _MovementPath;
        public PlayerBullet(Texture2D texture, Vector2 pos, int damage) : base(texture, pos, damage)
        {
            // start from player position and go towards top of screen
            _MovementPath = new Vector2(Globals.player.currentPosition.X, 0);
            this.speed = 100;
        }

        public override void Move()
        {

            var directionToMove = _MovementPath - this.currentPosition;
            directionToMove.Normalize();
            this.currentPosition += directionToMove * this.speed * Globals.Time;

        }
    }
}