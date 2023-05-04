using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FlameShotGame.GameObjects
{
    internal class HeartPowerUp : Entity
    {

        public HeartPowerUp(Texture2D texture, Vector2 pos) : base(texture, pos)
        {
        }
        public override void Move()
        {
        }
    }
}
