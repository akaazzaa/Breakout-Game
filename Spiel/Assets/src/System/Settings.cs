using SFML.Graphics;
using SFML.Window;
using Spiel.Assets.src.Components;
using Spiel.Assets.src.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
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
        RenderWindow window;
        Sprite background;
        SettingsPanel settingsPanel;


        private static readonly string ConfigPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Config", "Config.txt");


        public Settings(RenderWindow window) 
        {
            this.window = window;
            Init();
        }

        public void Init()
        {
            
            window.Closed += new EventHandler(OnClose);
            window.MouseMoved += Window_MouseMoved;
            window.MouseButtonPressed += Window_MouseButtonPressed;

            background = new Sprite(ResourceLoader.Instance.LoadTexture("UI\\gray-textured-wall.jpg"));
            CreatePanel();
        }

        public void CreatePanel()
        {
            settingsPanel = new SettingsPanel(new SFML.System.Vector2f(1000,1000),"Game Settings");
            settingsPanel.SetPosition(new SFML.System.Vector2f(window.Size.X / 2 - settingsPanel.Size.X /2  ,window.Size.Y / 2 - settingsPanel.Size.Y /2));
            settingsPanel.SetFont(ResourceLoader.Instance.FontLoder("Lemon Shake Shake.ttf"));
            settingsPanel.SetTexture(ResourceLoader.Instance.LoadTexture("UI\\59277.png"));
            //settingsPanel.SetColor(Color.Black);
            settingsPanel.SetTexColor(Color.Red);
        }
        public void SettingsStart()
        {

            // Create menu loop
            while (window.IsOpen)
            {
                // Check for events
                window.DispatchEvents();



                // Clear the window
                window.Clear();
                // Zeichnet 
                window.Draw(background);
                // Eingener Button
                settingsPanel.Draw(window);

                // Display the window
                window.Display();
            }
        }

        private void OnClose(object? sender, EventArgs e)
        {
            RenderWindow window = (RenderWindow)sender;
            window.Close();
        }

        private void Window_MouseButtonPressed(object? sender, MouseButtonEventArgs e)
        {
            
        }

        private void Window_MouseMoved(object? sender, MouseMoveEventArgs e)
        {
           
        }

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
