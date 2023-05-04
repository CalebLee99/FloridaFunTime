using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FlameShotGame.GameObjects
{
    public class AlligatorEnemy : Entity
    {
        // TODO: Stat data members (e.g. hit points)

        // Movement data members
        /*public Player FollowTarget {get; set;}*/

        IMovement movement;


        public AlligatorEnemy(Texture2D texture, Vector2 pos, IMovement movementType) : base(texture, pos)
        {
            this.movement = movementType;
            this.Health = 3;
        }

        public override void Move()
        {
            this.currentPosition = this.movement.Move();
        }
    }
}
