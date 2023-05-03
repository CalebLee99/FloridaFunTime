using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FlameShotGame.GameObjects
{
    public class StraightMovement : IMovement
    {
        private int speed { get; set; }
        private Vector2 currentPosition { get; set; }
        private Vector2 _MovementPath;
        public StraightMovement(Vector2 currentPosition, int speed)
        {
            this._MovementPath = new Vector2(Globals.player.currentPosition.X + 14, 0);
            this.currentPosition = new Vector2(currentPosition.X + 14, currentPosition.Y);
            this.speed = speed;
        }
        
        public override Vector2 Move()
        {
            var directionToMove = _MovementPath - this.currentPosition;
            directionToMove.Normalize();
            this.currentPosition += directionToMove * this.speed * Globals.Time;
            return this.currentPosition;
        }
    }
}