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
using System.Collections;

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
        private Dictionary<int, JSONEnemy> waveDictonary;
        private List<JSONEnemy> waveList;

        private int currentWaveTime;

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
            Debug.WriteLine(Globals.TotalElapsedTime);
            AddEntityToScreen();

            //prniting list
/*            foreach (JSONEnemy e in this.waveList)
            {
                Debug.Write("[");
                Debug.Write(e.enemyName + ", ");
                Debug.WriteLine("}");
            }*/

            if (Globals.EntitiesList.Count == 0 && waveList.Count != 0 && waveList[0].enemyName == "despawn")
            {
                
                Debug.WriteLine("*******All Enemies Dead*******");
                Dictionary<int, JSONEnemy> temp = new Dictionary<int, JSONEnemy>();
                var keys = new List<int>(waveDictonary.Keys);
                int timeToSubtract = waveList[0].spawnTime - (int)Globals.TotalElapsedTime;

 

                foreach (int key in keys)
                {
                    waveDictonary[key].spawnTime = waveDictonary[key].spawnTime - timeToSubtract + 1;
                    temp.Add((waveDictonary[key].spawnTime), waveDictonary[key]);
                }
                foreach(JSONEnemy e in waveList)
                {
                    Debug.WriteLine("SPAWN TIME IN WAVE LIST: " + e.spawnTime);
                    /*e.spawnTime = e.spawnTime - timeToSubtract;*/
                }

                this.waveDictonary.Remove(waveList[0].spawnTime);
                this.waveList.RemoveAt(0);

                this.waveDictonary = temp;

            }

        }

        private void AddEntityToScreen()
        {
            JSONEnemy currentEnemy;
            if (this.waveDictonary.TryGetValue((int) Globals.TotalElapsedTime, out currentEnemy))
            {
                this.SpawnEntity(currentEnemy);

                // remove because already spawned.
                try
                {
                    this.waveDictonary.Remove((int)Globals.TotalElapsedTime);
                }
                catch (Exception e)
                {
                    Debug.WriteLine("NULL EXCEPTION: WAVE DICTIONARY REMOVE FAILED BECAUSE DNE");
                }
                
                if (this.waveList.Count() > 0)
                {
                    this.waveList.RemoveAt(0);
                }
            }
        }

        protected SpawnManager()
        {

            EntitiesOnScreen = new List<Entity>();
            EnemyBulletList = new List<Bullet>();
            PlayerBulletList = new List<Bullet>();

            this.enemyFactory = new EnemyFactory();

            waveDictonary = new Dictionary<int, JSONEnemy>();
            waveList = new List<JSONEnemy>();
            this.ReadWave();
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
                    gruntEnemy.Fire();

/*                    Random rand = new Random();
                    
                        if (gruntEnemy.ShootAccumulator >= gruntEnemy.ShootCoolDownValue)
                        {
                            gruntEnemy.HasShotUpdate(); // Now HasShot is True
                            Debug.WriteLine("!!!! SHOOT ACCUMUL !!!" + gruntEnemy.ShootAccumulator);

                            IMovement diagonalMovement = new DiagonalMovement(enemy.currentPosition, Globals.player.currentPosition, rand.Next(-5, 5), 350);
                            Globals.EnemyBulletList.Add(new EnemyBullet(global.Content.Load<Texture2D>("Sprites/enemybullet"), enemy.currentPosition, -1, diagonalMovement));
                        }*/
                }
            }
        }

        public void ReadWave()
        {
            string fileName = "../../../EnemyWaves.JSON";
            string jsonString = File.ReadAllText(fileName);
            Debug.WriteLine("----------------------READING WAVE---------------------------");
 /*           Debug.WriteLine(jsonString);*/

            var enemyWaves = JsonConvert.DeserializeObject<JToken>(jsonString);
                foreach (var enemy in enemyWaves["enemies"])
                {

                    Debug.WriteLine("\t enemy: " + enemy["enemyType"]);
                    string enemyType = (string)enemy["enemyType"];

                    Debug.WriteLine("\t movementType: " + enemy["movementType"]);
                    string movementType = (string)enemy["movementType"];

                    Debug.WriteLine("\t data: " + enemy["data"]);
                    string data = (string)enemy["data"];

                    Debug.WriteLine("\t speed: " + enemy["speed"]);
                    int speed = (int)enemy["speed"];

                    Debug.WriteLine("\t spawnTime: " + enemy["spawnTime"]);
                    int spawnTime = (int)enemy["spawnTime"];

                    Debug.WriteLine("\t spawnLocX: " + enemy["spawnLocX"]);
                    int spawnLocX = (int)enemy["spawnLocX"];

                    Debug.WriteLine("\t spawnLocY: " + enemy["spawnLocY"]);
                    int spawnLocY = (int)enemy["spawnLocY"];

                    JSONEnemy newJSONEnemy = new JSONEnemy(enemyType, movementType, data, spawnTime, speed, spawnLocX, spawnLocY);
                
                    this.waveDictonary[spawnTime] = newJSONEnemy;
                    this.waveList.Add(newJSONEnemy);
                }

        }

        private void SpawnEntity(JSONEnemy enemy)
        {
            // clear enemies at end of wave or another arbitrary time
            if (enemy.enemyName == "despawn")
            {
                EntitiesOnScreen.Clear();
            }
            else
            {
                string spritePath = "Sprites/" + enemy.enemyName;
                EntitiesOnScreen.Add(enemyFactory.CreateEnemy(enemy.enemyName, enemy.movementType, enemy.speed, enemy.data,
                                       global.Content.Load<Texture2D>(spritePath), new Vector2(enemy.spawnLocX, enemy.spawnLocY)));
            }
        }

        public void ShootPlayerBullet()
        {
            Random rand = new Random();
            int random = rand.Next(-50, 50);
            /*IMovement straightMovement = new StraightMovement(Globals.player.currentPosition, 350);*/
            /*IMovement straightMovement = new CircleMovement(Globals.player.currentPosition, 0.10f, 20)*/
            IMovement straightMovement = new DiagonalMovement(Globals.player.currentPosition, new Vector2(Globals.player.currentPosition.X + 14, 0), random, 350); 
            Globals.PlayerBulletList.Add(new PlayerBullet(global.Content.Load<Texture2D>("Sprites/playerbullet"), Globals.player.currentPosition, 1, straightMovement));
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
