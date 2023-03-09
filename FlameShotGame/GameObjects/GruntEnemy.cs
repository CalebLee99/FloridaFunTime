using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FlameShotGame.GameObjects
{
    // Basic enemy that will follow predefined path.
    public class GruntEnemy : Entity
    {
        // TODO: Stat data members (e.g. hit points)

        // Movement data members
        private readonly List<Vector2> _MovementPath;
        private int _currentMovementPath;
        Globals globals = Globals.instance();

        public GruntEnemy(Texture2D texture, Vector2 pos) : base(texture, pos)
        {
            // TODO: Stat data members (e.g. hit points)
            _currentMovementPath = 0;   
        }

        public GruntEnemy(Texture2D texture, Vector2 pos, List<Vector2> movePath) : base(texture, pos)
        {
            // TODO: Stat data members (e.g. hit points)
            this._MovementPath = movePath;
            _currentMovementPath = 0;   
        }

        // Add location for Grunt Enemy to move to.
        public void AddPosition(Vector2 pos)
        {
            _MovementPath.Add(pos);
        }

        public override void Move()
        {
            if (_MovementPath.Count == 0)
            {
                return;
            }

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
        }

        public override void Update()
        {
            return;
        }
    }
}
