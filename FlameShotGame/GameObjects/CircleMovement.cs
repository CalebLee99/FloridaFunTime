using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using System.Drawing;
using System.Windows.Forms.Design;

namespace FlameShotGame.GameObjects
{
    internal class CircleMovement : IMovement
    {
        private int speed { get; set; }
        private Vector2 currentPosition;
        private Vector2 origin;
        private float radius { get; set; }
        private float speed { get; set; }
        private float angle { get; set; }
        private float increase { get; set; }



        public CircleMovement(Vector2 currentPosition, float speed, float radius)
        {
            this.currentPosition = currentPosition;
            this.origin = currentPosition;
            this.radius = radius;
            this.speed = 0;
            this.angle = 0;
        }

        public override Vector2 Move()
        {
            speed += 0.10f;

            this.currentPosition.X = (float)(this.currentPosition.X + this.radius * Math.Cos(speed));
            this.currentPosition.Y = (float)(this.currentPosition.Y + this.radius * Math.Sin(speed));

            return this.currentPosition;

  /*          this.currentPosition.X = (float)(Globals.ScreenWidth / 2 + Math.Cos(angle) * radius);
            this.currentPosition.Y = (float)(Globals.ScreenHeight / 2 + Math.Sin(angle) * radius);

            angle += 0.1f;

            if (angle > MathHelper.TwoPi)
            {
                angle -= MathHelper.TwoPi;
            }

            return this.currentPosition;*/
        }
    }
}
