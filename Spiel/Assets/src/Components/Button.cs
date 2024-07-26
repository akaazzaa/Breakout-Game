using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Spiel.Assets.src.Components
{
    class Button
    {
        private RectangleShape button = new RectangleShape();
        private Text text = new Text();

        public Button(string text, Vector2f size, uint charSize, Color bgColor, Color textColor)
        {
            this.text.DisplayedString = text;
            this.text.FillColor = textColor;
            this.text.CharacterSize = charSize;

            button.Size = size;
            button.FillColor = bgColor;

        }
        public void SetFont(Font font)
        {
            text.Font = font;
        }
        public void SetTexture(Texture texture)
        {
            button.Texture = texture;
        }
        public void SetTexColor(Color color)
        {
            text.FillColor = color;
        }
        public void SetBackColor(Color color)
        {
            button.FillColor = color;
        }
        public void SetPosition(Vector2f pos)
        {
            button.Position = pos;

            FloatRect textRect = text.GetLocalBounds();
            text.Origin = new Vector2f(textRect.Left + textRect.Width / 3.5f, textRect.Top + textRect.Height / 3.5f);
            text.Position = new Vector2f(button.Position.X + button.Size.X / 3.5f, button.Position.Y + button.Size.Y / 3.5f);
        }
        public void Draw(RenderWindow window)
        {
            window.Draw(button);
            window.Draw(text);
        }
        public bool IsMouseOver(RenderWindow window)
        {

            Vector2i mousePos = Mouse.GetPosition(window);
            FloatRect buttonBounds = button.GetGlobalBounds();
            return buttonBounds.Contains(mousePos.X, mousePos.Y);

        }
    }


}

