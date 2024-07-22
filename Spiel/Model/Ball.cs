using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spiel.Components;

namespace Spiel.Model
{
    public class Ball
    {
        public CircleShape circle = new CircleShape();
        public Components.Transform  transform {  get; set; }
        public Components.Collision collision {  get; set; }

        public Ball(float radius, Color color)
        {
            circle = new CircleShape(radius);
            circle.FillColor = color;
        }
    }
}
