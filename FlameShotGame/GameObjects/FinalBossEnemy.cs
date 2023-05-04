using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlameShotGame.Creational;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct2D1;

namespace FlameShotGame.GameObjects
{
    internal class FinalBossEnemy : Entity
    {
        Globals globals = Globals.Instance();

        IMovement movement;
        int spawnTime;
        int timeAlive;
        bool firstPhase;
        bool secondPhase;
        bool spawnedGrunts = false;

        public float ShootCoolDownValue;
        public float ShootAccumulator;

        public float SpawnCoolDownValue;
        public float SpawnAccumulator;

        private EnemyFactory enemyFactory = new EnemyFactory();

        public FinalBossEnemy(Texture2D texture, Vector2 pos, IMovement movementType) : base(texture, pos)
        {
            this.movement = movementType;
            this.Health = 75;
            this.spawnTime = (int)Globals.TotalElapsedTime;
            this.timeAlive = 0;
            this.firstPhase = true;
            this.secondPhase = true;

            this.ShootAccumulator = 0;
            this.ShootCoolDownValue = (float)0.8;

            this.SpawnAccumulator = 0;
            this.SpawnCoolDownValue = 3;
        }

        public override void Move()
        {
            timeAlive = (int)Globals.TotalElapsedTime - spawnTime;
            if (timeAlive > 15 && firstPhase)
            {
                firstPhase = false;
                // Make new movement
                IMovement movement = new ChaseMovement(this.currentPosition, 90);
                this.movement = movement;
            }
            if (timeAlive > 30 && secondPhase)
            {
                secondPhase = false;
                IMovement movement = new PatrolMovement(this.currentPosition, new List<Vector2>() { new Vector2(0, 0), new Vector2(Globals.ScreenWidth - 100, 0), new Vector2(Globals.ScreenWidth - 100, Globals.ScreenHeight - 200), new Vector2(0, Globals.ScreenHeight - 200) }, 200);
                this.movement = movement;
            }
   
            this.currentPosition = this.movement.Move();
        }
        public void HasShotUpdate()
        {
            this.ShootAccumulator -= this.ShootCoolDownValue;
        }

        public void HasSpawnUpdate()
        {
            this.SpawnAccumulator -= this.SpawnCoolDownValue;
        }

        public override void Update()
        {
            base.Update();
            this.ShootAccumulator += Globals.Time;
            this.SpawnAccumulator += Globals.Time;
        }

        public void Fire()
        {
            Random rand = new Random();

            if (this.ShootAccumulator >= this.ShootCoolDownValue)
            {
                this.HasShotUpdate(); // Now HasShot is True
                Debug.WriteLine("!!!! SHOOT ACCUMUL !!!" + this.ShootAccumulator);

                int speed = 350;

                if (timeAlive > 30)
                {
                    speed = 500;
                }

                IMovement diagonalMovement = new DiagonalMovement(this.currentPosition, Globals.player.currentPosition, rand.Next(-5, 5), speed);
                Globals.EnemyBulletList.Add(new EnemyBullet(globals.Content.Load<Texture2D>("Sprites/enemybullet"), this.currentPosition, -1, diagonalMovement));

                if (timeAlive > 15)
                {
                    // shoot another bullet
                    IMovement circleMovement = new CircleMovement(this.currentPosition, 50, 20);
                    Globals.EnemyBulletList.Add(new EnemyBullet(globals.Content.Load<Texture2D>("Sprites/enemybullet"), this.currentPosition, -1, circleMovement));
                }

                if (spawnedGrunts == false)
                {
                    for (int i = 0; i < 9; i++)
                    {
                        IMovement movement = new PatrolMovement(new Vector2(this.currentPosition.X + ((50 * i) - 200), this.currentPosition.Y + 40),
                            new List<Vector2>() { new Vector2(this.currentPosition.X + 200, this.currentPosition.Y + 40), new Vector2(this.currentPosition.X, this.currentPosition.Y) }, 50);
                        Globals.EntitiesList.Add(new GruntEnemy(globals.Content.Load<Texture2D>("Sprites/grunt"), new Vector2(this.currentPosition.X + ((50 * i) - 200), this.currentPosition.Y + 40), movement));
                        /*Globals.EntitiesList.Add(enemyFactory.CreateEnemy("enemy", "", 80, "",
                                        globals.Content.Load<Texture2D>("Sprites/grunt"), new Vector2(this.currentPosition.X + ((10 * i) - 20), this.currentPosition.Y + 40)));*/

                    }
                    spawnedGrunts = true;
                }
                // spawn grunts who act as shield
                

            }
            if (this.SpawnAccumulator >= this.SpawnCoolDownValue && timeAlive > 15) // phase 2 spawning
            {
                this.HasSpawnUpdate();

                // spawn aligators
                Globals.EntitiesList.Add(enemyFactory.CreateEnemy("alligator", "chase", 160, "",
                                   globals.Content.Load<Texture2D>("Sprites/alligator"), this.currentPosition));
            }
        }
    }
}
