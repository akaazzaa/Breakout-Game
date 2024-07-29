using InstilledBee.SFML.SimpleCollision;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using Spiel.Assets.src.System;


namespace Spiel.Assets.src.Model
{
    public class Game
    {
        RenderWindow window;
        uint _frames;
        uint _wWidth, _wHeight;
        bool _isRunning = true;
        Entity Player;
        Entity Ball;
        Sprite background;
        Entity TestStone;
        EntityManager EntityManager = new EntityManager();
        Text Text;

        public Game(RenderWindow window)
        {
            this.window = window;
            Text = new Text("Press Space to Start",new Font(ResourceLoader.Instance.FontLoder("Lemon Shake Shake.ttf")));
            Text.Position = new Vector2f(window.Size.X / 2 - 150, window.Size.Y - 150);
            Init();
        }
        public void CreateLevel(Level level)
        {
            //Konstanten für Skalierung und Fenstergröße
            const float SCALE_FACTOR = 2.0f;

            // Laden der Textur
            Texture texture = ResourceLoader.Instance.LoadTexture("big bricks\\bigBrickGreen.png");
            
            // Dynamische Berechnung der Blockgrößen basierend auf der Texturgröße
            float blockWidth = texture.Size.X * SCALE_FACTOR;
            float blockHeight = texture.Size.Y * SCALE_FACTOR;

            // Berechnungen für die Startkoordinaten
            float xStart = (_wWidth - (level.Columns * (blockWidth + level.HorizontalSpacing) - level.HorizontalSpacing)) / 2;
            float yStart = _wHeight / 3 - (level.Rows * (blockHeight + level.VerticalSpacing) - level.VerticalSpacing) / 2;

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
            Run();
        }
        void Init()
        {
            _wWidth = 1920;
            _wHeight = 1080;
            _frames = 60;

            
            window.SetFramerateLimit(_frames);
            window.KeyPressed += new EventHandler<KeyEventArgs>(OnKeyPressed);
            window.KeyReleased += new EventHandler<KeyEventArgs>(OnKeyRelease);
            window.Closed += new EventHandler(OnClose);

            background = new Sprite(new Texture(ResourceLoader.Instance.LoadTexture("Background\\Background.jpg")));

        }
        private void CreateBall()
        {
            Texture texture = new Texture(ResourceLoader.Instance.LoadTexture("Balls\\bigBallgrey.png"));
            CollisionTester.AddBitMask(texture);
            Entity ball = EntityManager.AddEntity("Ball");

            ball.Circle = new CircleShape(15);
            ball.Circle.Texture = texture;
            ball.Transform = new Components.Transform(new Vec2(_wWidth / 2 - ball.Circle.Radius , _wHeight - 70), new Vec2(0, 0));
            ball.Collision = new Components.Collision(ball.Circle.Texture.Size.X, ball.Circle.Texture.Size.Y);
            Ball = ball;
        }
        private void spawnplayer()
        {
            Texture texture = new Texture(ResourceLoader.Instance.LoadTexture("Paddels\\Orange\\PaddelsOrangeForm (1).png"));

            Entity player = EntityManager.AddEntity("Player");

            player.Rectangle = new RectangleShape(new Vector2f(texture.Size.X + 60, texture.Size.Y + 30));
            player.Rectangle.Texture = texture;

            player.Transform = new Components.Transform(new Vec2(_wWidth / 2 - player.Rectangle.Size.X / 2, _wHeight - 50), new Vec2(5, 5));
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
            if (Player.Input.right && Player.Transform.pos.x + Player.Collision.x * 3 < _wWidth)
            { Player.Transform.velocity.x = 10.0f; }

            //Movement hoch runter
            if (Player.Input.up)
            {
                Player.Transform.velocity.y = -10.0f;
            }

            if (Player.Input.down)
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
                //case Keyboard.Key.W:
                //    Player.Input.up = true;
                //    break;
                //case Keyboard.Key.S:
                //    Player.Input.down = true;
                //    break;
                case Keyboard.Key.D:
                    Player.Input.right = true;
                    break;
                    case Keyboard.Key.Space:
                    if (!Ball._Ismoving)
                        Ball._Ismoving = true;
                        
                    Ball.Transform.velocity = new Vec2(6, -6);
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
                //case Keyboard.Key.W:
                //    Player.Input.up = false;
                //    break;
                //case Keyboard.Key.S:
                //    Player.Input.down = false;
                //    break;
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
            window.DispatchEvents();
        }
        void Collision()
        {

            if (EntityManager.entitiesByTag.ContainsKey("Stone"))
            {
                foreach (Entity stone in EntityManager.GetEntitiesByTag("Stone"))
                {
                    switch (src.Components.Collision.CheckCollision(Ball.Circle, stone.Rectangle))
                    {
                        //No hit 
                        case 0:
                            Console.WriteLine("no hit");
                            break;
                        // hit left or right 
                        case 1:
                            Console.WriteLine("left right");
                            stone.Hit();
                            Ball.Transform.velocity.x = -Ball.Transform.velocity.x;
                            break;
                        // hit top or bottm
                        case 2:
                            Console.WriteLine("top bottom");
                            Ball.Transform.velocity.y = -Ball.Transform.velocity.y;
                            stone.Hit();
                            break;
                        // hit Corner
                        case 3:
                            Console.WriteLine("corner");
                            stone.Hit();
                            Ball.Transform.velocity.x = -Ball.Transform.velocity.x;
                            Ball.Transform.velocity.y = -Ball.Transform.velocity.y;
                            break;

                    }
                }
            }

            switch (src.Components.Collision.CheckCollision(Ball.Circle, Player.Rectangle))
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
            window.Clear(Color.White);
            window.Draw(background);
           
            foreach (Entity entity in EntityManager.entities)
            {
                if (entity.Circle != null)
                {
                    entity.Circle.Position = new Vector2f(entity.Transform.pos.x, entity.Transform.pos.y);
                    window.Draw(entity.Circle);
                }
                else
                {
                    entity.Rectangle.Position = new Vector2f(entity.Transform.pos.x, entity.Transform.pos.y);
                    window.Draw(entity.Rectangle);
                }


            }
            if (!Ball._Ismoving)
            {
                window.Draw(Text);
            }
            
            window.Display();
        }
        public void Run()
        {
            while (_isRunning)
            {
                EntityManager.Update();
                
                UserInput();

                Movement();

                Render();

                Collision();

            }
        }


    }


}
