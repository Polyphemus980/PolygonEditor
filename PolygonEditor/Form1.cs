using System.ComponentModel;
using System.Reflection;
using System.Security.Cryptography.Xml;
using System.Xml.Linq;

namespace PolygonEditor
{
    public partial class Form1 : Form, INotifyPropertyChanged
    {
        public int draggedIndex { get; set; } = -1;
        public bool isDragging { get; set; } = false;
        private Point rightClickPosition;
        public Action<Point, Point, Graphics, Color> drawingMethod { get; set; }
        public int vertexCount => vertices.Count;
        public int edgeCount => edges.Count;
        private Edge? selectedEdge_ = null;

        public Edge? selectedEdge
        {
            get => selectedEdge_;
            set
            {
                selectedEdge_ = value;
                if (value == null)
                {
                    constantRadioButton.Checked = false;
                    verticalRadioButton.Checked = false;
                    horizontalRadioButton.Checked = false;
                }
                OnPropertyChanged(nameof(selectedEdgeNull));
            }
        }
        public bool selectedEdgeNull => selectedEdge != null;
        public List<Vertex> vertices { get; set; } = new List<Vertex>();
        public List<Edge> edges { get; set; } = new List<Edge>();

        public Form1()
        {
            InitializeComponent();
            typeof(Panel).InvokeMember(
                "DoubleBuffered",
                BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                null,
                EditingPanel,
                new object[] { true }
            );
            drawingMethod = drawLineBerenham;
            var binding1 = new Binding(
                "Enabled",
                this,
                nameof(selectedEdgeNull),
                true,
                DataSourceUpdateMode.OnPropertyChanged
            );
            var binding2 = new Binding(
                "Enabled",
                this,
                nameof(selectedEdgeNull),
                true,
                DataSourceUpdateMode.OnPropertyChanged
            );
            var binding3 = new Binding(
                "Enabled",
                this,
                nameof(selectedEdgeNull),
                true,
                DataSourceUpdateMode.OnPropertyChanged
            );
            var binding4 = new Binding(
                "Enabled",
                this,
                nameof(selectedEdgeNull),
                true,
                DataSourceUpdateMode.OnPropertyChanged
            );
            verticalRadioButton.DataBindings.Add(binding1);
            horizontalRadioButton.DataBindings.Add(binding2);
            constantRadioButton.DataBindings.Add(binding3);
            clearButton.DataBindings.Add(binding4);
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

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void removeVertex_Click(object sender, EventArgs e)
        {
            Vertex? selectedVertex = null;
            for (int i = 0; i < vertices.Count; i++)
            {
                if (vertices[i].isNear(rightClickPosition))
                {
                    selectedVertex = vertices[i];
                    break;
                }
            }
            if (selectedVertex == null)
            {
                MessageBox.Show(
                    "Must be near the vertex to be removed",
                    "Error",
                    MessageBoxButtons.OK
                );
                return;
            }
            List<Edge> neighborEdges = edges.FindAll(edge =>
                edge.start == selectedVertex || edge.end == selectedVertex
            );
            Vertex neighborFirst =
                neighborEdges.First().start == selectedVertex
                    ? neighborEdges.First().end
                    : neighborEdges.First().start;
            Vertex neighborSecond =
                neighborEdges.Last().start == selectedVertex
                    ? neighborEdges.Last().end
                    : neighborEdges.Last().start;
            edges.Remove(neighborEdges.First());
            edges.Remove(neighborEdges.Last());
            vertices.Remove(selectedVertex);
            selectedEdge = null;
            if (
                !edges.Any(edge =>
                    (edge.start, edge.end) == (neighborSecond, neighborFirst)
                    || (edge.end, edge.start) == (neighborSecond, neighborFirst)
                )
            )
                edges.Add(new Edge(neighborSecond, neighborFirst));
            EditingPanel.Invalidate();
        }

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

        private void newPolygon_Click(object sender, EventArgs e)
        {
            EditingPanel.Invalidate();
        }

        private void WriteConstraints(Edge e, PaintEventArgs p)
        {
            int midpointX = (e.start.X + e.end.X) / 2;
            int midpointY = (e.start.Y + e.end.Y) / 2;
            Font font = new Font("Arial", 8);
            Brush brush = Brushes.White;
            string lengthText = e.length.ToString("0.00");
            if (e.isVertical)
                lengthText += "V";
            else if (e.isHorizontal)
                lengthText += "H";
            else if (e.isConstantLength)
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

        private void EditingPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                rightClickPosition = e.Location;
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
                    int dx = currentVertex.X - e.X;
                    int dy = currentVertex.Y - e.Y;
                    for (int i = 0; i < vertices.Count; i++)
                    {
                        vertices[i].X -= dx;
                        vertices[i].Y -= dy;
                    }
                }
                else
                {
                    MoveVertexAPI(currentVertex, e.X, e.Y);
                }
                EditingPanel.Invalidate();
            }
        }

