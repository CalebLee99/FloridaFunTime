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
                string[] dev = data.Split(",");
                int x_dev;
                int y_dev;

                Int32.TryParse(dev[0], out x_dev);
                Int32.TryParse(dev[1], out y_dev);

                List<Vector2> points = new List<Vector2>();
                points.Add(new Vector2(pos.X, pos.Y));
                points.Add(new Vector2(pos.X + x_dev, pos.Y));
                points.Add(new Vector2(pos.X + x_dev, pos.Y + y_dev));
                points.Add(new Vector2(pos.X, pos.Y + y_dev));

                movement = new PatrolMovement(pos, new List<Vector2>() { new Vector2(100, 100), new Vector2(400, 100), new Vector2(400, 400), new Vector2(100, 400) }, speed);
            }
            else if (movementType == "circle")
            {
                int radius;
                Int32.TryParse(data, out radius);
               
                movement = new CircleMovement(pos, speed, radius);
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
            else if (enemyType == "snake")
            {
                return new SnakeEnemy(texture, pos, movement);
            }
            else if (enemyType == "midboss")
            {
                return new MidbossEnemy(texture, pos, movement);
            }
            else
            {
                Debug.WriteLine("Enemy Type of " + enemyType + " not recognized.");
                return null;
            }
        }
    }
}
