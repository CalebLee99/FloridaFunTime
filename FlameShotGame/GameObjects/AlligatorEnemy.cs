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
        public Player FollowTarget {get; set;}

        public AlligatorEnemy(Texture2D texture, Vector2 pos, Player target) : base(texture, pos)
        {
            this.FollowTarget = target;
            this.speed = 85;
        }

        public override void Move()
        {
            if (FollowTarget != null)
            {
                var directionToMove = FollowTarget.currentPosition - this.currentPosition;

                if (directionToMove.Length() > 4)
                {
                    directionToMove.Normalize();
                    this.currentPosition += directionToMove * this.speed * Globals.Time;
                }
            }
        }
    }
}
