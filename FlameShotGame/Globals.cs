using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using FlameShotGame.GameObjects;
using Microsoft.Xna.Framework.Input;
using SharpDX.MediaFoundation.DirectX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace FlameShotGame
{
    public class Globals // Might be better to be internal
    {
        private static Globals uniqueInstance = new Globals();

        // attributes

        public static float Time { get; set; }
        public SpriteBatch SpriteBatch { get; set; }
        public GraphicsDeviceManager GraphicsDevice { get; set; }
        public ContentManager Content { get; set; }
        public readonly float defaultEntitySpeed = 40;
        
        public static List<Entity> EntitiesList;
        public static Player player;
        public static List<Bullet> EnemyBulletList;
        public static List<Bullet> PlayerBulletList;

        public static Globals Instance()
        {
            return uniqueInstance;
        }

        public static void Update(GameTime gt)
        {
            Time = (float)gt.ElapsedGameTime.TotalSeconds;
        }

        private Globals() 
        {
            Time = (float) 0;

        }

    }
}
