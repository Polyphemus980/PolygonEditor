using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolygonEditor
{
    public class BezierControlPoint
    {
        public double X { get; set; }
        public double Y { get; set; }

        public BezierControlPoint(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}
