using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace PolygonEditor
{
    public enum EdgeConstraint
    {
        None,
        Vertical,
        Horizontal,
        ConstantLength,
        Bezier,
    }

    public class Edge
    {
        public Vertex start { get; set; }
        public Vertex end { get; set; }
        public EdgeConstraint constraint { get; set; }
        public BezierControlPoint? p1 { get; set; } = null;
        public BezierControlPoint? p2 { get; set; } = null;
        public int length =>
            (int)Math.Sqrt(Math.Pow(start.X - end.X, 2) + Math.Pow(start.Y - end.Y, 2));
        public int fixedLength = 0;

        public Edge(Vertex start, Vertex end)
        {
            this.start = start;
            this.end = end;
            start.edges.Add(this);
            end.edges.Add(this);
        }

        public Vertex OtherVertex(Vertex v)
        {
            return v == start ? end : start;
        }

        public BezierControlPoint? AdjacentControlPoint(Vertex v)
        {
            if (v != end && v != start)
                return null;
            return v == end ? p2 : p1;
        }

        public BezierControlPoint otherControlPoint(BezierControlPoint cp)
        {
            return cp == p1 ? p2 : p1;
        }

        public bool IsPointNearEdge(Point P, int threshold = 5)
        {
            int x1 = start.X;
            int y1 = start.Y;
            int x2 = end.X;
            int y2 = end.Y;

            int px = P.X;
            int py = P.Y;

            int dx = x2 - x1;
            int dy = y2 - y1;
            int apx = px - x1;
            int apy = py - y1;

            double bottom = dx * dx + dy * dy;
            double t = (apx * dx + apy * dy) / bottom;

            t = Math.Max(0, Math.Min(1, t));

            double closestX = x1 + t * dx;
            double closestY = y1 + t * dy;

            double distSq = (closestX - px) * (closestX - px) + (closestY - py) * (closestY - py);

            return distSq < threshold * threshold;
        }

        public void MoveBezierIteratively(BezierControlPoint cp, int x, int y)
        {
            //public void MoveVertexIteratively(int newX, int newY, bool direction)
            //{
            //    X = newX;
            //    Y = newY;
            //    Vertex? prev = this;
            //    Vertex v = direction ? edges[0].OtherVertex(this) : edges[1].OtherVertex(this);
            //    Edge e = direction ? edges[0] : edges[1];
            //    while (v != this)
            //    {
            //        if (e.constraint == EdgeConstraint.Vertical)
            //        {
            //            v.X = prev.X;
            //        }
            //        else if (e.constraint == EdgeConstraint.Horizontal)
            //        {
            //            v.Y = prev.Y;
            //        }
            //        else if (e.constraint == EdgeConstraint.ConstantLength)
            //        {
            //            double angle = Math.Atan2(v.Y - prev.Y, v.X - prev.X);
            //            int vX = (int)(prev.X + e.fixedLength * Math.Cos(angle));
            //            int vY = (int)(prev.Y + e.fixedLength * Math.Sin(angle));
            //            v.X = vX;
            //            v.Y = vY;
            //        }
            //        if (e.constraint == EdgeConstraint.None || e.constraint == EdgeConstraint.Bezier)
            //        {
            //            return;
            //        }
            //        e = v.OtherEdge(e);
            //        prev = v;
            //        v = e.OtherVertex(v);
            //    }
            //}
            cp.X = x;
            cp.Y = y;
            Vertex closerVertex = cp == p1 ? start : end;
            if (closerVertex.constraint == VertexConstraint.G1)
            {
                Edge otherEdge = closerVertex.OtherEdge(this);
                if (otherEdge.constraint == EdgeConstraint.Bezier)
                {
                    BezierControlPoint b = otherEdge.AdjacentControlPoint(closerVertex);
                    int dx = cp.X - closerVertex.X;
                    int dy = cp.Y - closerVertex.Y;
                    b.X = (int)(closerVertex.X - 0.5 * dx);
                    b.Y = (int)(closerVertex.Y - 0.5 * dy);
                }
                else
                {
                    Vertex v = otherEdge.OtherVertex(closerVertex);
                    int dx = v.X - cp.X;
                    int dy = v.Y - cp.Y;
                    Form1.MoveVertexAPI(
                        closerVertex,
                        (int)(cp.X + 0.5 * dx),
                        (int)(cp.Y + 0.5 * dy)
                    );
                }
            }
        }
    }
}
