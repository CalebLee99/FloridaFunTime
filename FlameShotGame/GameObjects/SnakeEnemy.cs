using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FlameShotGame.GameObjects

{
    public class SnakeEnemy : Entity
    {
        IMovement movement;

        public SnakeEnemy(Texture2D texture, Vector2 pos, IMovement movementType) : base(texture, pos)
        {
            this.movement = movementType;
        }

        public override void Move()
        {
            this.currentPosition = this.movement.Move();
        }
    }
}
