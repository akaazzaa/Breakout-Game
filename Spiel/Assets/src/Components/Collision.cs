using SFML.Graphics;
using SFML.System;


namespace Spiel.Assets.src.Components
{
    public class Collision
    {
        public float raduis = 0;
        public float x = 0;
        public float y = 0;

        public Collision(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
        public Collision(float raduis) { this.raduis = raduis; }

        public static int CheckCollision(CircleShape ball, RectangleShape rect)
        {
            float closetX = Clamp(ball.Position.X, rect.Position.X, rect.Position.X + rect.Size.X);
            float closetY = Clamp(ball.Position.Y, rect.Position.Y, rect.Position.Y + rect.Size.Y);

            float distanceX = ball.Position.X - closetX;
            float distanceY = ball.Position.Y - closetY;

            float distanceSquared = distanceX * distanceX + distanceY * distanceY;
            if (distanceSquared < ball.Radius * ball.Radius && closetX != ball.Position.X && closetY != ball.Position.Y)
            {
                return 3;
            }
            else if (distanceSquared < ball.Radius * ball.Radius && closetX == ball.Position.X)
            {
                return 2;
            }
            else if (distanceSquared < ball.Radius * ball.Radius && closetY == ball.Position.Y)
            {
                return 1;
            }

            else return 0;

        }
        public static float Clamp(float value, float min, float max)
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }

    }
}
