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
using System.Diagnostics;

namespace FlameShotGame.Managers
{

    public class DrawManager 
    {
        private static DrawManager uniqueInstance = new DrawManager();
        SpawnManager spawnManager = SpawnManager.Instance();
        
        Globals global = Globals.Instance();
        
        public static DrawManager Instance()
        {
            return uniqueInstance;
        }
        public void Update()
        {
            global.SpriteBatch.Begin();
            
            // actor entities
            foreach(var entity in Globals.EntitiesList.ToList())
            {
                entity.Move();
                entity.Draw();
            }
            
            // player bullet entities
            foreach(var bullet in Globals.PlayerBulletList.ToList())
            {
                bullet.Move();
                bullet.Draw();
                Debug.WriteLine("Bullet Position in int: " + (int) bullet.currentPosition.X + ", " + (int) bullet.currentPosition.Y);
                if (((int) bullet.currentPosition.Y) == 0)
                {
                    Debug.WriteLine("bullet should be deleted.");
                    spawnManager.DespawnPlayerBullet(bullet);
                }
            }


            global.SpriteBatch.End();
        }
        protected DrawManager()
        {
        
        }
    }
}