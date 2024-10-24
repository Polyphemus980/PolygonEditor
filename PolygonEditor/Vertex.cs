using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolygonEditor
{
    public class Vertex
    {
        public static int index = 0;
        public int self_index;
        public int X;
        public int Y;
        public List<Edge> edges = new List<Edge>();

        public Vertex(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Edge OtherEdge(Edge edge)
        {
            return edges[0] == edge ? edges[1] : edges[0];
        }

        public void MoveVertexIteratively(int newX, int newY, bool direction)
        {
            X = newX;
            Y = newY;
            Vertex? prev = this;
            Vertex v = direction ? edges[0].OtherVertex(this) : edges[1].OtherVertex(this);
            Edge e = direction ? edges[0] : edges[1];
            while (v != this)
            {
                if (e.isVertical)
                {
                    v.X = prev.X;
                }
                else if (e.isHorizontal)
                {
                    v.Y = prev.Y;
                }
                else if (e.isConstantLength)
                {
                    double angle = Math.Atan2(v.Y - prev.Y, v.X - prev.X);
                    int vX = (int)(prev.X + e.fixedLength * Math.Cos(angle));
                    int vY = (int)(prev.Y + e.fixedLength * Math.Sin(angle));
                    v.X = vX;
                    v.Y = vY;
                }
                else
                    return;
                e = v.OtherEdge(e);
                prev = v;
                v = e.OtherVertex(v);
            }
        }

        public bool isNear(Point mousePosition)
        {
            double squaredRadius =
                Math.Pow(X - mousePosition.X, 2) + Math.Pow(Y - mousePosition.Y, 2);
            return squaredRadius < 30;
        }
    }
}
