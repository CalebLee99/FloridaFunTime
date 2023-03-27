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
        public PlayerBullet(Texture2D texture, Vector2 pos, int damage) : base(texture, new Vector2(pos.X + 14, pos.Y), damage)
        {
            // start from player position and go towards top of screen
            _MovementPath = new Vector2(Globals.player.currentPosition.X + 14, 0);
            this.speed = 350;
        }

        public override void Move()
        {

            var directionToMove = _MovementPath - this.currentPosition;
            directionToMove.Normalize();
            this.currentPosition += directionToMove * this.speed * Globals.Time;

        }
    }
}