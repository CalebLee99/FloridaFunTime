using FlameShotGame;
using FlameShotGame.Managers;
using Microsoft.VisualBasic.Devices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D9;
using SharpDX.DirectWrite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlameShotGame.GameObjects
{
    public class HealthBar : Entity
    {
        public HealthBar(Texture2D texture, Vector2 pos) : base(texture, pos)
        {
            
        }

        public override void Move()
        {
            // Do nothing; we dont want the health bar to move.
        }
    }
}
