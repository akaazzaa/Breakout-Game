
using Spiel.Model;

namespace Spiel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();

            float windowWidth = 1000;
            float windowHeight = 1000;

            Level level1 = new Level(5, 10, 40, 20, 5, 5,0,0);
            game.CreateLevel(level1, windowWidth, windowHeight);
            game.Run();


            Level level2 = new Level(10, 50, 40, 20, 5, 5, 0, 0);
            game.CreateLevel(level1, windowWidth, windowHeight);
            game.Run();

        }
    }
}
