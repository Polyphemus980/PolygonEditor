using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
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
            else if (closerVertex.constraint == VertexConstraint.C1)
            {
                Edge otherEdge = closerVertex.OtherEdge(this);
                if (otherEdge.constraint == EdgeConstraint.Bezier)
                {
                    BezierControlPoint b = otherEdge.AdjacentControlPoint(closerVertex);
                    int dx = cp.X - closerVertex.X;
                    int dy = cp.Y - closerVertex.Y;
                    b.X = (int)(closerVertex.X - dx);
                    b.Y = (int)(closerVertex.Y - dy);
                }
                else
                {
                    Vertex v = otherEdge.OtherVertex(closerVertex);
                    int dx = v.X - cp.X;
                    int dy = v.Y - cp.Y;
                    Form1.MoveVertexAPI(
                        closerVertex,
                        (int)(cp.X + 0.33 * dx),
                        (int)(cp.Y + 0.33 * dy)
                    );
                }
            }
        }
    }
}
