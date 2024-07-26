using SFML.Graphics;
using SFML.System;
using SFML.Window;
using Spiel.Assets.src.Components;



namespace Spiel.Assets.src.System
{
    public class Menu
    {
        Button playButton;
        Button settingsButton;
        Button ExitButton;
        Sprite background;
        RenderWindow window;
        Font font;

        public Menu()
        {
            Init();
        }
        public void Init()
        {
            // window erstellen
            window = new RenderWindow(new VideoMode(800, 600), "SFML Main Menu");
            window.Closed += new EventHandler(OnClose);
            window.MouseMoved += Window_MouseMoved;

           
            
            // Hintergund Laden und Instantzieren
            background = new Sprite(ResourceLoader.Instance.LoadTexture("UI\\Background\\Big@2x.png")); ;
           
            CreateButtons();

        }

        private void CreateButtons()
        {
            font = new Font(ResourceLoader.Instance.FontLoder("Lemon Shake Shake.ttf"));

            playButton = new Button("Play", new Vector2f(100, 50), 20, Color.White, Color.White);
            playButton.SetPosition(new Vector2f(window.Size.X / 2 - 50, window.Size.Y / 4));
            playButton.SetTexture(ResourceLoader.Instance.LoadTexture("UI\\png\\Buttons\\Rect-Medium\\PlayIcon\\Default.png"));
            //playButton.SetFont(font);

            
        }

        public void MenuStart()
        {

            // Create menu loop
            while (window.IsOpen)
            {
                // Check for events
                window.DispatchEvents();



                // Clear the window
                window.Clear(Color.Black);
                // Zeichnet 
                
                // Eingener Button
                playButton.Draw(window);


                // Display the window
                window.Display();
            }
        }

        private void Window_MouseMoved(object? sender, MouseMoveEventArgs e)
        {
            RenderWindow window = (RenderWindow)sender;
            if (playButton.IsMouseOver(window))
            {
                playButton.SetTexture(ResourceLoader.Instance.LoadTexture("UI\\png\\Buttons\\Rect-Medium\\PlayIcon\\Hover.png"));
            }
            else
            {
                playButton.SetTexture(ResourceLoader.Instance.LoadTexture("UI\\png\\Buttons\\Rect-Medium\\PlayIcon\\Default.png"));
            }
        }

        private void OnClose(object? sender, EventArgs e)
        {
            RenderWindow window = (RenderWindow)sender;
            window.Close();

        }


    }
}
