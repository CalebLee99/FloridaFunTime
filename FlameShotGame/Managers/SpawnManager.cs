using System;
using System.Text.Json;
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
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
            EntitiesOnScreen.Add(Globals.player.PlayerHealthBar);
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
                        Globals.EnemyBulletList.Add(new EnemyBullet(global.Content.Load<Texture2D>("Sprites/enemybullet"), enemy.currentPosition, -1));
                    }
                }
            }
        }

        public void ReadWave()
        {
            string fileName = "../../../EnemyWaves.JSON";
            string jsonString = File.ReadAllText(fileName);
            Debug.WriteLine("----------------------READING WAVE---------------------------");
            Debug.WriteLine(jsonString);

            var enemyWaves = JsonConvert.DeserializeObject<JToken>(jsonString);

            foreach (var wave in enemyWaves["waves"])
            {
                Debug.WriteLine("Wave: " + wave["id"]);
                foreach (var enemy in wave["enemies"])
                {
                    Debug.WriteLine("\t enemy: " + enemy["type"]);
                    Debug.WriteLine("\t spawnLoc: " + enemy["spawnLoc"]);
                    Debug.WriteLine("\t pathList");
                    foreach (var pos in enemy["pathList"])
                    {
                        Debug.WriteLine("\t" + pos);
                    }
                }
            }
        }

        public void SpawnEntity()
        {
            this.ReadWave();
            /*EntitiesOnScreen.Add(enemyFactory.CreateEnemy("grunt",
                                                                global.Content.Load<Texture2D>("Sprites/enemy"),
                                                                new Vector2(0, 100),
                                                                Globals.player,
                                                                new List<Vector2>(){
                                                                    new Vector2(400, 100),
                                                                    new Vector2(0, 100)
                                                                    }))*/;

            /*            EntitiesOnScreen.Add(enemyFactory.CreateEnemy("alligator",
                                                                            global.Content.Load<Texture2D>("Sprites/alligator"),
                                                                            new Vector2(0, 0),
                                                                            Globals.player,
                                                                            new List<Vector2>(){
                                                                                new Vector2(100, 100),
                                                                                new Vector2(400, 100),
                                                                                new Vector2(400, 400),
                                                                                new Vector2(100, 400)
                                                                                }));*/
            EntitiesOnScreen.Add(enemyFactory.CreateEnemy("alligator", "chase", 85, "",
                                                                global.Content.Load<Texture2D>("Sprites/alligator"),
                                                                new Vector2(0, 0)));
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

        public void UpdatePlayerHealthBar()
        {
            if (Globals.player._currentHealth == 5)
            {
                Globals.player.PlayerHealthBar = new HealthBar(global.Content.Load<Texture2D>("Sprites/health_5"), new Vector2(0, 0));
            }
            if (Globals.player._currentHealth == 4)
            {
                Globals.player.PlayerHealthBar = new HealthBar(global.Content.Load<Texture2D>("Sprites/health_4"), new Vector2(0, 0));
            }
            if (Globals.player._currentHealth == 3)
            {
                Globals.player.PlayerHealthBar = new HealthBar(global.Content.Load<Texture2D>("Sprites/health_3"), new Vector2(0, 0));
            }
            if (Globals.player._currentHealth == 2)
            {
                Globals.player.PlayerHealthBar = new HealthBar(global.Content.Load<Texture2D>("Sprites/health_2"), new Vector2(0, 0));
            }
            if (Globals.player._currentHealth == 1)
            {
                Globals.player.PlayerHealthBar = new HealthBar(global.Content.Load<Texture2D>("Sprites/health_1"), new Vector2(0, 0));
            }
        }
    }
}
