using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FlameShotGame.GameObjects
{
    public abstract class IMovement
    {
        protected string data;
        protected int speed;
        public abstract Vector2 Move();
    }
}
