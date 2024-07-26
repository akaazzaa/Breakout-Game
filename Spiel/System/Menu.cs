using SFML.Graphics;
using SFML.System;
using SFML.Window;
using Spiel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Spiel.System
{
    public class Menu
    {
        Button myButton = new Button("Click me", new Vector2f(200, 50), 20, Color.Transparent, Color.White);
        Texture texture = new Texture(Source.GetPath("Blue", Source.ui));
        Sprite background = new Sprite(new Texture(Source.GetPath(8, Source.background)));
        RenderWindow window = new RenderWindow(new VideoMode(800, 600), "SFML Main Menu");
        Font font = new Font("C:\\Users\\dgami\\source\\repos\\Spiel\\Spiel\\Fonts\\Lemon Shake Shake.ttf");
        public void MenuStart()
        { 
            window.Closed += new EventHandler(OnClose);
            window.MouseMoved += Window_MouseMoved;

            myButton.SetPosition(new Vector2f(100, 300));
            myButton.SetFont(font);
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
                myButton.Draw(window);
               
                
                // Display the window
                window.Display();
            }
        }

        private void Window_MouseMoved(object? sender, MouseMoveEventArgs e)
        {
            RenderWindow window = (RenderWindow)sender;
            if (myButton.IsMouseOver(window))
            {
                myButton.SetBackColor(Color.Red);
            }
            else
            {
                myButton.SetBackColor(Color.Transparent);
            }
        }

        private void OnClose(object? sender, EventArgs e)
        {
            RenderWindow window = (RenderWindow)sender;
            window.Close();

        }

        
    }
}
