﻿using System;
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

        public static SpawnManager Instance()
        {
            return uniqueInstance;
        }

        public void Update()
        {
            Globals.EntitiesList = EntitiesOnScreen;
        }

        protected SpawnManager()
        {
            EntitiesOnScreen = new List<Entity>();
            this.enemyFactory = new EnemyFactory();
        }

        public void SpawnPlayer(Player pl)
        {
            EntitiesOnScreen.Add(pl);
        }

        public void SpawnEntity(Player player)
        {
            EntitiesOnScreen.Add(enemyFactory.CreateEnemy("grunt",
                                                                global.Content.Load<Texture2D>("Sprites/enemy"),
                                                                new Vector2(200, 0),
                                                                player,
                                                                new List<Vector2>(){new Vector2(50, 0)}));

            EntitiesOnScreen.Add(enemyFactory.CreateEnemy("alligator",
                                                                global.Content.Load<Texture2D>("Sprites/alligator"),
                                                                new Vector2(0, 0),
                                                                player,
                                                                new List<Vector2>(){
                                                                    new Vector2(100, 100),
                                                                    new Vector2(400, 100),
                                                                    new Vector2(400, 400),
                                                                    new Vector2(100, 400)
                                                                    }));
        }

        public void DespawnEntity(Entity en)
        {
            EntitiesOnScreen.Remove(en);
        }
    }

}
