using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolygonEditor
{
    partial class Form1 : Form
    {
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

        private void g0ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < vertices.Count; i++)
            {
                if (vertices[i].isNear(rightClickPosition))
                {
                    vertices[i].constraint = VertexConstraint.G0;
                    EditingPanel.Invalidate();
                    return;
                }
            }
        }

        private void g1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < vertices.Count; i++)
            {
                if (vertices[i].isNear(rightClickPosition))
                {
                    vertices[i].constraint = VertexConstraint.G1;
                    EditingPanel.Invalidate();
                    return;
                }
            }
        }

        private void c1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < vertices.Count; i++)
            {
                if (vertices[i].isNear(rightClickPosition))
                {
                    vertices[i].constraint = VertexConstraint.C1;
                    EditingPanel.Invalidate();
                    return;
                }
            }
        }
    }
}
