using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
    public class Globals // Might be better 
    {
        private static Globals uniqueInstance = new Globals();

        // attributes

        public static float Time { get; set; }
        public static SpriteBatch SpriteBatch { get; set; }
        public static GraphicsDevice GraphicsDevice { get; set; }
        
        public static Globals instance()
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
            // SpriteBatch Initialization?
            // GraphicsDevice Initialization?
        }

    }
}
