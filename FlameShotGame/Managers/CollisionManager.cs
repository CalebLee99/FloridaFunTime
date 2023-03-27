﻿// This manager is used to gather information on collision detection.
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
            }

            // 
            foreach (var bullet in Globals.EnemyBulletList.ToList())
            {
                bullet.Update();
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
                        Debug.WriteLine("!!!! PlayerBullet hits Enemy !!!!!");
                    }
                }
            }

            // Case 2: EnemyBullet hits Player
            foreach (var bullet in Globals.EnemyBulletList.ToList())
            {
                if (bullet.Hitbox.Intersects(Globals.player.Hitbox))
                {
                    Debug.WriteLine("!!!!! EnemyBullet hits Player !!!!!");
                }
            }
            // Case 3: Enemy hits Player
            foreach (var enemy in Globals.EntitiesList.ToList())
            {
                if (enemy.Hitbox.Intersects(Globals.player.Hitbox))
                {
                    Debug.WriteLine("!!!!! Enemy hits Player !!!!!");
                }
            }
        }
    }
}