using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Spiel.Assets.src.System
{
    public class Settings
    {
        public string GameTitle { get; set; }
        public int WindowWidth { get; set; }
        public int WindowHeight { get; set; }


        private static readonly string ConfigPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Config", "Config.txt");

        public void Load()
        {
            if (File.Exists(ConfigPath))
            {
                //var json = File.ReadAllText(ConfigPath);
                //var settings = JsonConvert.DeserializeObject<Settings>(json);
                //if (settings != null)
                //{
                //    GameTitle = settings.GameTitle;
                //    WindowWidth = settings.WindowWidth;
                //    WindowHeight = settings.WindowHeight;
                //}
            }
        }

        public void Save()
        {
            //var json = JsonConvert.SerializeObject(this, Formatting.Indented);
            //File.WriteAllText(ConfigPath, json);
        }
    }
}
