using SFML.Graphics;
using SFML.Window;
using Spiel.Assets.src.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Spiel.Assets.src.Model
{
    public class Entity
    {
        public bool _active = true;
        public uint _id = 0;
        public string _tag = "default";
        public bool _Ismoving = false;


        public Components.Transform Transform { get; set; }
        public CircleShape Circle { get; set; }
        public RectangleShape Rectangle { get; set; }
        public int hitcounter { get; set; }
        public Input Input { get; set; }
        public Score Score { get; set; }
        public Collision Collision { get; set; }

        public Entity(uint id, string tag)
        {
            _id = id;
            _tag = tag;

            hitcounter = 3;
        }

        public bool IsActive()
        {
            return _active;
        }

        public string GetTag() { return _tag; }

        public uint GetID() { return _id; }

        public void destroy() { _active = false; }

        public void Hit()
        {
            hitcounter--;
            if (hitcounter == 2)
            {
                Rectangle.Texture = ResourceLoader.Instance.LoadTexture("big bricks\\bigBrickGreenHit1.png");
            }
            if (hitcounter == 1)
            {
                Rectangle.Texture = ResourceLoader.Instance.LoadTexture("big bricks\\bigBrickGreenHit2.png");
            }
            if (hitcounter == 0)
            {
                destroy();
            }
        }

        
    }
}
