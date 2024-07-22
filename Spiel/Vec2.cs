using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spiel
{
    public class Vec2
    {
        public float x;
        public float y;

        public Vec2()
        {
        }

        public Vec2(float xin, float yin)
        {
            x = xin;
            y = yin;
        }

        public bool Gleich(Vec2 rhs)
        {
            return (x == rhs.x && y == rhs.y);
        }

        public bool UnGleich(Vec2 rhs)
        {
            return (x != rhs.x && y != rhs.y);
        }

        public Vec2 Plus(Vec2 rhs)
        {
            return new Vec2(x + rhs.x, y + rhs.y);
        }

        public Vec2 Minus(Vec2 rhs)
        {
            return new Vec2(rhs.x - x, rhs.y - y);
        }

        public Vec2 Geteilt(float val)
        {
            return new Vec2(x / val, y / val);
        }

        public Vec2 Mal(float val)
        {
            return new Vec2(x * val, y * val);
        }

        public void PlusGleich(Vec2 rhs)
        {
            x += rhs.x;
            y += rhs.y;
        }

        public void MinusGleich(Vec2 rhs)
        {
            x -= rhs.x;
            y -= rhs.y;
        }

        public void MalGleich(float val)
        {
            x *= val;
            y *= val;
        }

        public void DurchGleich(float val)
        {
            x /= val;
            y /= val;
        }

        public float Distanc(Vec2 rhs)
        {
            float dx = rhs.x - x;
            float dy = rhs.y - y;
            return (float)Math.Sqrt(dx * dx + dy * dy);
        }
    }
}
