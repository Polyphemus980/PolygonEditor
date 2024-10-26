using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolygonEditor
{
    public enum VertexConstraint
    {
        G0,
        G1,
        C1,
    }

    public class Vertex
    {
        public static int index = 0;
        public int self_index;
        public int X;
        public int Y;
        public List<Edge> edges = new List<Edge>();
        public VertexConstraint constraint;

        public Vertex(int x, int y)
        {
            constraint = VertexConstraint.G0;
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
                if (e.constraint == EdgeConstraint.Vertical)
                {
                    v.X = prev.X;
                }
                else if (e.constraint == EdgeConstraint.Horizontal)
                {
                    v.Y = prev.Y;
                }
                else if (e.constraint == EdgeConstraint.ConstantLength)
                {
                    double angle = Math.Atan2(v.Y - prev.Y, v.X - prev.X);
                    int vX = (int)(prev.X + e.fixedLength * Math.Cos(angle));
                    int vY = (int)(prev.Y + e.fixedLength * Math.Sin(angle));
                    v.X = vX;
                    v.Y = vY;
                }
                if (prev.constraint == VertexConstraint.G1)
                {
                    Edge other = OtherEdge(e);
                    if (other.p1 == null || other.p2 == null)
                        return;
                    BezierControlPoint adjustedPoint = other.p1;
                    //Distance(X, Y, other.p1.X, other.p1.Y)
                    //> Distance(X, Y, other.p2.X, other.p2.Y)
                    //    ? other.p2
                    //    : other.p1;
                    int dx = v.X - prev.X;
                    int dy = v.Y - prev.Y;
                    adjustedPoint.X = (int)(prev.X - dx);
                    adjustedPoint.Y = (int)(prev.Y - dy);
                }
                if (e.constraint == EdgeConstraint.None)
                {
                    return;
                }
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

        public static double Distance(int posX, int posY, int x1, int y1)
        {
            return Math.Sqrt(Math.Pow(posX - x1, 2) + Math.Pow(posY - y1, 2));
        }
    }
}
