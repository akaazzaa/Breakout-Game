using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SFML.Window.Mouse;


namespace Spiel.Assets.src.Components
{
    public class SettingsPanel
    {
        RectangleShape panel = new RectangleShape();
        RectangleShape Header = new RectangleShape();
        RectangleShape middelPanel = new RectangleShape();

        Text text = new Text();
        public Vector2f Size { get;  }

        public SettingsPanel(Vector2f size,string titel)
        {
            panel.Size = size;
            Size = panel.Size;
            panel.OutlineColor = Color.Black;
            panel.OutlineThickness = 15;

            this.text.DisplayedString = titel;

            Header.Size = new Vector2f(panel.Size.X ,100);
            Header.FillColor = Color.Black;

            middelPanel.Size = new Vector2f(panel.Size.X - 200, panel.Size.Y - 200);
            middelPanel.FillColor = Color.Black;
            
        }
        
        public void SetCharsize(uint size)
        {
            this.text.CharacterSize = size; 
        }
        public void SetTexColor(Color color)
        {
            this.text.FillColor = color;
        }
        public void SetFont(Font font)
        {
            this.text.Font = font;
        }
        public void SetTitel(string titel)
        {
            this.text.DisplayedString = titel;
        }
        public void SetColor(Color color)
        {
            panel.FillColor = color;
        }

        public void SetPosition(Vector2f pos)
        {
            panel.Position = pos;

            Header.Position = new Vector2f(panel.Position.X , panel.Position.Y );

            middelPanel.Position = new Vector2f (panel.Position.X + middelPanel.Size.X /8  , panel.Position.Y + 150);

            text.Position = new Vector2f(panel.Position.X + panel.Size.X /2 - 100 ,panel.Size.Y / 16);

        }
        public void SetTexture(Texture texture)
        {
           panel.Texture = texture;
        }
        public void Draw(RenderWindow window)
        {
            window.Draw(panel);
            window.Draw(Header);
            window.Draw(middelPanel);
            window.Draw(text);

        }



    }
}
