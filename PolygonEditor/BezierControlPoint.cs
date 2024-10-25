using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolygonEditor
{
    public class BezierControlPoint
    {
        public int X { get; set; }
        public int Y { get; set; }

        public BezierControlPoint(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}
