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

using FlameShotGame.Creational;

namespace FlameShotGame.GameObjects
{
    public class MidbossEnemy : Entity
    {
        Globals globals = Globals.Instance();

        IMovement movement;
        int spawnTime;
        int timeAlive;
        private int phaseTwoTime = 30;
        bool firstPhase;

 /*       public bool HasShot;*/
        public float ShootCoolDownValue;
        public float ShootAccumulator;

  /*      public bool HasSpawned;*/
        public float SpawnCoolDownValue;
        public float SpawnAccumulator;

        private EnemyFactory enemyFactory = new EnemyFactory();


        public MidbossEnemy(Texture2D texture, Vector2 pos, IMovement movementType) : base(texture, pos)
        {
            this.movement = movementType;
            this.Health = 100;
            this.spawnTime = (int) Globals.TotalElapsedTime;
            this.timeAlive = 0;
            this.firstPhase = true;

            this.ShootAccumulator = 0;
            this.ShootCoolDownValue = (float) 0.5;

            this.SpawnAccumulator = 0;
            this.SpawnCoolDownValue = 3;
        }
        public override void Move()
        {
            timeAlive = (int) Globals.TotalElapsedTime - spawnTime;
            if (timeAlive > 15 && firstPhase) 
            {
                firstPhase = false;
                // Make new movement
                IMovement movement = new ChaseMovement(this.currentPosition, 90);
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

                IMovement diagonalMovement = new DiagonalMovement(this.currentPosition, Globals.player.currentPosition, rand.Next(-5, 5), 350);
                Globals.EnemyBulletList.Add(new EnemyBullet(globals.Content.Load<Texture2D>("Sprites/enemybullet"), this.currentPosition, -1, diagonalMovement));

                if (timeAlive > 15)
                {
                    // shoot another bullet
                    IMovement circleMovement = new CircleMovement(this.currentPosition, 50, 20);
                    Globals.EnemyBulletList.Add(new EnemyBullet(globals.Content.Load<Texture2D>("Sprites/enemybullet"), this.currentPosition, -1, circleMovement));
                }

                /*if (timeAlive > 25)
                {
                    List<Vector2> PointsToShoot = new List<Vector2>();
                    for (int i = 0; i < 10; i++)
                    {
                        Vector2 newPoint = new Vector2();
                        newPoint.X = currentPosition.X * i;
                        newPoint.Y = currentPosition.Y * i;

                    }

                }*/
            }

            if (this.SpawnAccumulator >= this.SpawnCoolDownValue && timeAlive > 15)
            {
                this.HasSpawnUpdate();

                // spawn aligators
                Globals.EntitiesList.Add(enemyFactory.CreateEnemy("alligator", "chase", 160, "",
                                   globals.Content.Load<Texture2D>("Sprites/alligator"), this.currentPosition));
            }
        }

/*        public override void Update()
        {
            
            this.currentPosition = this.movement.Move();
        }*/
    }
}
