using FlameShotGame.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.MediaFoundation;
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
        public float MaxTime;
        public float Age;
        private static SpawnManager spawnManager = SpawnManager.Instance();
        public Bullet(Texture2D texture, Vector2 pos, int damage) : base(texture, pos)
        {
            this.Damage = damage;
            MaxTime = 10;
        }

        public int GetDamage()
        {
            return this.Damage;
        }

        public override void Update()
        {
            base.Update();
            Age += Globals.Time;
            if (Age >= MaxTime && this.GetType() == typeof(EnemyBullet))
            {
                spawnManager.DespawnEnemyBullet(this);
            }
        }

    }
}
