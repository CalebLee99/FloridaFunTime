// This manager is used to gather information on collision detection.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using FlameShotGame.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using FlameShotGame.GameObjects;
using FlameShotGame.Creational;
using System.Diagnostics;

namespace FlameShotGame.Managers
{
    public class CollisionManager
    {
        private static CollisionManager uniqueInstance = new CollisionManager();
        private static SpawnManager spawnManager = SpawnManager.Instance();
        Globals global = Globals.Instance();

        // Attributes

        public static CollisionManager Instance()
        {
            return uniqueInstance;
        }

        public void Update()
        {
            // Update hitboxes of all entites

            // Player calls Update in Move function

            // Enemies list
            foreach (var entity in Globals.EntitiesList.ToList())
            {
                entity.Update();
            }

            // Player Bullets list
            foreach (var bullet in Globals.PlayerBulletList.ToList())
            {
                bullet.Update();
                //Debug.WriteLine("Bullet Position in int: " + (int)bullet.currentPosition.X + ", " + (int)bullet.currentPosition.Y);

                if (((int)bullet.currentPosition.Y) <= 2)
                {
                    spawnManager.DespawnPlayerBullet(bullet);
                }
            }

            // 
            foreach (var bullet in Globals.EnemyBulletList.ToList())
            {
                bullet.Update();

                // If bullet is off the screen. Despawn the bullet.
                /*int w = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
                int h = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;*/

                if (bullet.currentPosition.Y <= 2 || bullet.currentPosition.X <= 2 
                    || bullet.currentPosition.X >= Globals.ScreenWidth 
                    || bullet.currentPosition.Y >= Globals.ScreenHeight)
                {
                    spawnManager.DespawnEnemyBullet(bullet);
                }
            }
            
            // ---------------------------
            // checking cases for collison

            // Case 1: PlayerBullet hits Enemy
            foreach (var entity in Globals.EntitiesList.ToList())
            {
                foreach (var bullet in Globals.PlayerBulletList.ToList())
                {
                    if (bullet.Hitbox.Intersects(entity.Hitbox))
                    {
                        
                        entity.Health -= bullet.GetDamage();
                        if (entity.Health <= 0)
                        {
                            spawnManager.DespawnEntity(entity);
                            Random HeartDropRate = new Random();
                            int heartChance = HeartDropRate.Next(0, 40);
                            if (heartChance <= 10)
                            {
                                // Create new HeartPowerUp
                                Globals.EntitiesList.Add(new HeartPowerUp(global.Content.Load<Texture2D>("Sprites/HeartPowerUp"), bullet.currentPosition));
                            }
                        }

                        Debug.WriteLine("!!!! Take That !!!!!");

                        

                        spawnManager.DespawnPlayerBullet(bullet);

                    }
                }
            }

            // Case 2: EnemyBullet hits Player
            if (!Globals.player.Invincible)
            {
                // Case 2: EnemyBullet hits Player
                foreach (var bullet in Globals.EnemyBulletList.ToList())
                {
                    if (bullet.Hitbox.Intersects(Globals.player.Hitbox))
                    {
                        Debug.WriteLine("!!!!! POW POW !!!!!");
                        // Despawn Enemy Bullet
                        spawnManager.DespawnEnemyBullet(bullet);
                        // Update Health
                        //Globals.player.UpdateHealth(bullet.GetDamage());
                        Globals.player.PlayerTakesDamage(bullet.GetDamage());
                        spawnManager.UpdatePlayerHealthBar();
                    }
                }

                // Case 3: Enemy or Powerup hits Player
                foreach (var entity in Globals.EntitiesList.ToList())
                {
                    if (entity.Hitbox.Intersects(Globals.player.Hitbox))
                    {
                        if (entity.GetType() == typeof(HeartPowerUp) && Globals.player.playerDamaged == true)
                        {
                            Debug.WriteLine("!!!!! YEAH BABY !!!!!");

                            Globals.player.UpdateHealth(+1);
                            spawnManager.DespawnEntity(entity);
                            spawnManager.UpdatePlayerHealthBar();
                        } 
                        else if (entity.GetType() != typeof(HeartPowerUp))
                        {
                            Debug.WriteLine("!!!!! Ouch !!!!!");

                            Globals.player.PlayerTakesDamage(-1);
                            spawnManager.UpdatePlayerHealthBar();
                        }
                        
                    }
                }
            }
        }
    }
}