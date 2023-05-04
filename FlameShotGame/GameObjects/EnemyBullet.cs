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
/*        private Vector2 _Direction;*/
        IMovement movement;

        public EnemyBullet(Texture2D texture, Vector2 pos, int damage, IMovement movement) : base(texture, pos, damage)
        {
/*            _Direction = new Vector2(Globals.player.currentPosition.X, Globals.player.currentPosition.Y) - pos;
            _Direction.Normalize();
            this.speed = 150;
            Debug.WriteLine("Enemy Bullet: " + _Direction.X + ", " + _Direction.Y);*/

            this.movement = movement;
        }

        public override void Move()
        {
            this.currentPosition = this.movement.Move();
        }
    }
}
