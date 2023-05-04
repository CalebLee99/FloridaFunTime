using System;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlameShotGame.Creational;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct2D1;


namespace FlameShotGame.GameObjects
{
    public class Notify : Entity
    {
        public Notify(Texture2D texture, Vector2 pos) : base(texture, pos)
        {

        }

        public override void Move()
        {
        }
    }
}
