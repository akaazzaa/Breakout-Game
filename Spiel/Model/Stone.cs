using SFML.Graphics;
using SFML.System;

namespace Spiel.Model
{
    public class Stone
    {
        public bool active = true;
        public uint id = 0;
        public string tag = "default";


        public RectangleShape StoneShape = new RectangleShape();
        public Components.Transform Transform {  get; set; }
        public Components.Collision Collision { get; set; }
        public Components.Score Score { get; set; }

        public Stone(uint id,string tag,Vector2f size, Color color)
        {
            this.id = id;
            this.tag = tag;

            StoneShape.Size = size; 
            StoneShape.FillColor = color;
        }

        public bool IsActive()
        {
            return active;
        }

        public string GetTag() { return tag; }
        public uint GetID() { return id; }
        public void Destroy() { active = false; }


    }
}
