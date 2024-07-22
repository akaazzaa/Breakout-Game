using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Graphics.Glsl;
using SFML.System;
using Spiel.Model;

namespace Spiel
{
    public class StoneManager
    {
        public List<Stone> stones = new List<Stone>();
        public Dictionary<string,List<Stone>> stonesDictionary = new Dictionary<string,List<Stone>>();

        public uint totalStones = 0;
        public StoneManager() 
        {
          
        }

        public List<Stone> GetStones() { return stones; }

        public List<Stone> GetStoneByTag(string tag)
        {
            return stonesDictionary[tag];
        }
    }
}
