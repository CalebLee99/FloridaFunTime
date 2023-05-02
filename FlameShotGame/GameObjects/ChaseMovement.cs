using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FlameShotGame.GameObjects
{
    internal class ChaseMovement : IMovement
    {
        private Vector2 currentPosition { get; set; }
        
        private Player FollowTarget = Globals.player;

        public ChaseMovement(Vector2 pos, int speed)
        {
            this.currentPosition = pos;
            this.EnemySpeed = speed;
        }

        public override Vector2 Move()
        {
            Debug.WriteLine("Chase current position:");
            Debug.WriteLine(this.currentPosition);
            
            if (FollowTarget != null)
            {
                var directionToMove = FollowTarget.currentPosition - this.currentPosition;

                if (directionToMove.Length() > 4)
                {
                    directionToMove.Normalize();
                    this.currentPosition += directionToMove * this.EnemySpeed * Globals.Time;
                }
            }
            return this.currentPosition;    
        }
    }
}
