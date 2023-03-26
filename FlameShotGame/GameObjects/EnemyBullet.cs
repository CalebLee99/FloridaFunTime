﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlameShotGame.GameObjects
{
    internal class EnemyBullet : Bullet
    {
        public EnemyBullet(Texture2D texture, Vector2 pos, int damage) : base(texture, pos, damage)
        {
        }

        public override void Move()
        {
            return;
        }
    }
}
