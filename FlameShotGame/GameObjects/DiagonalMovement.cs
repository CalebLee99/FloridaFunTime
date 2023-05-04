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
    internal class DiagonalMovement : IMovement
    {
        private int speed { get; set; }
        private Vector2 currentPosition { get; set; }
        /*private Vector2 _MovementPath;*/
        private Vector2 _Direction;

        public DiagonalMovement(Vector2 currentPosition, Vector2 Target,  int deviation, int speed)
        {
            this.currentPosition = new Vector2(currentPosition.X + 14, currentPosition.Y);
            _Direction = new Vector2(Target.X + deviation, Target.Y + deviation) - currentPosition;
            _Direction.Normalize();
            this.speed = speed;
            Debug.WriteLine("Enemy Bullet: " + _Direction.X + ", " + _Direction.Y);

            /*            this._MovementPath = new Vector2(Target.X + deviation, Target.Y + deviation);
                        this.currentPosition = new Vector2(currentPosition.X + 14, currentPosition.Y);
                        this.speed = speed;*/
        }

        public override Vector2 Move()
        {
            this.currentPosition += _Direction * this.speed * Globals.Time;
            return this.currentPosition;

            /*            var directionToMove = _MovementPath - this.currentPosition;
                        directionToMove.Normalize();
                        this.currentPosition += directionToMove * this.speed * Globals.Time;
                        return this.currentPosition;*/
        }
    }
}
