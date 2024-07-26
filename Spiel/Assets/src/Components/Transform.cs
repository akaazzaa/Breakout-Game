using Spiel.Assets.src.System;

namespace Spiel.Assets.src.Components
{
    public class Transform
    {
        public Vec2 pos { get; set; }
        public Vec2 velocity { get; set; }

        public float DeltaTime { get; set; }

        public Transform(Vec2 pos, Vec2 velocity)
        {

            this.pos = pos;
            this.velocity = velocity;
        }
    }
}
