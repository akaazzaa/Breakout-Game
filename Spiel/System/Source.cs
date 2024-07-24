using Spiel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Spiel.System
{
    public class Source
    {
        public static Dictionary<string, string> smallBricks = new Dictionary<string, string>()
        {
            {"smallGreenBrick","C:\\Users\\dgami\\source\\repos\\Spiel\\Spiel\\Sprites\\small bricks\\Green\\smallBricksGreen.png"},
            {"smallGreenBrickHit","C:\\Users\\dgami\\source\\repos\\Spiel\\Spiel\\Sprites\\small bricks\\Green\\smallBricksGreenHit.png"},

            {"smallOrangeBrick", "C:\\Users\\dgami\\source\\repos\\Spiel\\Spiel\\Sprites\\small bricks\\Orange\\smallBricksOrange.png"},
            {"smallOrangeBrickHit", "C:\\Users\\dgami\\source\\repos\\Spiel\\Spiel\\Sprites\\small bricks\\Orange\\smallBricksOrange Hit.png"},

            {"smallRedBrick","C:\\Users\\dgami\\source\\repos\\Spiel\\Spiel\\Sprites\\small bricks\\Red\\smallBricksRed.png"},
            {"smallRedBrickHit", "C:\\Users\\dgami\\source\\repos\\Spiel\\Spiel\\Sprites\\small bricks\\Red\\smallBricksRedHi.png"},

            {"smallSilverBrick","C:\\Users\\dgami\\source\\repos\\Spiel\\Spiel\\Sprites\\small bricks\\Silver\\smallBricksSilver.png" },
            {"smallSilverBrickHit","C:\\Users\\dgami\\source\\repos\\Spiel\\Spiel\\Sprites\\small bricks\\Silver\\smallBricksSilverHit.png" },

            {"smallYellowBrick","C:\\Users\\dgami\\source\\repos\\Spiel\\Spielvsmall bricks\\Yellow\\smallBricksYellow.png" },
            {"smallYwllowBrickHit","C:\\Users\\dgami\\source\\repos\\Spiel\\Spiel\\Sprites\\small bricks\\Yellow\\smallBricksYellowHit.png"}

        };
        public static Dictionary<string, string> mediumBricks = new Dictionary<string, string>()
        {
            {"mediumgGreenBrick","C:\\Users\\dgami\\source\\repos\\Spiel\\Spiel\\Sprites\\medium bricks\\mediumBrickGreen.png" },
            {"mediumgGreenBrickHit1","C:\\Users\\dgami\\source\\repos\\Spiel\\Spiel\\Sprites\\medium bricks\\mediumBrickGreenHit1.png" },
            {"mediumgGreenBrickHit2","C:\\Users\\dgami\\source\\repos\\Spiel\\Spiel\\Sprites\\medium bricks\\mediumBrickGreenHit2.png" },

            {"mediumgOrangeBrick","C:\\Users\\dgami\\source\\repos\\Spiel\\Spiel\\Sprites\\medium bricks\\mediumBrickOrange.png" },
            {"mediumgOrangeBrickHit1","C:\\Users\\dgami\\source\\repos\\Spiel\\Spiel\\Sprites\\medium bricks\\mediumBrickOrangeHit1.png" },
            {"mediumgOrangeBrickhit2","C:\\Users\\dgami\\source\\repos\\Spiel\\Spiel\\Sprites\\medium bricks\\mediumBrickOrangeHit2.png" },

            {"mediumgRedBrick","C:\\Users\\dgami\\source\\repos\\Spiel\\Spiel\\Sprites\\medium bricks\\mediumBrickRed.png" },
            {"mediumgRedBrickHit1","C:\\Users\\dgami\\source\\repos\\Spiel\\Spiel\\Sprites\\medium bricks\\mediumBrickRedHit1.png" },
            {"mediumgRedBrickHit2","C:\\Users\\dgami\\source\\repos\\Spiel\\Spiel\\Sprites\\medium bricks\\mediumBrickRedHit2.png" },

            {"mediumgSilverBrick","C:\\Users\\dgami\\source\\repos\\Spiel\\Spiel\\Sprites\\medium bricks\\mediumBrickSilver.png" },
            {"mediumgSilverBrickHit1","C:\\Users\\dgami\\source\\repos\\Spiel\\Spiel\\Sprites\\medium bricks\\mediumBrickSilverHit1.png" },
            {"mediumgSilverBrickHit2","C:\\Users\\dgami\\source\\repos\\Spiel\\Spiel\\Sprites\\medium bricks\\mediumBrickSilverHit2.png" },

            {"mediumgYellowBrick","C:\\Users\\dgami\\source\\repos\\Spiel\\Spiel\\Sprites\\medium bricks\\mediumBrickYellow.png" },
            {"mediumgYellowBrickHit1","C:\\Users\\dgami\\source\\repos\\Spiel\\Spiel\\Sprites\\medium bricks\\mediumBrickYellowHit1.png" },
            {"mediumgYellowBrickHit2","C:\\Users\\dgami\\source\\repos\\Spiel\\Spiel\\Sprites\\medium bricks\\mediumBrickYellowHit2.png" }


        };
        public static Dictionary<string, string> bigBricks = new Dictionary<string, string>()
        {
            {"bigGreenBrick","C:\\Users\\dgami\\source\\repos\\Spiel\\Spiel\\Sprites\\big bricks\\bigBrickGreen.png" },
            {"bigGreenBrickHit1","C:\\Users\\dgami\\source\\repos\\Spiel\\Spiel\\Sprites\\big bricks\\bigBrickGreenHit1.png" },
            {"bigGreenBrickHit2","C:\\Users\\dgami\\source\\repos\\Spiel\\Spiel\\Sprites\\big bricks\\bigBrickGreenHit2.png" },

            {"bigOrangeBrick","C:\\Users\\dgami\\source\\repos\\Spiel\\Spiel\\Sprites\\big bricks\\bigBrickOrange.png" },
            {"bigOrangeBrickHit1","C:\\Users\\dgami\\source\\repos\\Spiel\\Spiel\\Sprites\\big bricks\\bigBrickOrangehit1.png" },
            {"bigOrangeBrickHit2","C:\\Users\\dgami\\source\\repos\\Spiel\\Spiel\\Sprites\\big bricks\\bigBrickOraangehit2.png" },

            {"bigRedBrick","C:\\Users\\dgami\\source\\repos\\Spiel\\Spiel\\Sprites\\big bricks\\bigBrickRed.png" },
            {"bigRedBrickHit1","C:\\Users\\dgami\\source\\repos\\Spiel\\Spiel\\Sprites\\big bricks\\bigBrickRedHit1.png" },
            {"bigRedBrickHit2","C:\\Users\\dgami\\source\\repos\\Spiel\\Spiel\\Sprites\\big bricks\\BigBrickRedHit2.png" },

            {"bigSilverBrick","C:\\Users\\dgami\\source\\repos\\Spiel\\Spiel\\Sprites\\big bricks\\bigBricksivler.png" },
            {"bigSilverBrickHit1","C:\\Users\\dgami\\source\\repos\\Spiel\\Spiel\\Sprites\\big bricks\\bigBricksilverhit1.png" },
            {"bigSilverBrickHit2","C:\\Users\\dgami\\source\\repos\\Spiel\\Spiel\\Sprites\\big bricks\\bigBricksilverhit2.png" },

            {"bigYellowBrick","C:\\Users\\dgami\\source\\repos\\Spiel\\Spiel\\Sprites\\big bricks\\bigBrickYellow.png" },
            {"bigYellowBrickHit1","C:\\Users\\dgami\\source\\repos\\Spiel\\Spiel\\Sprites\\big bricks\\bricksYellowHit1.png" },
            {"bigYellowBrickHit2","C:\\Users\\dgami\\source\\repos\\Spiel\\Spiel\\Sprites\\big bricks\\bigBrickYellowHit2.png" },
        };
        public static Dictionary<string, string> balls = new Dictionary<string, string>()
        {
            {"bigBallBraun","C:\\Users\\dgami\\source\\repos\\Spiel\\Spiel\\Sprites\\Balls\\bigBallbraun.png" },
            {"smallBallBraun","C:\\Users\\dgami\\source\\repos\\Spiel\\Spiel\\Sprites\\Balls\\smallBallbraun.png" },

            {"bigBallDunkelBraun","C:\\Users\\dgami\\source\\repos\\Spiel\\Spiel\\Sprites\\Balls\\bigBalldunkelbraun.png" },
            {"smallBallDunkelBraun","C:\\Users\\dgami\\source\\repos\\Spiel\\Spiel\\Sprites\\Balls\\smallBalldunkelbraun.png" },

            {"bigBallGrau","C:\\Users\\dgami\\source\\repos\\Spiel\\Spiel\\Sprites\\Balls\\bigBallgrey.png" },
            {"smallBallGrau","C:\\Users\\dgami\\source\\repos\\Spiel\\Spiel\\Sprites\\Balls\\smallBallgrey.png" }

        };
        public static Dictionary<string, string> hearts = new Dictionary<string, string>()
        {
            {"Full","C:\\Users\\dgami\\source\\repos\\Spiel\\Spiel\\Sprites\\hearts\\Full.png" },
            {"Half","C:\\Users\\dgami\\source\\repos\\Spiel\\Spiel\\Sprites\\hearts\\thirdhit.png" },
            {"Empty","C:\\Users\\dgami\\source\\repos\\Spiel\\Spiel\\Sprites\\hearts\\Empty.png" },

        };
        public static Dictionary<string, string> paddels = new Dictionary<string, string>()
        {

            {"OrangePaddelForm1","C:\\Users\\dgami\\source\\repos\\Spiel\\Spiel\\Sprites\\Paddels\\Orange\\PaddelsOrangeForm (1).png"},
            {"OrangePaddelForm2","C:\\Users\\dgami\\source\\repos\\Spiel\\Spiel\\Sprites\\Paddels\\Orange\\PaddelsOrangeForm (2).png"},
            {"OrangePaddelForm3","C:\\Users\\dgami\\source\\repos\\Spiel\\Spiel\\Sprites\\Paddels\\Orange\\PaddelsOrangeForm (3).png"},

            {"RedPaddelForm1","C:\\Users\\dgami\\source\\repos\\Spiel\\Spiel\\Sprites\\Paddels\\Red\\PaddelsRedForm (1).png"},
            {"RedPaddelForm2","C:\\Users\\dgami\\source\\repos\\Spiel\\Spiel\\Sprites\\Paddels\\Red\\PaddelsRedForm (2).png"},
            {"RedPaddelForm3","C:\\Users\\dgami\\source\\repos\\Spiel\\Spiel\\Sprites\\Paddels\\Red\\PaddelsRedForm (3).png"},

            {"SilverPaddelForm1","C:\\Users\\dgami\\source\\repos\\Spiel\\Spiel\\Sprites\\Paddels\\Silver\\PaddelsSilverForm (1).png"},
            {"SilverPaddelForm2","C:\\Users\\dgami\\source\\repos\\Spiel\\Spiel\\Sprites\\Paddels\\Silver\\PaddelsSilverForm (2).png"},
            {"SilverPaddelForm3","C:\\Users\\dgami\\source\\repos\\Spiel\\Spiel\\Sprites\\Paddels\\Silver\\PaddelsSilverForm (3).png"},

            {"YellowPaddelForm1","C:\\Users\\dgami\\source\\repos\\Spiel\\Spiel\\Sprites\\Paddels\\Yellow\\PaddelsYellwoForm (1).png"},
            {"YeellowPaddelForm2","C:\\Users\\dgami\\source\\repos\\Spiel\\Spiel\\Sprites\\Paddels\\Yellow\\PaddelsYellwoForm (2).png"},
            {"YellowPaddelForm3","C:\\Users\\dgami\\source\\repos\\Spiel\\Spiel\\Sprites\\Paddels\\Yellow\\PaddelsYellwoForm (3).png"},

        };
        public static Dictionary<int, string> background = new Dictionary<int, string>()
        {
            {0,"C:\\Users\\dgami\\source\\repos\\Spiel\\Spiel\\Sprites\\Background\\Backround_Tiles_0.png" },
            {1,"C:\\Users\\dgami\\source\\repos\\Spiel\\Spiel\\Sprites\\Background\\Backround_Tiles_1.png" },
            {2,"C:\\Users\\dgami\\source\\repos\\Spiel\\Spiel\\Sprites\\Background\\Backround_Tiles_2.png" },
            {3,"C:\\Users\\dgami\\source\\repos\\Spiel\\Spiel\\Sprites\\Background\\Backround_Tiles_3.png" },
            {4,"C:\\Users\\dgami\\source\\repos\\Spiel\\Spiel\\Sprites\\Background\\Backround_Tiles_4.png" },
            {5,"C:\\Users\\dgami\\source\\repos\\Spiel\\Spiel\\Sprites\\Background\\Backround_Tiles_5.png" },
            {6,"C:\\Users\\dgami\\source\\repos\\Spiel\\Spiel\\Sprites\\Background\\Backround_Tiles_6.png" },
            {7,"C:\\Users\\dgami\\source\\repos\\Spiel\\Spiel\\Sprites\\Background\\Backround_Tiles_7.png" },
        };

        public static string GetPath(string key, Dictionary<string, string> source)
        {

            return source[key];
            
        }
    }   


}
