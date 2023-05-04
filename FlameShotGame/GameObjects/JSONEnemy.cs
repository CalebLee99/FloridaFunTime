using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlameShotGame.GameObjects
{
    internal class JSONEnemy
    {
        public string enemyName { get; set; }
        public string movementType { get; set; }
        public string data { get; set; }
        public int spawnTime { get; set; }
        public int speed { get; set; }
        public int spawnLocX { get; set; }
        public int spawnLocY { get; set; }

        public JSONEnemy(string name, string type, string data, int spawnTime, int speed, int sX, int sY)
        {
            this.enemyName = name;
            this.movementType = type;
            this.data = data;
            this.spawnTime = spawnTime;
            this.speed = speed;
            this.spawnLocX = sX;
            this.spawnLocY = sY;
        }
    }
}
