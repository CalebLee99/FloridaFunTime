using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using FlameShotGame.GameObjects;
using FlameShotGame.Creational;
using System.Diagnostics;

// This manager is used when ever an entity needs to be spawned.
namespace FlameShotGame.Managers
{
    public class SpawnManager
    {
        private static SpawnManager uniqueInstance = new SpawnManager();
        Globals global = Globals.Instance();
        private EnemyFactory enemyFactory;

        // Attributes
        private static List<Entity> EntitiesOnScreen; // This should be pass by ref per entity... Test this.
        public static Player player;
        public static List<Bullet> EnemyBulletList;
        public static List<Bullet> PlayerBulletList;

        public static SpawnManager Instance()
        {
            return uniqueInstance;
        }

        public void Update()
        {
            Globals.EntitiesList = EntitiesOnScreen;

            //Globals.player = player; GameManager will set player

            Globals.EnemyBulletList = EnemyBulletList;

            Globals.PlayerBulletList = PlayerBulletList;

            EnemiesSpawnAndShootBullets();
        }

        protected SpawnManager()
        {

            EntitiesOnScreen = new List<Entity>();
            EnemyBulletList = new List<Bullet>();
            PlayerBulletList = new List<Bullet>();

            this.enemyFactory = new EnemyFactory();
        }

        public void SpawnPlayer()
        {
            EntitiesOnScreen.Add(Globals.player);
        }

        public void EnemiesSpawnAndShootBullets()
        {
            foreach (var enemy in EntitiesOnScreen)
            {
                if(enemy.GetType() == typeof(GruntEnemy))
                {
                    var gruntEnemy = enemy as GruntEnemy;   
                    if (gruntEnemy.ShootAccumulator >= gruntEnemy.ShootCoolDownValue)
                    {
                        gruntEnemy.HasShotUpdate(); // Now HasShot is True
                        Debug.WriteLine("!!!! SHOOT ACCUMUL !!!" + gruntEnemy.ShootAccumulator);
                        Globals.EnemyBulletList.Add(new EnemyBullet(global.Content.Load<Texture2D>("Sprites/enemybullet"), enemy.currentPosition, 25));
                    }
                }
            }
        }

        public void SpawnEntity()
        {
            EntitiesOnScreen.Add(enemyFactory.CreateEnemy("grunt",
                                                                global.Content.Load<Texture2D>("Sprites/enemy"),
                                                                new Vector2(0, 100),
                                                                Globals.player,
                                                                new List<Vector2>(){
                                                                    new Vector2(400, 100),
                                                                    new Vector2(0, 100)
                                                                    }));

            EntitiesOnScreen.Add(enemyFactory.CreateEnemy("alligator",
                                                                global.Content.Load<Texture2D>("Sprites/alligator"),
                                                                new Vector2(0, 0),
                                                                Globals.player,
                                                                new List<Vector2>(){
                                                                    new Vector2(100, 100),
                                                                    new Vector2(400, 100),
                                                                    new Vector2(400, 400),
                                                                    new Vector2(100, 400)
                                                                    }));
        }

        public void ShootPlayerBullet()
        {
            Globals.PlayerBulletList.Add(new PlayerBullet(global.Content.Load<Texture2D>("Sprites/playerbullet"), Globals.player.currentPosition, 25));
        }

        public void DespawnEntity(Entity en)
        {
            EntitiesOnScreen.Remove(en);
        }

        public void DespawnPlayerBullet(Bullet b)
        {
            PlayerBulletList.Remove(b);
        }

        public void DespawnEnemyBullet(Bullet b)
        {
            EnemyBulletList.Remove(b);
        }
    }

}
