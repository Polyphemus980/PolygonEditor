using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolygonEditor
{
    partial class Form1 : Form
    {
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
            vertex.MoveVertexIteratively(X, Y, true);
            vertex.MoveVertexIteratively(X, Y, false);
        }

        private void EditingPanel_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
            draggedIndex = -1;
        }
    }
}
