using Spiel.System;
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
