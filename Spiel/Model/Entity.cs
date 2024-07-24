using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spiel.Model
{
    public class Entity
    {
        public bool _active = true;
        public uint _id = 0;
        public string _tag = "default";

        public Components.Transform Transform { get; set; }
        public Sprite Sprite { get; set; }
        public Components.Input Input { get; set; }
        public Components.Score Score { get; set; }
        public Components.Collision Collision { get; set; }

        public Entity(uint id, string tag)
        {
            _id = id;
            _tag = tag;
        }

        public bool IsActive()
        {
            return _active;
        }

        public string GetTag() { return _tag; }

        public uint GetID() { return _id; }

        public void destroy() { _active = false; }
    }
}
