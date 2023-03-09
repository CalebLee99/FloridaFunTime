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

namespace FlameShotGame.Managers
{

    public class DrawManager : GameManager
    {
        private static DrawManager uniqueInstance = new DrawManager();
        Globals global = Globals.Instance();
        
        public static new DrawManager Instance()
        {
            return uniqueInstance;
        }
        public override void Update()
        {
            global.SpriteBatch.Begin();
            foreach(var entity in Globals.EntitiesList)
            {
                entity.Draw();
            }
            global.SpriteBatch.End();
        }
        protected DrawManager()
        {
        
        }
    }
}