        public void MoveVertexAPI(Vertex vertex, int X, int Y)
        {
            //vertex.MoveVertexIteratively(X, Y, true);
            //vertex.MoveVertexIteratively(X, Y, false);
            vertex.X = X;
            vertex.Y = Y;
            vertex.MoveVertex(X, Y);
            vertex.SwappedMoveVertex(X, Y);
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
            Vertex mid = new Vertex((start.X + end.X) / 2, (start.Y + end.Y) / 2);
            vertices.Add(mid);
            edges.Add(new Edge(start, mid));
            edges.Add(new Edge(mid, end));
            edges.Remove(selectedEdge);
            start.edges.Remove(selectedEdge);
            end.edges.Remove(selectedEdge);
            selectedEdge = null;
            textBox1.Text = "";
            EditingPanel.Invalidate();
        }

        private void EditingPanel_MouseDoubleClick(object sender, MouseEventArgs e)
        {
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
                    SetButtons();
                    EditingPanel.Invalidate();
                    return;
                }
            }
        }

        private void SetButtons()
        {
            if (selectedEdge.isVertical)
            {
                verticalRadioButton.Checked = true;
            }
            else if (selectedEdge.isConstantLength)
            {
                constantRadioButton.Checked = true;
            }
            else if (selectedEdge.isHorizontal)
            {
                horizontalRadioButton.Checked = true;
            }
            else
            {
                horizontalRadioButton.Checked = false;
                verticalRadioButton.Checked = false;
                constantRadioButton.Checked = false;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                drawingMethod = drawLineBerenham;
                EditingPanel.Invalidate();
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                drawingMethod = DrawLineLibrary;
                EditingPanel.Invalidate();
            }
        }

        private void VerticalRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (verticalRadioButton.Checked)
            {
                selectedEdge.isVertical = true;
                selectedEdge.isHorizontal = false;
                selectedEdge.isConstantLength = false;
                MoveVertexAPI(selectedEdge.end, selectedEdge.start.X, selectedEdge.end.Y);
                EditingPanel.Invalidate();
            }
        }

        private void HorizontalRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (horizontalRadioButton.Checked)
            {
                selectedEdge.isVertical = false;
                selectedEdge.isHorizontal = true;
                textBox1.Clear();
                MoveVertexAPI(selectedEdge.end, selectedEdge.end.X, selectedEdge.start.Y);
                EditingPanel.Invalidate();
                selectedEdge.isConstantLength = false;
            }
        }

        private void ConstantRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (constantRadioButton.Checked)
            {
                selectedEdge.fixedLength = selectedEdge.length;
                selectedEdge.isVertical = false;
                selectedEdge.isHorizontal = false;
                textBox1.Text = selectedEdge.length.ToString();
                selectedEdge.isConstantLength = true;
                EditingPanel.Invalidate();
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            horizontalRadioButton.Checked = false;
            constantRadioButton.Checked = false;
            verticalRadioButton.Checked = false;
            selectedEdge.isVertical = false;
            selectedEdge.isHorizontal = false;
            selectedEdge.isConstantLength = false;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (String.IsNullOrEmpty(Text) || e.KeyChar != (char)Keys.Enter)
                return;
            int length = int.Parse(textBox1.Text);
            selectedEdge.fixedLength = length;
            Vertex end = selectedEdge.end;
            Vertex start = selectedEdge.start;
            double angle = Math.Atan2(end.Y - start.Y, end.X - start.X);
            int endX = (int)(start.X + length * Math.Cos(angle));
            int endY = (int)(start.Y + length * Math.Sin(angle));
            MoveVertexAPI(end, endX, endY);
            EditingPanel.Invalidate();
        }
    }
}
