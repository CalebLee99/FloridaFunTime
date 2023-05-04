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
    // Basic enemy that will follow predefined path.
    public class GruntEnemy : Entity
    {
        // TODO: Stat data members (e.g. hit points)

        // 

        // Movement data members
        IMovement movement;

/*        private readonly List<Vector2> _MovementPath;
        private int _currentMovementPath;*/
        Globals globals = Globals.Instance();

        public bool HasShot;
        public float ShootCoolDownValue;
        public float ShootAccumulator;

/*        public GruntEnemy(Texture2D texture, Vector2 pos) : base(texture, pos)
        {
            // TODO: Stat data members (e.g. hit points)
            _currentMovementPath = 0;   
        }*/

        public GruntEnemy(Texture2D texture, Vector2 pos, IMovement movement) : base(texture, pos)
        {
            // TODO: Stat data members (e.g. hit points)
            /*this._MovementPath = movePath;
            _currentMovementPath = 0;*/

            this.movement = movement;
            this.ShootCoolDownValue = (float) 2;
            this.ShootAccumulator = 0;
        }
        /*
                // Add location for Grunt Enemy to move to.
                public void AddPosition(Vector2 pos)
                {
                    _MovementPath.Add(pos);
                }*/

        public override void Move()
        {
            this.currentPosition = this.movement.Move();
        }

        public void HasShotUpdate()
        {
            this.ShootAccumulator -= this.ShootCoolDownValue;
        }


        public override void Update()
        {
            base.Update();
            this.ShootAccumulator += Globals.Time;
        }

        public void Fire()
        {
            Random rand = new Random();

            if (this.ShootAccumulator >= this.ShootCoolDownValue)
            {
                this.HasShotUpdate(); // Now HasShot is True
                Debug.WriteLine("!!!! SHOOT ACCUMUL !!!" + this.ShootAccumulator);

                IMovement diagonalMovement = new DiagonalMovement(this.currentPosition, Globals.player.currentPosition, rand.Next(-5, 5), 350);
                Globals.EnemyBulletList.Add(new EnemyBullet(globals.Content.Load<Texture2D>("Sprites/enemybullet"), this.currentPosition, -1, diagonalMovement));
            }
        }
    }
}
