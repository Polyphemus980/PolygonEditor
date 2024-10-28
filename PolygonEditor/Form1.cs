using System.ComponentModel;
using System.Reflection;
using System.Security.Cryptography.Xml;
using System.Windows.Forms.VisualStyles;
using System.Xml.Linq;

namespace PolygonEditor
{
    public partial class Form1 : Form, INotifyPropertyChanged
    {
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

        bool newPolygonMode { get; set; } = false;

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
            drawingBezierMethod = DrawBezier;
            SetBinding(verticalRadioButton);
            SetBinding(horizontalRadioButton);
            SetBinding(constantRadioButton);
            SetBinding(clearButton);
            SetBinding(bezierRadioButton);
            SetBinding(textBox1);
            //int top = EditingPanel.Top;
            //int bottom = EditingPanel.Bottom;
            //int left = EditingPanel.Left;
            //int right = EditingPanel.Right;
            //vertices.Add(new Vertex(200, 200));
            //vertices.Add(new Vertex(300, 300));
            //vertices.Add(new Vertex(400, 200));
            //edges.Add(new Edge(vertices[0], vertices[1]));
            //edges.Add(new Edge(vertices[1], vertices[2]));
            //edges.Add(new Edge(vertices[2], vertices[0]));
            CreateStartExample();
            EditingPanel.BorderStyle = BorderStyle.FixedSingle;
        }

        public void CreateStartExample()
        {
            int top = EditingPanel.Top;
            int bottom = EditingPanel.Bottom;
            int left = EditingPanel.Left;
            int right = EditingPanel.Right;
            vertices.Add(new Vertex(200, 200));
            vertices.Add(new Vertex(300, 150));
            vertices.Add(new Vertex(400, 200));
            vertices.Add(new Vertex(400, 400));
            edges.Add(new Edge(vertices[0], vertices[1]));
            edges.Add(new Edge(vertices[1], vertices[2]));
            edges.Add(new Edge(vertices[2], vertices[3]));
            edges.Add(new Edge(vertices[3], vertices[0]));
            SetConstraintEdge(edges[0], EdgeConstraint.Horizontal);
            SetConstraintEdge(edges[1], EdgeConstraint.Bezier);
            SetConstraintEdge(edges[2], EdgeConstraint.Vertical);
            SetConstraintEdge(edges[3], EdgeConstraint.ConstantLength);
        }

        private void SetConstraintEdge(Edge edge, EdgeConstraint constraint)
        {
            selectedEdge = edge;
            SetConstraint(constraint);
            selectedEdge = null;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void SetBinding(Control control)
        {
            Binding binding = new Binding(
                "Enabled",
                this,
                nameof(selectedEdgeNull),
                true,
                DataSourceUpdateMode.OnPropertyChanged
            );
            control.DataBindings.Add(binding);
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
                        textBox1.Clear();
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

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (String.IsNullOrEmpty(Text) || e.KeyChar != (char)Keys.Enter)
                return;
            int length;
            if (!int.TryParse(textBox1.Text, out length))
            {
                MessageBox.Show("Length must be an integer");
                textBox1.Clear();
                return;
            }
            selectedEdge.fixedLength = length;
            Vertex end = selectedEdge.end;
            Vertex start = selectedEdge.start;
            double angle = Math.Atan2(end.Y - start.Y, end.X - start.X);
            int endX = (int)(start.X + length * Math.Cos(angle));
            int endY = (int)(start.Y + length * Math.Sin(angle));
            MoveVertexAPI(end, endX, endY);
            EditingPanel.Invalidate();
        }

        public bool IsNear(double p1x, double p1y, double p2x, double p2y)
        {
            double squaredRadius = Math.Pow(p1y - p2y, 2) + Math.Pow(p1y - p2y, 2);
            return squaredRadius < 10;
        }

        private void newPolygonButton_Click(object sender, EventArgs e)
        {
            vertices.Clear();
            edges.Clear();
            EditingPanel.Invalidate();
            selectedEdge = null;

            newPolygonMode = true;
        }

        private void EditingPanel_MouseClick(object sender, MouseEventArgs e)
        {
            if (newPolygonMode)
            {
                for (int i = 0; i < vertices.Count; i++)
                {
                    if (IsNear(vertices[i].X, vertices[i].Y, e.X, e.Y) && vertices.Count >= 3)
                    {
                        edges.Add(new Edge(vertices.Last(), vertices.First()));
                        newPolygonMode = false;
                        EditingPanel.Invalidate();
                        return;
                    }
                    else if (IsNear(vertices[i].X, vertices[i].Y, e.X, e.Y) && vertices.Count < 3)
                        continue;
                }
                vertices.Add(new Vertex(e.X, e.Y));
                if (vertices.Count > 1)
                {
                    edges.Add(new Edge(vertices.Last(), vertices[vertices.Count - 2]));
                }
                EditingPanel.Invalidate();
                return;
            }
        }

        private void tutorialButton_Click(object sender, EventArgs e)
        {
            TutorialForm f = new TutorialForm();
            f.formatTutorial();
            f.ShowDialog();
        }

        private void ImplementationButton_Click(object sender, EventArgs e)
        {
            TutorialForm f = new TutorialForm();
            f.formatImplementation();
            f.ShowDialog();
        }
    }
}
