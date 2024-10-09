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
        public bool IsPointNearEdge(Point p)
        {
            Point start = this.start.position;
            Point end = this.end.position;

            double distance = DistanceFromPointToLine(p, start, end);
            return distance <= 10;
        }

        private double DistanceFromPointToLine(Point p, Point start, Point end)
        {
            double numerator = Math.Abs((end.Y - start.Y) * p.X - (end.X - start.X) * p.Y + end.X * start.Y - end.Y * start.X);
            double denominator = Math.Sqrt(Math.Pow(end.Y - start.Y, 2) + Math.Pow(end.X - start.X, 2));
          
            return numerator / denominator;
           
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
