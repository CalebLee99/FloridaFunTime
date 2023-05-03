using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FlameShotGame.GameObjects
{
    public class MidbossEnemy : Entity
    {
        IMovement movement;
        public MidbossEnemy(Texture2D texture, Vector2 pos, IMovement movementType) : base(texture, pos)
        {
            this.movement = movementType;
        }
        public override void Move()
        {
            throw new NotImplementedException();
        }

        public override void Update()
        {
            this.currentPosition = this.movement.Move();
        }
    }
}
