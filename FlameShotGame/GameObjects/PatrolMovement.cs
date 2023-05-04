using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FlameShotGame.GameObjects
{
    internal class PatrolMovement : IMovement
    {
        private readonly List<Vector2> _MovementPath;
        private int _currentMovementPath;
        private Vector2 currentPosition { get; set; }

        public PatrolMovement(Vector2 currentPosition, List<Vector2> movementPath, int currentMovementPath)
        {
            _MovementPath = movementPath;
            _currentMovementPath = currentMovementPath;
            this.currentPosition = currentPosition;
        }


        // Add location for Grunt Enemy to move to.
        public void AddPosition(Vector2 pos)
        {
            _MovementPath.Add(pos);
        }


        public override Vector2 Move()
        {
/*            if (_MovementPath.Count == 0)
            {
                return null;
            }*/

            var directionToMove = _MovementPath[_currentMovementPath] - this.currentPosition;

            if (directionToMove.Length() > 4)
            {
                directionToMove.Normalize();
                this.currentPosition += directionToMove * this.speed * Globals.Time;
            }
            else
            {
                _currentMovementPath = (_currentMovementPath + 1) % _MovementPath.Count;
            }

            return this.currentPosition;
        }
    }
}
