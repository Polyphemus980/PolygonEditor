using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolygonEditor
{
    partial class Form1 : Form
    {
        public Action<Point, Point, Graphics, Color> drawingMethod { get; set; }

        private void DrawLineLibrary(Point start, Point end, Graphics g, Color color)
        {
            Pen pen = new Pen(color, 5);
            g.DrawLine(pen, start, end);
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

        private void WriteConstraints(Edge e, PaintEventArgs p)
        {
            int midpointX = (e.start.X + e.end.X) / 2;
            int midpointY = (e.start.Y + e.end.Y) / 2;
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

        private void EditingPanel_Paint(object sender, PaintEventArgs e)
        {
            foreach (var edge in edges)
            {
                Color drawingColor = (selectedEdge == edge) ? Color.Red : Color.Green;
                drawingMethod(
                    new Point(edge.start.X, edge.start.Y),
                    new Point(edge.end.X, edge.end.Y),
                    e.Graphics,
                    drawingColor
                );
                WriteConstraints(edge, e);
                if (edge.p1 != null && edge.p2 != null)
                {
                    int radius = 5;
                    e.Graphics.FillEllipse(
                        Brushes.Pink,
                        edge.p1.X - radius,
                        edge.p1.Y - radius,
                        2 * radius,
                        2 * radius
                    );
                    e.Graphics.FillEllipse(
                        Brushes.Pink,
                        edge.p2.X - radius,
                        edge.p2.Y - radius,
                        2 * radius,
                        2 * radius
                    );
                }
            }
            foreach (var vertex in vertices)
            {
                int radius = 5;
                e.Graphics.FillEllipse(
                    Brushes.Red,
                    vertex.X - radius,
                    vertex.Y - radius,
                    2 * radius,
                    2 * radius
                );
            }
        }
    }
}
