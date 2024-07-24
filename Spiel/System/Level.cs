using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spiel.System
{
    public class Level
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
        public float BlockWidth { get; set; }
        public float BlockHeight { get; set; }
        public float HorizontalSpacing { get; set; }
        public float VerticalSpacing { get; set; }
        public float XStart { get; set; }
        public float YStart { get; set; }

        public Level(int rows, int columns, float blockWidth, float blockHeight, float horizontalSpacing, float verticalSpacing, float xStart, float yStart)
        {
            Rows = rows;
            Columns = columns;
            BlockWidth = blockWidth;
            BlockHeight = blockHeight;
            HorizontalSpacing = horizontalSpacing;
            VerticalSpacing = verticalSpacing;
            XStart = xStart;
            YStart = yStart;
        }
    }
}
