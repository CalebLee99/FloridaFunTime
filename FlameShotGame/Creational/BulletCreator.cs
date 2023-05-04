using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using FlameShotGame.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FlameShotGame.Creational
{
    public class BulletCreator : EntityCreator
    {
        Globals global = Globals.Instance();

        protected override Entity createEntity(string entityType, Vector2 pos, int damage, IMovement movement)
        {
            if (entityType.ToLower() == "player")
            {
                return new PlayerBullet(global.Content.Load<Texture2D>("Sprites/playerbullet"), pos, damage, movement);
            }
            else if (entityType.ToLower() == "enemy")
            {
                return new EnemyBullet(global.Content.Load<Texture2D>("Sprites/enemybullet"), pos, damage, movement);
            }
            else
            {
                Debug.WriteLine("Invalid Entity Requested in BulletCreator");
                return null;
            }
        }
    }
}