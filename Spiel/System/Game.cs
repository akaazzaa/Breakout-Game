using SFML.Graphics;
using SFML.Graphics.Glsl;
using SFML.System;
using SFML.Window;
using Spiel.Model;
using System.Net.Http.Headers;
using System.Net.WebSockets;
using System.Numerics;



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
        EntityManager EntityManager = new EntityManager();

        public Game()
        {
            Init();
        }
        public void CreateLevel(Level level)
        {
            // Konstanten für Skalierung und Fenstergröße
            const float SCALE_FACTOR = 2.0f;

            // Laden der Textur
            Texture texture = new Texture(Source.GetPath("bigGreenBrick", Source.bigBricks));

            // Dynamische Berechnung der Blockgrößen basierend auf der Texturgröße
            float blockWidth = texture.Size.X * SCALE_FACTOR;
            float blockHeight = texture.Size.Y * SCALE_FACTOR;

            // Berechnungen für die Startkoordinaten
            float xStart = (_wWidth - (level.Columns * (blockWidth + level.HorizontalSpacing) - level.HorizontalSpacing)) / 2;
            float yStart = (_wHeight / 3) - (level.Rows * (blockHeight + level.VerticalSpacing) - level.VerticalSpacing) / 2;

            CreateBall();
            spawnplayer();
             
            

            for (int row = 0; row < level.Rows; row++)
            {
                for (int col = 0; col < level.Columns; col++)
                {
                    // Berechnung der Positionen der Steine
                    float posX = xStart + col * (blockWidth + level.HorizontalSpacing);
                    float posY = yStart + row * (blockHeight + level.VerticalSpacing);

                    // Erstellung und Initialisierung der Steine
                    Entity stone = EntityManager.AddEntity("Stone");
                    stone.Sprite = new Sprite(texture);
                    stone.Sprite.Scale = new Vector2f(SCALE_FACTOR, SCALE_FACTOR);
                    stone.Transform = new Components.Transform(new Vec2(posX, posY), new Vec2(0, 0));
                    stone.Collision = new Components.Collision(blockWidth, blockHeight);
                }
            }

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

        }

        private void CreateBall()
        {
            Texture texture = new Texture(Source.GetPath("bigBallBraun", Source.balls));

            Entity ball = EntityManager.AddEntity("Ball");
            ball.Sprite = new Sprite(texture);
            ball.Sprite.Scale = new Vector2f(2, 2);
            ball.Transform = new Components.Transform(new Vec2(_wWidth / 2, _wHeight / 2), new Vec2(1, -1));
            ball.Collision = new Components.Collision(ball.Sprite.Texture.Size.X, ball.Sprite.Texture.Size.Y);
            Ball = ball;
        }

        private void spawnplayer()
        {
            Texture texture = new Texture(Source.GetPath("RedPaddelForm2", Source.paddels));
            Entity player = EntityManager.AddEntity("Player");
            player.Sprite = new Sprite(texture);
            player.Sprite.Scale = new Vector2f(4, 4);
            player.Transform = new Components.Transform(new Vec2(_wWidth / 2, _wHeight / 2), new Vec2(5, 5));
            player.Collision = new Components.Collision(player.Sprite.Texture.Size.X, player.Sprite.Texture.Size.Y);
            player.Input = new Components.Input();
            Player = player;
        }
        void Movement()
        {
            Player.Transform.velocity = new Vec2(0, 0);

            if (Player.Input.left && Player.Transform.pos.x > -1)
            { Player.Transform.velocity.x = -10.0f; }

            if (Player.Input.right && Player.Transform.pos.x + Player.Collision.x * 4 < _wWidth)
            { Player.Transform.velocity.x = 10.0f; }

            Player.Transform.pos.x += Player.Transform.velocity.x;
            Player.Transform.pos.y += 0;

            Ball.Transform.pos.x += Ball.Transform.velocity.x;
            Ball.Transform.pos.y += Ball.Transform.velocity.y;

            if (Ball.Transform.pos.y <= -1)
            {
                Ball.Transform.velocity.y = +5.0f;
            }
            else if (Ball.Transform.pos.y > _wHeight)
            {
                Ball.Transform.pos.x = _wWidth / 2;
                Ball.Transform.pos.y = _wHeight / 2;
            }
            else if (Ball.Transform.pos.x <= -1)
            {
                Ball.Transform.velocity.x = +5.0f;
            }
            else if (Ball.Transform.pos.x >= _wWidth - Ball.Collision.x * 2)
            {
                Ball.Transform.velocity.x = -5.0f;
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
        void SCollision()
        {
            //foreach (Stone stone in stoneManager.stones)
            //{
            //    if (Components.Collision.CheckCollision(Ball.transform.pos, Ball.collision.raduis, stone.Transform.pos, stone.Collision.width,stone.Collision.height))
            //    {
            //        stone.Destroy();
            //    }
            //}
        }

        private void Render()
        {
            _window.Clear();

            foreach (Entity entity in EntityManager.entities)
            {
                entity.Sprite.Position = new Vector2f(entity.Transform.pos.x, entity.Transform.pos.y);

                _window.Draw(entity.Sprite);
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


            }
        }


    }


}
