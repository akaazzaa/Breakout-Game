using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using Spiel.Assets.src.Components;
using Spiel.Assets.src.Model;



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
        Game game;
        Level level;
        Settings settings;
        Sound sound;
        SoundBuffer buffer;
        


        uint wWidth ,wHeight ;
        uint frames;
        public Menu()
        {
            Init();
        }
        public void Init()
        {
            wWidth = 1400;
            wHeight = 1080;
            frames = 60;
            // window erstellen
            window = new RenderWindow(new VideoMode(wWidth, wHeight), "SFML Main Menu");
            window.SetFramerateLimit(frames); 
            window.Closed += new EventHandler(OnClose);
            window.MouseMoved += Window_MouseMoved;
            window.MouseButtonPressed += Window_MouseButtonPressed;

            buffer = new SoundBuffer("C:\\Users\\dgami\\source\\repos\\Spiel\\Spiel\\Assets\\Resources\\Sounds\\pixelgroove-77930.mp3");

            sound = new Sound(buffer);
            sound.Volume = 1f;
            sound.Play();

            // 1: Rows , 1: Column ,
            level = new Level(10, 1, 0, 0, 40, 20, 0, 0);



            // Hintergund Laden und Instantzieren
            background = new Sprite(ResourceLoader.Instance.LoadTexture("UI\\gray-textured-wall.jpg")); 
           
            CreateButtons();

        }

        private void Window_MouseButtonPressed(object? sender, MouseButtonEventArgs e)
        {
            
            if (playButton.IsMouseOver(window)) 
            {
                sound.Stop();
                game = new Game(window);
                game.CreateLevel(level);
                
            }

            if (ExitButton.IsMouseOver(window))
            {
                window.Close();
            }

            if (settingsButton.IsMouseOver(window))
            {
                settings = new Settings(window);
                settings.SettingsStart();

            }
        }

        private void CreateButtons()
        {
          
            playButton = new Button(new Vector2f(150, 50));
            playButton.SetPosition(new Vector2f(window.Size.X / 2 - 60, window.Size.Y / 4));
            playButton.SetTexture(ResourceLoader.Instance.LoadTexture("UI\\Large Buttons\\Large Buttons\\Play Button.png"));
           
            settingsButton = new Button(new Vector2f(150,50));
            settingsButton.SetPosition(new Vector2f(window.Size.X / 2 - 60 , window.Size.Y / 3));
            settingsButton.SetTexture(ResourceLoader.Instance.LoadTexture("UI\\Large Buttons\\Large Buttons\\Options Button.png"));

            ExitButton = new Button(new Vector2f(150, 50));
            ExitButton.SetPosition(new Vector2f(window.Size.X / 2 - 60, window.Size.Y / 2));
            ExitButton.SetTexture(ResourceLoader.Instance.LoadTexture("UI\\Large Buttons\\Large Buttons\\Exit Button.png"));
        }

        public void MenuStart()
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
                playButton.Draw(window);
                settingsButton.Draw(window);
                ExitButton.Draw(window);

                // Display the window
                window.Display();
            }
        }

        private void Window_MouseMoved(object? sender, MouseMoveEventArgs e)
        {
            RenderWindow window = (RenderWindow)sender;
            if (playButton.IsMouseOver(window))
            {
                playButton.SetTexture(ResourceLoader.Instance.LoadTexture("UI\\Large Buttons\\Colored Large Buttons\\Play col_Button.png"));
            }
            else
            {
                playButton.SetTexture(ResourceLoader.Instance.LoadTexture("UI\\Large Buttons\\Large Buttons\\Play Button.png"));
            }

            if (settingsButton.IsMouseOver(window))
            {
                settingsButton.SetTexture(ResourceLoader.Instance.LoadTexture("UI\\Large Buttons\\Colored Large Buttons\\Options  col_Button.png"));
            }
            else
            {
                settingsButton.SetTexture(ResourceLoader.Instance.LoadTexture("UI\\Large Buttons\\Large Buttons\\Options Button.png"));
            }



            if (ExitButton.IsMouseOver(window))

            {
                ExitButton.SetTexture(ResourceLoader.Instance.LoadTexture("UI\\Large Buttons\\Colored Large Buttons\\Exit  col_Button.png"));
            }
            else
            {
                ExitButton.SetTexture(ResourceLoader.Instance.LoadTexture("UI\\Large Buttons\\Large Buttons\\Exit Button.png"));
            }

        }

        private void OnClose(object? sender, EventArgs e)
        {
            RenderWindow window = (RenderWindow)sender;
            window.Close();

        }


    }
}
