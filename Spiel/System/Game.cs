using InstilledBee.SFML.SimpleCollision;
using SFML.Graphics;
using SFML.Graphics.Glsl;
using SFML.System;
using SFML.Window;
using Spiel.Model;
using System.ComponentModel;
using System.Net.Http.Headers;
using System.Net.WebSockets;
using System.Numerics;
using System.Reflection.Metadata;



namespace Spiel.System
{
    public class Game
    {
        RenderWindow _window;
        uint _frames;
        uint _wWidth, _wHeight;
        bool _isRunning = true;
        Entity Player;
        Entity Ball;
        Sprite background;
        Entity TestStone;
        EntityManager EntityManager = new EntityManager();
       
        public Game()
        {
            Init();
        }
        public void CreateLevel(Level level)
        {
            //Konstanten für Skalierung und Fenstergröße
            const float SCALE_FACTOR = 2.0f;

            // Laden der Textur
            Texture texture = new Texture(Source.GetPath("bigGreenBrick", Source.bigBricks));
            CollisionTester.AddBitMask(texture);
            // Dynamische Berechnung der Blockgrößen basierend auf der Texturgröße
            float blockWidth = texture.Size.X * SCALE_FACTOR;
            float blockHeight = texture.Size.Y * SCALE_FACTOR;

            // Berechnungen für die Startkoordinaten
            float xStart = (_wWidth - (level.Columns * (blockWidth + level.HorizontalSpacing) - level.HorizontalSpacing)) / 2;
            float yStart = (_wHeight / 3) - (level.Rows * (blockHeight + level.VerticalSpacing) - level.VerticalSpacing) / 2;

            for (int row = 0; row < level.Rows; row++)
            {
                for (int col = 0; col < level.Columns; col++)
                {
                    // Berechnung der Positionen der Steine
                    float posX = xStart + col * (blockWidth + level.HorizontalSpacing);
                    float posY = yStart + row * (blockHeight + level.VerticalSpacing);

                    // Erstellung und Initialisierung der Steine
                    Entity stone = EntityManager.AddEntity("Stone");
                    stone.Rectangle = new RectangleShape(new Vector2f(texture.Size.X, texture.Size.Y));
                    stone.Rectangle.Texture = texture;
                    stone.Rectangle.Scale = new Vector2f(SCALE_FACTOR, SCALE_FACTOR);
                    stone.Transform = new Components.Transform(new Vec2(posX, posY), new Vec2(0, 0));
                    stone.Collision = new Components.Collision(blockWidth, blockHeight);
                }
            }
            CreateBall();
            spawnplayer();
        }
        void Init()
        {
            _wWidth = 1920;
            _wHeight = 1080;
            _frames = 60;

            _window = new RenderWindow(new VideoMode(_wWidth, _wHeight), "SFML GameTEst", Styles.Default);
            _window.SetFramerateLimit(_frames);
            _window.KeyPressed += new EventHandler<KeyEventArgs>(OnKeyPressed);
            _window.KeyReleased += new EventHandler<KeyEventArgs>(OnKeyRelease);
            _window.Closed += new EventHandler(OnClose);

            background = new Sprite(new Texture(Source.GetPath(8, Source.background)));
            
        }
        private void CreateBall()
        {
            Texture texture = new Texture(Source.GetPath("bigBallBraun", Source.balls));
            CollisionTester.AddBitMask(texture);
            Entity ball = EntityManager.AddEntity("Ball");

            ball.Circle = new CircleShape(texture.Size.Y / 2);
            ball.Circle.Texture = texture;
            ball.Transform = new Components.Transform(new Vec2(_wWidth / 2, _wHeight - 50), new Vec2(5, -5));
            ball.Collision = new Components.Collision(ball.Circle.Texture.Size.X , ball.Circle.Texture.Size.Y);
            Ball = ball;
        }
        private void spawnplayer()
        {
            Texture texture = new Texture(Source.GetPath("RedPaddelForm2", Source.paddels));
            
            Entity player = EntityManager.AddEntity("Player");

            player.Rectangle = new RectangleShape(new Vector2f(texture.Size.X + 60, texture.Size.Y + 30));
            player.Rectangle.Texture = texture;
            
            player.Transform = new Components.Transform(new Vec2(_wWidth / 2, _wHeight - 50), new Vec2(5, 5));
            player.Collision = new Components.Collision(player.Rectangle.Texture.Size.X, player.Rectangle.Texture.Size.Y);
            player.Input = new Components.Input();
            Player = player;
        }
        void Movement()
        {
            Player.Transform.velocity = new Vec2(0, 0);
            // Movement recht links
            if (Player.Input.left && Player.Transform.pos.x > -1)
            { Player.Transform.velocity.x = -10.0f; }
            if (Player.Input.right && Player.Transform.pos.x + Player.Collision.x * 4 < _wWidth)
            { Player.Transform.velocity.x = 10.0f; }

            //Movement hoch runter
            if ((Player.Input.up))
            {
                Player.Transform.velocity.y = -10.0f;
            }

            if ((Player.Input.down))
            {
                Player.Transform.velocity.y = 10.0f;
            }
            
            // Bewgenung der Objekte
            Player.Transform.pos.x += Player.Transform.velocity.x;
            Player.Transform.pos.y += Player.Transform.velocity.y;

            Ball.Transform.pos.x += Ball.Transform.velocity.x;
            Ball.Transform.pos.y += Ball.Transform.velocity.y;

            //Überprüfung der Kollision mit den Wänden
            if (Ball.Transform.pos.x <= 0 || Ball.Transform.pos.x >= _wWidth - Ball.Circle.Texture.Size.X)
                Ball.Transform.velocity.x = -Ball.Transform.velocity.x;

            if (Ball.Transform.pos.y <= 0)
                Ball.Transform.velocity.y = -Ball.Transform.velocity.y;

            // // Überprüfe, ob der Ball das untere Ende erreicht
            if (Ball.Transform.pos.y > _wHeight)
            {
                Ball.Transform.velocity.y = -Ball.Transform.velocity.y;
                //Ball.Transform.pos.x = _wWidth / 2;
                //Ball.Transform.pos.y = _wHeight / 2;
            }

        }
        private void OnKeyPressed(object? sender, KeyEventArgs e)
        {
            switch (e.Code)
            {
                case Keyboard.Key.Escape:
                    _isRunning = false;
                    break;
                case Keyboard.Key.A:
                    Player.Input.left = true;
                    break;
                case Keyboard.Key.W:
                    Player.Input.up = true;
                    break ;
                case Keyboard.Key.S:
                    Player.Input.down = true;
                    break;
                case Keyboard.Key.D:
                    Player.Input.right = true;
                    break;
            }
        }
        private void OnKeyRelease(object? sender, KeyEventArgs e)
        {
            switch (e.Code)
            {
                case Keyboard.Key.A:
                    Player.Input.left = false;
                    break;
                case Keyboard.Key.W:
                    Player.Input.up = false;
                    break;
                case Keyboard.Key.S:
                    Player.Input.down = false;
                    break; 
                case Keyboard.Key.D:
                    Player.Input.right = false;
                    break;
            }
        }
        void OnClose(object? sender, EventArgs e)
        {
            RenderWindow window = (RenderWindow)sender;
            window.Close();

        }
        private void UserInput()
        {
            _window.DispatchEvents();
        }
        void Collision()
        {
            
            if (EntityManager.entitiesByTag.ContainsKey("Stone"))
            {
                foreach (Entity stone in EntityManager.GetEntitiesByTag("Stone"))
                {
                    switch(Components.Collision.CheckCollision(Ball.Circle,stone.Rectangle))
                    {
                        //No hit 
                        case 0:Console.WriteLine("no hit");
                            break;
                            // hit left or right 
                        case 1:Console.WriteLine("left right");
                            stone.Hit();
                            Ball.Transform.velocity.x = -Ball.Transform.velocity.x;
                            break;
                            // hit top or bottm
                        case 2: Console.WriteLine("top bottom");
                            Ball.Transform.velocity.y = -Ball.Transform.velocity.y;
                            stone.Hit();
                            break;
                            // hit Corner
                        case 3: Console.WriteLine("corner");
                            stone.Hit();
                            Ball.Transform.velocity.x = -Ball.Transform.velocity.x;
                            Ball.Transform.velocity.y = -Ball.Transform.velocity.y;
                            break;

                    }
                }
            }

            switch (Components.Collision.CheckCollision(Ball.Circle, Player.Rectangle))
            {
                //No hit 
                case 0:
                    Console.WriteLine("no hit");
                    break;
                // hit left or right 
                case 1:
                    Console.WriteLine("left right");
                    Ball.Transform.velocity.x = -Ball.Transform.velocity.x;
                    break;
                // hit top or bottm
                case 2:
                    Console.WriteLine("top bottom");
                    Ball.Transform.velocity.y = -Ball.Transform.velocity.y;
                    break;
                // hit Corner
                case 3:
                    Console.WriteLine("corner");
                    Ball.Transform.velocity.x = -Ball.Transform.velocity.x;
                    Ball.Transform.velocity.y = -Ball.Transform.velocity.y;
                    break;

            }
        }
        private void Render()
        {
            _window.Clear(Color.White);
            _window.Draw(background);

            foreach (Entity entity in EntityManager.entities)
            {
                if(entity.Circle != null)
                {
                  entity.Circle.Position = new Vector2f(entity.Transform.pos.x, entity.Transform.pos.y);
                    _window.Draw(entity.Circle);
                }
                else
                {
                    entity.Rectangle.Position = new Vector2f(entity.Transform.pos.x, entity.Transform.pos.y);
                    _window.Draw(entity.Rectangle);
                }

                
            }
            
            _window.Display();
        }
        public void Run()
        {
            while (_isRunning)
            {
                EntityManager.Update();
                Movement();
                UserInput();
                Render();
                Collision();
 
            }
        }


    }


}
