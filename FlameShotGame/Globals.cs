using Microsoft.Xna.Framework.Graphics;
using SharpDX.MediaFoundation.DirectX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FlameShotGame
{
    public class Globals // might be better to make internal
    {
        private static Globals uniqueInstance = new Globals();

        // attributes
        private float m_Time;
        private SpriteBatch m_SpriteBatch;
        private GraphicsDevice m_GraphicsDevice;

        public static Globals instance()
        {
            return uniqueInstance;
        }

        private Globals()
        {
            // Accessors
            void setTime(float time)
            {
                this.m_Time = time;
            }

            float getTime()
            {
                return this.m_Time;
            }

            SpriteBatch getSpriteBatch()
            {
                return m_SpriteBatch;
            }

            void setSpriteBatch(SpriteBatch sb)
            {
                this.m_SpriteBatch = sb;   
            }

            void setGraphicsDevice(GraphicsDevice gd)
            {
                this.m_GraphicsDevice = gd;
            }

            GraphicsDevice getGraphicsDevice()
            {
                return this.m_GraphicsDevice;
            }
        }
    }
}
