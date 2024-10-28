using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PolygonEditor
{
    public partial class Form1 : Form
    {
        public Action<Point, Point, Graphics, Color> drawingMethod { get; set; }
        public Action<
            int,
            int,
            int,
            int,
            int,
            int,
            int,
            int,
            Graphics,
            Color
        > drawingBezierMethod { get; set; }

        private void DrawLineLibrary(Point start, Point end, Graphics g, Color color)
        {
            Pen pen = new Pen(color, 1);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.DrawLine(pen, start, end);
        }

        private void DrawBezierLibrary(
            int x1,
            int y1,
            int x2,
            int y2,
            int x3,
            int y3,
            int x4,
            int y4,
            Graphics g,
            Color color
        )
        {
            Pen pen = new Pen(color, 1);
            g.DrawBezier(pen, x1, y1, x2, y2, x3, y3, x4, y4);
        }

        private void DrawBezier(
            int x1,
            int y1,
            int x2,
            int y2,
            int x3,
            int y3,
            int x4,
            int y4,
            Graphics g,
            Color color
        )
        {
            Pen pen = new Pen(color, 1);
            double length = Math.Sqrt((x1 - x4) * (x1 - x4) + (y1 - y4) * (y1 - y4));
            int numberOfSteps = (int)(length * 2);
            float d = 1f / numberOfSteps;
            Vector2 A0 = new Vector2(x1, y1);
            Vector2 A1 = new Vector2(3 * (x2 - x1), 3 * (y2 - y1));
            Vector2 A2 = new Vector2(3 * (x3 - 2 * x2 + x1), 3 * (y3 - 2 * y2 + y1));
            Vector2 A3 = new Vector2(x4 - 3 * x3 + 3 * x2 - x1, y4 - 3 * y3 + 3 * y2 - y1);
            List<Point> bezierPoints = new List<Point>();

            Vector2 currentPoint = A0;
            Vector2 deltaP = A3 * d * d * d + A2 * d * d + A1 * d;
            Vector2 deltaP2 = 6 * A3 * d * d * d + 2 * A2 * d * d;
            Vector2 deltaP3 = 6 * A3 * d * d * d;

            for (int i = 0; i < numberOfSteps; i++)
            {
                bezierPoints.Add(new Point((int)currentPoint.X, (int)currentPoint.Y));
                currentPoint = currentPoint + deltaP;
                deltaP = deltaP + deltaP2;
                deltaP2 = deltaP2 + deltaP3;
            }
            bezierPoints.Add(new Point((int)currentPoint.X, (int)currentPoint.Y));
            for (int i = 0; i < bezierPoints.Count - 1; i++)
            {
                drawLineBerenham(bezierPoints[i], bezierPoints[i + 1], g, color);
            }
        }

        private void drawLineBerenham(Point start, Point end, Graphics g, Color color)
        {
            Brush brush = new SolidBrush(color);
            int x0 = start.X;
            int y0 = start.Y;
            int x1 = end.X;
            int y1 = end.Y;
            int dx = Math.Abs(x1 - x0);
            int dy = Math.Abs(y1 - y0);
            int stepX = x0 < x1 ? 1 : -1;
            int stepY = y0 < y1 ? 1 : -1;
            if (dx > dy)
            {
                int err = dx / 2;
                while (x0 != x1)
                {
                    g.FillRectangle(brush, new Rectangle(x0, y0, 1, 1));
                    x0 += stepX;
                    err -= dy;
                    if (err < 0)
                    {
                        y0 += stepY;
                        err += dx;
                    }
                }
            }
            else
            {
                int err = dy / 2;
                while (y0 != y1)
                {
                    g.FillRectangle(brush, new Rectangle(x0, y0, 1, 1));
                    y0 += stepY;
                    err -= dx;
                    if (err < 0)
                    {
                        x0 += stepX;
                        err += dy;
                    }
                }
            }
            g.FillRectangle(brush, new Rectangle(x0, y0, 1, 1));
        }

        private void displayConstraintsEdge(Edge e, PaintEventArgs p)
        {
            int midpointX = (int)(e.start.X + e.end.X) / 2;
            int midpointY = (int)(e.start.Y + e.end.Y) / 2;
            Font font = new Font("Arial", 8);
            Brush brush = Brushes.White;
            string lengthText = e.length.ToString("0.00");
            if (e.constraint == EdgeConstraint.Vertical)
                lengthText += "V";
            else if (e.constraint == EdgeConstraint.Horizontal)
                lengthText += "H";
            else if (e.constraint == EdgeConstraint.ConstantLength)
                lengthText += "C";
            p.Graphics.DrawString(lengthText, font, brush, new Point(midpointX, midpointY));
        }

        private void displayConstraintsVertex(Vertex v, PaintEventArgs p)
        {
            Font font = new Font("Arial", 8);
            Brush brush = Brushes.White;
            string text = "";
            if (v.constraint == VertexConstraint.G0)
            {
                text = "G0";
            }
            else if (v.constraint == VertexConstraint.G1)
            {
                text = "G1";
            }
            else if (v.constraint == VertexConstraint.C1)
            {
                text = "C1";
            }
            p.Graphics.DrawString(text, font, brush, new Point((int)v.X + 5, (int)v.Y + 5));
        }

        private void ConnectBezier(Edge e, Graphics g)
        {
            Pen pen = new Pen(Color.Azure);
            pen.DashStyle = DashStyle.Custom;
            pen.DashPattern = new float[] { 5, 10 };
            g.DrawLine(
                pen,
                new Point((int)e.start.X, (int)e.start.Y),
                new Point((int)e.end.X, (int)e.end.Y)
            );
            g.DrawLine(
                pen,
                new Point((int)e.p2.X, (int)e.p2.Y),
                new Point((int)e.p1.X, (int)e.p1.Y)
            );
            g.DrawLine(
                pen,
                new Point((int)e.start.X, (int)e.start.Y),
                new Point((int)e.p1.X, (int)e.p1.Y)
            );
            g.DrawLine(
                pen,
                new Point((int)e.end.X, (int)e.end.Y),
                new Point((int)e.p2.X, (int)e.p2.Y)
            );
        }

        private void EditingPanel_Paint(object sender, PaintEventArgs e)
        {
            foreach (var edge in edges)
            {
                Color drawingColor = (selectedEdge == edge) ? Color.Red : Color.Green;
                if (edge.constraint != EdgeConstraint.Bezier)
                {
                    drawingMethod(
                        new Point((int)edge.start.X, (int)edge.start.Y),
                        new Point((int)edge.end.X, (int)edge.end.Y),
                        e.Graphics,
                        drawingColor
                    );
                }
                else
                {
                    drawingBezierMethod(
                        (int)edge.start.X,
                        (int)edge.start.Y,
                        (int)edge.p1.X,
                        (int)edge.p1.Y,
                        (int)edge.p2.X,
                        (int)edge.p2.Y,
                        (int)edge.end.X,
                        (int)edge.end.Y,
                        e.Graphics,
                        drawingColor
                    );
                }
                if (edge.constraint != EdgeConstraint.Bezier)
                    displayConstraintsEdge(edge, e);
                if (edge.p1 != null && edge.p2 != null)
                {
                    int radius = 5;
                    e.Graphics.FillEllipse(
                        Brushes.Pink,
                        (int)edge.p1.X - radius,
                        (int)edge.p1.Y - radius,
                        2 * radius,
                        2 * radius
                    );
                    e.Graphics.DrawString(
                        "p1",
                        new Font("Arial", 8),
                        Brushes.Azure,
                        new Point((int)edge.p1.X, (int)edge.p1.Y)
                    );
                    e.Graphics.FillEllipse(
                        Brushes.Pink,
                        (int)edge.p2.X - radius,
                        (int)edge.p2.Y - radius,
                        2 * radius,
                        2 * radius
                    );
                    e.Graphics.DrawString(
                        "p2",
                        new Font("Arial", 8),
                        Brushes.Azure,
                        new Point((int)edge.p2.X, (int)edge.p2.Y)
                    );
                    ConnectBezier(edge, e.Graphics);
                }
            }
            foreach (var vertex in vertices)
            {
                int radius = 5;
                e.Graphics.FillEllipse(
                    Brushes.Red,
                    (int)vertex.X - radius,
                    (int)vertex.Y - radius,
                    2 * radius,
                    2 * radius
                );
                displayConstraintsVertex(vertex, e);
            }
        }
    }
}
