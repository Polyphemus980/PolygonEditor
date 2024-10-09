using System.Reflection;
using System.Security.Cryptography.Xml;
using System.Xml.Linq;

namespace PolygonEditor
{
    public partial class Form1 : Form
    {
        public int draggedIndex { get; set; } = -1;
        public bool isDragging { get; set; } = false;

        public Action<Pen, Point, Point> drawingMethod; 
        public Vertex? selectedVertex { get; set; }
        public int vertexCount => vertices.Count;
        public int edgeCount => edges.Count;
        public Edge? selectedEdge { get; set; }
        public List<Vertex> vertices { get; set; } = new List<Vertex>();
        public List<Edge> edges { get; set; } = new List<Edge>();
        public Form1()
        {
            InitializeComponent();
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty
           | BindingFlags.Instance | BindingFlags.NonPublic, null,
           EditingPanel, new object[] { true });

            int top = EditingPanel.Top;
            int bottom = EditingPanel.Bottom;
            int left = EditingPanel.Left;
            int right = EditingPanel.Right;
            vertices.Add(new Vertex(200, 200));
            vertices.Add(new Vertex(300, 300));
            vertices.Add(new Vertex(400, 200));
            edges.Add(new Edge(vertices[0], vertices[1]));
            edges.Add(new Edge(vertices[1], vertices[2]));
            edges.Add(new Edge(vertices[2], vertices[0]));
            EditingPanel.BorderStyle = BorderStyle.FixedSingle;
        }

        private void removeVertex_Click(object sender, EventArgs e)
        {
            if (selectedVertex == null)
            {
                MessageBox.Show("Must select a vertex to remove", "Error", MessageBoxButtons.OK);
                return;
            }
            List<Edge> neighborEdges = edges.FindAll(edge => edge.start == selectedVertex || edge.end == selectedVertex);
            Vertex neighborFirst = neighborEdges.First().start == selectedVertex ? neighborEdges.First().end : neighborEdges.First().start;
            Vertex neighborSecond = neighborEdges.Last().start == selectedVertex ? neighborEdges.Last().end : neighborEdges.Last().start;
            edges.Remove(neighborEdges.First());
            edges.Remove(neighborEdges.Last());
            vertices.Remove(selectedVertex);
            selectedVertex = null;
            selectedEdge = null;
            if (!edges.Any(edge => (edge.start, edge.end) == (neighborSecond, neighborFirst) || (edge.end, edge.start) == (neighborSecond, neighborFirst)))
                edges.Add(new Edge(neighborSecond, neighborFirst));
            EditingPanel.Invalidate();

        }

        private void DrawLineLibrary(Point start,Point end,Graphics g,Color color)
        {
            Pen pen  = new Pen(color,1);
            g.DrawLine(pen, start, end);
        }
        private void drawLineBerenham(Point start, Point end, Graphics g, Color color)
        {   
            Brush brush = new SolidBrush(color);
            int x0 = start.X; int y0 = start.Y;
            int x1 = end.X; int y1 = end.Y;
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

        private void newPolygon_Click(object sender, EventArgs e)
        {
            EditingPanel.Invalidate();
        }

        private void EditingPanel_Paint(object sender, PaintEventArgs e)
        {
            foreach (var edge in edges)
            {
                Color drawingColor = (selectedEdge == edge) ? Color.Red : Color.Green;
                drawLineBerenham(edge.start.position, edge.end.position, e.Graphics, drawingColor);
            }
            foreach (var vertex in vertices)
            {
                int radius = selectedVertex == vertex ? 10 : 5;
                e.Graphics.FillEllipse(Brushes.Red, vertex.position.X - radius, vertex.position.Y - radius, 2 * radius, 2 * radius);
            }
        }

        private void EditingPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            for (int i = 0; i < vertices.Count; i++)
            {
                if (vertices[i].isNear(e.Location))
                {

                    draggedIndex = i;
                    isDragging = true;
                    EditingPanel.Invalidate();
                    return;
                }
            }
        }


        private void EditingPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Vertex currentVertex = vertices[draggedIndex];
                if (Control.ModifierKeys == Keys.Control)
                {
                    int dx = currentVertex.position.X - e.X;
                    int dy = currentVertex.position.Y - e.Y;
                    for (int i = 0; i < vertices.Count; i++)
                    {
                        vertices[i].position.X -= dx;
                        vertices[i].position.Y -= dy;
                    }
                }
                else
                {
                    currentVertex.position = new Point(e.X, e.Y);
                }
                EditingPanel.Invalidate();
            }
        }

        private void EditingPanel_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
            draggedIndex = -1;
        }

        private void addVertexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selectedEdge == null)
            {
                MessageBox.Show("You must select an edge to split", "Error", MessageBoxButtons.OK);
                return;
            }
            Vertex start = selectedEdge.start;
            Vertex end = selectedEdge.end;
            Vertex mid = new Vertex((start.position.X + end.position.X) / 2, (start.position.Y + end.position.Y) / 2);
            vertices.Add(mid);
            edges.Add(new Edge(start, mid));
            edges.Add(new Edge(mid, end));
            edges.Remove(selectedEdge);
            selectedEdge = null;
            EditingPanel.Invalidate();
        }

        private void EditingPanel_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < vertices.Count; i++)
            {
                if (vertices[i].isNear(e.Location))
                {
                    if (selectedVertex == vertices[i])
                        selectedVertex = null;
                    else
                        selectedVertex = vertices[i];
                    EditingPanel.Invalidate();
                    return;
                }
            }
            for (int i = 0; i < edges.Count; i++)
            {
                if (edges[i].IsPointNearEdge(e.Location))
                {
                    if (selectedEdge == edges[i])
                    {
                        selectedEdge = null;
                        EditingPanel.Invalidate();
                        return;
                    }
                    selectedEdge = edges[i];
                    EditingPanel.Invalidate();
                    return;
                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {

            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
