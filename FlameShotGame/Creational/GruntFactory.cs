using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlameShotGame.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;


namespace FlameShotGame.Creational
{
    public class EnemyFactory
    {
        public Entity CreateEnemy(string enemyType, Texture2D texture, Vector2 pos, Player player, List<Vector2> movePath)
        {
            if (enemyType == "alligator")
            {
                return new AlligatorEnemy(texture, pos, player);
            }
            else if (enemyType == "grunt")
            {
                return new GruntEnemy(texture, pos, movePath);
            }
            else
            {
                Debug.WriteLine("Enemy Type of " + enemyType + " not recognized.");
                return null;
            }
        }
    }
}
