using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlameShotGame.GameObjects
{
    public abstract class Bullet : Entity
    {
        protected int Damage { get; set; }
        
        public Bullet(Texture2D texture, Vector2 pos, int damage) : base(texture, pos)
        {
            this.Damage = damage;
        }

        public override void Move()
        {
            
        }
    }
}
