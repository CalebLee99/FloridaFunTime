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
        public Entity CreateEnemy(string enemyType, string movementType, int speed, string data, Texture2D texture, Vector2 pos)
        {
            IMovement movement = null;
            if (movementType == "chase")
            {
                movement = new ChaseMovement(pos, speed);
            }
            else if (movementType == "patrol")
            {
                /*movement = new PatrolMovement(); //Temp*/
            }
            else
            {
                Debug.WriteLine("Invalid Movement");
            }
            
            if (enemyType == "alligator")
            {
                return new AlligatorEnemy(texture, pos, movement);
            }
            else if (enemyType == "enemy")
            {
                return new GruntEnemy(texture, pos, movement);
            }
            else
            {
                Debug.WriteLine("Enemy Type of " + enemyType + " not recognized.");
                return null;
            }
        }
    }
}
