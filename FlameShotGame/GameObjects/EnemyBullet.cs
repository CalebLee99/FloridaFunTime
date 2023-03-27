using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace FlameShotGame.GameObjects
{
    internal class EnemyBullet : Bullet
    {
        Globals global = Globals.Instance();
        private Vector2 _MovementPath;
        public EnemyBullet(Texture2D texture, Vector2 pos, int damage) : base(texture, pos, damage)
        {
            if (Globals.player.currentPosition.X >= Globals.ScreenWidth / 2)
            {
                _MovementPath = new Vector2(Globals.player.currentPosition.X, Globals.player.currentPosition.Y) * 2;
                this.speed = 150;
                Debug.WriteLine("Enemy Bullet: " + _MovementPath.X + ", " + _MovementPath.Y);
            }
            
        }

        public override void Move()
        {
            var directionToMove = _MovementPath - this.currentPosition;
            directionToMove.Normalize();
            this.currentPosition += directionToMove * this.speed * Globals.Time;
        }
    }
}
