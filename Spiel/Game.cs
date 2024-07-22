using SFML.Graphics;
using SFML.Graphics.Glsl;
using SFML.System;
using SFML.Window;
using Spiel.Model;



namespace Spiel
{
    public class Game
    {
        RenderWindow _window;
        uint _frames;
        uint _wWidth, _wHeight;
        bool _isRunning = true;
        PlayerShape Player;
        Ball Ball;
        StoneManager stoneManager = new StoneManager();

        public Game() 
        {
            Init();
        }
        public void CreateLevel(Level level, float windowWidth, float windowHeight)
        {
            stoneManager.stones.Clear();
            float xStart = (windowWidth - (level.Columns * (level.BlockWidth + level.HorizontalSpacing) - level.HorizontalSpacing)) / 2;
            float yStart = windowHeight / 3 - (level.Rows * (level.BlockHeight + level.VerticalSpacing) - level.VerticalSpacing) / 2;

            for (int row = 0; row < level.Rows; row++)
            {
                for (int col = 0; col < level.Columns; col++)
                {
                    Stone stone = new Stone((uint)(row * level.Columns + col), "stone", new Vector2f(level.BlockWidth, level.BlockHeight), Color.Red);
                    stone.Transform = new Components.Transform(new Vec2(xStart + col * (level.BlockWidth + level.HorizontalSpacing), yStart + row * (level.BlockHeight + level.VerticalSpacing)),new Vec2(0,0));
                    stoneManager.stones.Add(stone);
                }
            }
        }

        void Init()
        {
            _wWidth = 1000;
            _wHeight = 1000;
            _frames = 60;

            _window = new RenderWindow(new VideoMode(_wWidth, _wHeight), "SFML GameTEst", Styles.Default);
            _window.SetFramerateLimit(_frames);
            _window.KeyPressed += new EventHandler<KeyEventArgs>(OnKeyPressed);
            _window.KeyReleased += new EventHandler<KeyEventArgs>(OnKeyRelease);
            _window.Closed += new EventHandler(OnClose);

            spawnplayer();
            spawnBall();
        }

        private void spawnBall()
        {
            Ball ball = new Ball(10, Color.White);
            ball.transform = new Components.Transform(new Vec2(_wWidth / 2 - 10 , Player.PlayerStone.Position.Y - Player.PlayerStone.Size.Y - 10),new Vec2(5,5));
            ball.circle.Position = new Vector2f(ball.transform.pos.x, ball.transform.pos.x);
            Ball = ball;
        }

        private void spawnplayer()
        {
            PlayerShape playerShape = new PlayerShape(new Vector2f(60, 10), Color.Green);
            playerShape.Transform = new Components.Transform(new Vec2(_wWidth / 2 - playerShape.PlayerStone.Size.X / 2, _wHeight - playerShape.PlayerStone.Size.Y - 5), new Vec2(5,5));
            playerShape.Input = new Components.Input();
            
            Player = playerShape;
        }
        void Movement()
        {
            Player.Transform.velocity = new Vec2(0, 0);

            if (Player.Input.left  /*Player.Transform.pos.x - Player.Collision.size > 0*/)
            { Player.Transform.velocity.x = -10.0f; }

            if (Player.Input.right  /*Player.Transform.pos.X < 1280 - Player.CCollision.*/)
            { Player.Transform.velocity.x = 10.0f; }

            Player.Transform.pos.x += Player.Transform.velocity.x;
            Player.Transform.pos.y += 0;

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
            foreach (Stone stone in stoneManager.stones)
            {
                if (Components.Collision.CheckCollision(Ball.transform.pos, Ball.collision.raduis, stone.Transform.pos, stone.Collision.size))
                {

                }
            }
        }

        private void Render()
        {
            _window.Clear();
            Player.PlayerStone.Position = new Vector2f(Player.Transform.pos.x, Player.Transform.pos.y);
            _window.Draw(Player.PlayerStone);
            _window.Draw(Ball.circle);

            foreach (Stone stone in stoneManager.stones) 
            {
                stone.StoneShape.Position = new Vector2f(stone.Transform.pos.x, stone.Transform.pos.y);
                _window.Draw(stone.StoneShape);
            }    

            _window.Display();
        }

        public void Run()
        {
            while (_isRunning)
            {



                Movement();
                UserInput();
                Render();


            }
        }

        
    }

    
}
