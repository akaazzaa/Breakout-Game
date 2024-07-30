using SFML.Graphics;
using SFML.System;

namespace Spiel.Assets.src.Model
{
    internal class Life
    {
         private RectangleShape heart;
         private RectangleShape heart1;
         private RectangleShape heart2;
         private int failcounter = 3;
         public bool isGamOver = false;

        public Life(Vector2f size,Vector2f pos1, Vector2f pos2 , Vector2f pos3)
        {
            this.heart = new RectangleShape(size);
            this.heart.Texture = ResourceLoader.Instance.LoadTexture("hearts\\Full.png");
            heart.Position = pos1;

            heart1 = new RectangleShape(size);
            heart1.Texture = ResourceLoader.Instance.LoadTexture("hearts\\Full.png");
            heart1.Position = pos2 ;

            heart2 = new RectangleShape(size);
            heart2.Texture = ResourceLoader.Instance.LoadTexture("hearts\\Full.png");
            heart2.Position = pos3;
        }
        public Life()
        {
            this.heart = new RectangleShape(new Vector2f(30, 30));
            this.heart.Texture = ResourceLoader.Instance.LoadTexture("hearts\\Full.png");
            heart.Position = new Vector2f(20, 20);

            heart1 = new RectangleShape(new Vector2f(30, 30));
            heart1.Texture = ResourceLoader.Instance.LoadTexture("hearts\\Full.png");
            heart1.Position = new Vector2f(60, 20);

            heart2 = new RectangleShape(new Vector2f(30, 30));
            heart2.Texture = ResourceLoader.Instance.LoadTexture("hearts\\Full.png");
            heart2.Position = new Vector2f(100, 20);
        }

        public void Fail()
        {
            failcounter--;
            if (failcounter == 2) 
            {
                heart2.Texture = ResourceLoader.Instance.LoadTexture("hearts\\Empty.png");
            }else if (failcounter == 1)
            {
                heart1.Texture = ResourceLoader.Instance.LoadTexture("hearts\\Empty.png");
            }else if (failcounter == 0)
            {
                heart.Texture = ResourceLoader.Instance.LoadTexture("hearts\\Empty.png");
                GameOver();
            }

        }

        private void GameOver()
        {
            isGamOver = true;
        }

        public void Draw(RenderWindow window)
        {
            window.Draw(heart);
            window.Draw(heart1);
            window.Draw(heart2);
        }
    }
}
