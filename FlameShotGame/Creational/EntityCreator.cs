using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using FlameShotGame.GameObjects;

namespace FlameShotGame.Creational
{
    public abstract class EntityCreator
    {
        protected abstract Entity createEntity(String entityType, Vector2 pos, int damage, IMovement movement);

        public Entity provideEntity(String entityType, Vector2 pos, int damage, IMovement movement)
        {
            Entity entity = createEntity(entityType, pos, damage, movement);
            return entity;
        }
    }
}
