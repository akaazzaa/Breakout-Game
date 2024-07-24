using Spiel.System;

namespace Spiel.Components
{
    public class Collision
    {
        public float raduis = 0;
        public float x = 0;
        public float y = 0;

        public Collision(float x,float y)
        {
            this.x = x;
            this.y = y;
        }
        public Collision(float raduis) { this.raduis = raduis; }

        public static bool CheckCollision(Vec2 pos1,float radius, Vec2 pos2, float width, float height)
        {
            float dist = (float)pos1.Distanc(pos2);
            if (dist < radius )
            {
                return true;
            }
            return false;
        }

    }
}
