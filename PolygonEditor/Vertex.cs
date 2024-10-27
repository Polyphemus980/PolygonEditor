using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PolygonEditor
{
    public enum VertexConstraint
    {
        None,
        G0,
        G1,
        C1,
    }

    public class Vertex
    {
        public static int index = 0;
        public int self_index;
        public double X;
        public double Y;
        public List<Edge> edges = new List<Edge>();
        public VertexConstraint constraint;

        public Vertex(double x, double y)
        {
            constraint = VertexConstraint.None;
            X = x;
            Y = y;
        }

        public Edge OtherEdge(Edge edge)
        {
            return edges[0] == edge ? edges[1] : edges[0];
        }

        public void MoveVertexIteratively(double newX, double newY, bool direction)
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
                    double vX = prev.X + e.fixedLength * Math.Cos(angle);
                    double vY = prev.Y + e.fixedLength * Math.Sin(angle);
                    v.X = vX;
                    v.Y = vY;
                }
                if (e.constraint == EdgeConstraint.None || e.constraint == EdgeConstraint.Bezier)
                {
                    return;
                }
                e = v.OtherEdge(e);
                prev = v;
                v = e.OtherVertex(v);
            }
        }

        public void MoveBeziersIteratively(bool direction)
        {
            Vertex? prev = this;
            Vertex v = direction ? edges[0].OtherVertex(this) : edges[1].OtherVertex(this);
            Edge e = direction ? edges[0] : edges[1];
            while (v != this)
            {
                if (prev.constraint == VertexConstraint.G1)
                {
                    Edge previousEdge = prev.OtherEdge(e);
                    if (previousEdge.constraint == EdgeConstraint.Bezier)
                    {
                        BezierControlPoint? adjustedPoint = previousEdge.AdjacentControlPoint(prev);
                        if (adjustedPoint != null)
                        {
                            double dx = v.X - prev.X;
                            double dy = v.Y - prev.Y;
                            Vector2 normalizedVector = Vector2.Normalize(
                                new Vector2((float)dx, (float)dy)
                            );
                            double distance = Vector2.Distance(
                                new Vector2((float)prev.X, (float)prev.Y),
                                new Vector2((float)adjustedPoint.X, (float)adjustedPoint.Y)
                            );
                            adjustedPoint.X = prev.X - distance * normalizedVector.X;
                            adjustedPoint.Y = prev.Y - distance * normalizedVector.Y;
                        }
                        if (
                            e.constraint == EdgeConstraint.Bezier
                            && previousEdge.constraint == EdgeConstraint.Bezier
                        )
                        {
                            BezierControlPoint? adjustedPoint2 = e.AdjacentControlPoint(prev);
                            if (adjustedPoint2 != null)
                            {
                                double dx = adjustedPoint.X - prev.X;
                                double dy = adjustedPoint.Y - prev.Y;
                                Vector2 normalizedVector = Vector2.Normalize(
                                    new Vector2((float)dx, (float)dy)
                                );
                                double distance = Vector2.Distance(
                                    new Vector2((float)prev.X, (float)prev.Y),
                                    new Vector2((float)adjustedPoint2.X, (float)adjustedPoint2.Y)
                                );
                                adjustedPoint2.X = prev.X - distance * normalizedVector.X;
                                adjustedPoint2.Y = prev.Y - distance * normalizedVector.Y;
                            }
                        }
                    }
                }
                else if (prev.constraint == VertexConstraint.C1)
                {
                    Edge previousEdge = prev.OtherEdge(e);
                    if (previousEdge.constraint == EdgeConstraint.Bezier)
                    {
                        BezierControlPoint? adjustedPoint = previousEdge.AdjacentControlPoint(prev);
                        if (adjustedPoint != null)
                        {
                            double dx = v.X - prev.X;
                            double dy = v.Y - prev.Y;
                            adjustedPoint.X = (int)(prev.X - 0.33 * dx);
                            adjustedPoint.Y = (int)(prev.Y - 0.33 * dy);
                        }
                        if (
                            e.constraint == EdgeConstraint.Bezier
                            && previousEdge.constraint == EdgeConstraint.Bezier
                        )
                        {
                            BezierControlPoint? adjustedPoint2 = e.AdjacentControlPoint(prev);
                            if (adjustedPoint2 != null)
                            {
                                double dx = adjustedPoint.X - prev.X;
                                double dy = adjustedPoint.Y - prev.Y;
                                adjustedPoint2.X = prev.X - dx;
                                adjustedPoint2.Y = prev.Y - dy;
                            }
                        }
                    }
                }
                e = v.OtherEdge(e);
                prev = v;
                v = e.OtherVertex(v);
            }
            if (prev.constraint == VertexConstraint.G1)
            {
                Edge previousEdge = prev.OtherEdge(e);
                if (previousEdge.constraint == EdgeConstraint.Bezier)
                {
                    BezierControlPoint? adjustedPoint = previousEdge.AdjacentControlPoint(prev);
                    if (adjustedPoint != null)
                    {
                        double dx = v.X - prev.X;
                        double dy = v.Y - prev.Y;
                        Vector2 normalizedVector = Vector2.Normalize(
                            new Vector2((float)dx, (float)dy)
                        );
                        double distance = Vector2.Distance(
                            new Vector2((float)prev.X, (float)prev.Y),
                            new Vector2((float)adjustedPoint.X, (float)adjustedPoint.Y)
                        );
                        adjustedPoint.X = prev.X - distance * normalizedVector.X;
                        adjustedPoint.Y = prev.Y - distance * normalizedVector.Y;
                    }
                    if (
                        e.constraint == EdgeConstraint.Bezier
                        && previousEdge.constraint == EdgeConstraint.Bezier
                    )
                    {
                        BezierControlPoint? adjustedPoint2 = e.AdjacentControlPoint(prev);
                        if (adjustedPoint2 != null)
                        {
                            double dx = adjustedPoint.X - prev.X;
                            double dy = adjustedPoint.Y - prev.Y;
                            Vector2 normalizedVector = Vector2.Normalize(
                                new Vector2((float)dx, (float)dy)
                            );
                            double distance = Vector2.Distance(
                                new Vector2((float)prev.X, (float)prev.Y),
                                new Vector2((float)adjustedPoint2.X, (float)adjustedPoint2.Y)
                            );
                            adjustedPoint2.X = prev.X - distance * normalizedVector.X;
                            adjustedPoint2.Y = prev.Y - distance * normalizedVector.Y;
                        }
                    }
                }
            }
            if (prev.constraint == VertexConstraint.C1)
            {
                Edge previousEdge = prev.OtherEdge(e);
                if (previousEdge.constraint == EdgeConstraint.Bezier)
                {
                    BezierControlPoint? adjustedPoint = previousEdge.AdjacentControlPoint(prev);
                    if (adjustedPoint != null)
                    {
                        double dx = v.X - prev.X;
                        double dy = v.Y - prev.Y;
                        adjustedPoint.X = (int)(prev.X - 0.33 * dx);
                        adjustedPoint.Y = (int)(prev.Y - 0.33 * dy);
                    }
                    if (
                        e.constraint == EdgeConstraint.Bezier
                        && previousEdge.constraint == EdgeConstraint.Bezier
                    )
                    {
                        BezierControlPoint? adjustedPoint2 = e.AdjacentControlPoint(prev);
                        if (adjustedPoint2 != null)
                        {
                            double dx = adjustedPoint.X - prev.X;
                            double dy = adjustedPoint.Y - prev.Y;
                            adjustedPoint2.X = (int)(prev.X - dx);
                            adjustedPoint2.Y = (int)(prev.Y - dy);
                        }
                    }
                }
            }
        }

        bool areColinear(BezierControlPoint b1, BezierControlPoint b2)
        {
            double pX = X;
            double pY = Y;
            return (pY - b1.Y) * (b2.X - b1.X) == (pX - b1.X) * (b2.Y - b1.Y);
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
