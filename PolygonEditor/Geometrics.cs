using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolygonEditor
{
    public class Edge
    {
        public Vertex start;
        public Vertex end;

       public Edge(Vertex start, Vertex end)
        {
            this.start = start;
            this.end = end;
        }


        private double DistanceFromPointToLine(Point p, Point start, Point end)
        {
            double numerator = Math.Abs((end.Y - start.Y) * p.X - (end.X - start.X) * p.Y + end.X * start.Y - end.Y * start.X);
            double denominator = Math.Sqrt(Math.Pow(end.Y - start.Y, 2) + Math.Pow(end.X - start.X, 2));
          
            return numerator / denominator;
           
        }
        public bool IsPointNearEdge(Point P, int threshold = 5)
        {
            int x1 = start.position.X;
            int y1 = start.position.Y;
            int x2 = end.position.X;
            int y2 = end.position.Y;

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
        public Point position;

        public Vertex(int x, int y)
        {
            position = new Point(x, y);
        }

        public bool isNear(Point mousePosition)
        {
            
            double radius = Math.Pow(position.X - mousePosition.X, 2) + Math.Pow(position.Y - mousePosition.Y, 2);
            return radius < 30;
        }
    }

}
