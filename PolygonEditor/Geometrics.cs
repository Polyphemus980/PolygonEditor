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
    public class Edge
    {
        public Vertex start { get; set; }
        public Vertex end { get; set; }
        public bool isVertical { get; set; }
        public bool isHorizontal { get; set; }
        public bool isConstantLength { get; set; }

        public int length => (int)Math.Sqrt(Math.Pow(start.X - end.X,2) + Math.Pow(start.Y - end.Y,2));
        public int fixedLength = 0;
        public bool hasConstraint => isVertical || isHorizontal || isConstantLength;

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
        private double DistanceFromPointToLine(Point p, Point start, Point end)
        {
            double numerator = Math.Abs((end.Y - start.Y) * p.X - (end.X - start.X) * p.Y + end.X * start.Y - end.Y * start.X);
            double denominator = Math.Sqrt(Math.Pow(end.Y - start.Y, 2) + Math.Pow(end.X - start.X, 2));
          
            return numerator / denominator;
           
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
    }
    public class  Vertex
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

        public void MoveVertex(int newX, int newY,Edge? comingEdge = null, List<Vertex>? visitedVertices = null)
        { 
            visitedVertices ??= new List<Vertex>();
            if (visitedVertices.Contains(this)) 
                return;
            visitedVertices.Add(this);
            foreach (Edge e in edges)
            {
                if (e == comingEdge)
                    continue;
                Vertex v = e.OtherVertex(this);
                if (e.isVertical)
                {
                    v.X = newX;
                    v.MoveVertex(newX, v.Y,e, visitedVertices);
                }
                else if (e.isHorizontal)
                {
                    v.Y = newY;
                    v.MoveVertex(v.X, newY,e, visitedVertices);
                }
                else if (e.isConstantLength)
                {
                    double angle = Math.Atan2(v.Y - Y, v.X - X);
                    int vX = (int)(X + e.fixedLength * Math.Cos(angle));
                    int vY = (int)(Y + e.fixedLength * Math.Sin(angle));
                    v.X = vX;
                    v.Y = vY;  
                    v.MoveVertex(vX,vY,e,visitedVertices);
                }
            }
        }
        public void SwappedMoveVertex(int newX, int newY, List<Vertex> visitedVertices = null)
        {
            visitedVertices ??= new List<Vertex>();
            if (visitedVertices.Contains(this))
                return;
            visitedVertices.Add(this);
            Edge e = edges[1];
            Vertex v = e.OtherVertex(this);
            if (e.isVertical)
            {
                v.X = newX;
                v.MoveVertex(newX, v.Y, e,visitedVertices);
            }
            else if (e.isHorizontal)
            {
                v.Y = newY;
                v.MoveVertex(v.X, newY,e, visitedVertices);
            }
            else if (e.isConstantLength)
            {
                double angle = Math.Atan2(v.Y - Y, v.X - X);
                int vX = (int)(X + e.fixedLength * Math.Cos(angle));
                int vY = (int)(Y + e.fixedLength * Math.Sin(angle));
                v.X = vX;
                v.Y = vY;
                v.MoveVertex(vX, vY,e, visitedVertices);
            }
        }
        public bool isNear(Point mousePosition)
        {
            
            double squaredRadius = Math.Pow(X - mousePosition.X, 2) + Math.Pow(Y - mousePosition.Y, 2);
            return squaredRadius < 30;
        }

        
        
       

    }

}
