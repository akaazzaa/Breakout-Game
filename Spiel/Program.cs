using Spiel.System;

namespace Spiel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();

            // 1: Rows , 1: Column ,
            Level level1 = new Level(13, 15, 0, 0, 40, 20,0,0);
            game.CreateLevel(level1);
            game.Run();


            Level level2 = new Level(10, 50, 40, 20, 5, 5, 0, 0);
            game.CreateLevel(level2);
            game.Run();

        }
    }
}
