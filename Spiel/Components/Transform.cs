using SFML.Graphics.Glsl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spiel.Components
{
    public class Transform
    {
        public Vec2 pos { get; set; }
        public Vec2 velocity { get; set; }

        public Transform(Vec2 pos, Vec2 velocity)
        {
            this.pos = pos;
            this.velocity = velocity;
        }
    }
}
