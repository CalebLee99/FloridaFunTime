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
using FlameShotGame.GameObjects;

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

            // player
            Globals.player.Draw();
            Globals.player.PlayerHealthBar.Draw();
            
            // actor entities
            foreach(var entity in Globals.EntitiesList.ToList())
            {
                entity.Move();
                entity.Draw();
            }
            
            // player bullet entities
            foreach(var bullet in Globals.PlayerBulletList.ToList())
            {
                UpdateBullet(bullet);
            }

            // enemy bullet entities
            foreach(var bullet in Globals.EnemyBulletList.ToList())
            {
                UpdateBullet(bullet);
            }

            global.SpriteBatch.End();
        }

        private void UpdateBullet(Bullet bullet)
        {
            bullet.Move();
            bullet.Draw();

        }

        protected DrawManager()
        {
        
        }
    }
}