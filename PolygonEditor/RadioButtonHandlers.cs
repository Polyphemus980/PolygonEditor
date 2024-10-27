using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolygonEditor
{
    public partial class Form1 : Form
    {
        private void bresenhamButton_CheckedChanged(object sender, EventArgs e)
        {
            if (BresenhamButton.Checked)
            {
                drawingMethod = drawLineBerenham;
                EditingPanel.Invalidate();
            }
        }

        private void libraryButton_CheckedChanged(object sender, EventArgs e)
        {
            if (LibraryButton.Checked)
            {
                drawingMethod = DrawLineLibrary;
                EditingPanel.Invalidate();
            }
        }

        private bool SetConstraint(EdgeConstraint constraint)
        {
            Edge neighbor1 = selectedEdge.start.OtherEdge(selectedEdge);
            Edge neighbor2 = selectedEdge.end.OtherEdge(selectedEdge);
            if (
                (constraint == EdgeConstraint.Vertical || constraint == EdgeConstraint.Horizontal)
                && (neighbor1.constraint == constraint || neighbor2.constraint == constraint)
            )
                return false;
            if (constraint != EdgeConstraint.Bezier)
            {
                if (selectedEdge.start.OtherEdge(selectedEdge).constraint != EdgeConstraint.Bezier)
                    selectedEdge.start.constraint = VertexConstraint.None;
                if (selectedEdge.end.OtherEdge(selectedEdge).constraint != EdgeConstraint.Bezier)
                    selectedEdge.end.constraint = VertexConstraint.None;
            }
            selectedEdge.constraint = constraint;
            textBox1.Clear();
            if (selectedEdge.constraint != EdgeConstraint.Bezier)
            {
                selectedEdge.p1 = null;
                selectedEdge.p2 = null;
            }

            switch (constraint)
            {
                case EdgeConstraint.Vertical:
                    MoveVertexAPI(selectedEdge.end, selectedEdge.start.X, selectedEdge.end.Y);
                    break;

                case EdgeConstraint.Horizontal:
                    MoveVertexAPI(selectedEdge.end, selectedEdge.end.X, selectedEdge.start.Y);
                    break;

                case EdgeConstraint.ConstantLength:
                    selectedEdge.fixedLength = selectedEdge.length;
                    textBox1.Text = selectedEdge.length.ToString();
                    break;

                case EdgeConstraint.Bezier:
                    double pos1X =
                        (selectedEdge.start.X + selectedEdge.end.X) / 2
                        - Math.Min(20, selectedEdge.length / 3);
                    double pos1Y =
                        (selectedEdge.start.Y + selectedEdge.end.Y) / 2
                        - Math.Min(20, selectedEdge.length / 3);
                    double pos2X =
                        (selectedEdge.start.X + selectedEdge.end.X) / 2
                        + Math.Min(selectedEdge.length / 3, 20);
                    double pos2Y =
                        (selectedEdge.start.Y + selectedEdge.end.Y) / 2
                        + Math.Min(20, selectedEdge.length / 3);
                    if (selectedEdge.start.constraint == VertexConstraint.None)
                        selectedEdge.start.constraint = VertexConstraint.G1;
                    if (selectedEdge.end.constraint == VertexConstraint.None)
                        selectedEdge.end.constraint = VertexConstraint.G1;
                    selectedEdge.p1 = new BezierControlPoint(pos1X, pos1Y);
                    selectedEdge.p2 = new BezierControlPoint(pos2X, pos2Y);
                    MoveVertexAPI(selectedEdge.start, selectedEdge.start.X, selectedEdge.start.Y);
                    break;
            }
            EditingPanel.Invalidate();
            return true;
        }

        private void verticalRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (verticalRadioButton.Checked && selectedEdge.constraint != EdgeConstraint.Vertical)
            {
                if (!SetConstraint(EdgeConstraint.Vertical))
                {
                    clearButton_Click(sender, e);
                }
            }
        }

        private void horizontalRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (
                horizontalRadioButton.Checked
                && selectedEdge.constraint != EdgeConstraint.Horizontal
            )
            {
                if (!SetConstraint(EdgeConstraint.Horizontal))
                {
                    clearButton_Click(sender, e);
                }
            }
        }

        private void constantRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (
                constantRadioButton.Checked
                && selectedEdge.constraint != EdgeConstraint.ConstantLength
            )
                SetConstraint(EdgeConstraint.ConstantLength);
        }

        private void bezierRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (bezierRadioButton.Checked && selectedEdge.constraint != EdgeConstraint.Bezier)
                SetConstraint(EdgeConstraint.Bezier);
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            SetConstraint(EdgeConstraint.None);
            SetButtons();
        }

        private void SetButtons()
        {
            textBox1.Clear();
            verticalRadioButton.Checked = (selectedEdge.constraint == EdgeConstraint.Vertical);
            horizontalRadioButton.Checked = (selectedEdge.constraint == EdgeConstraint.Horizontal);
            constantRadioButton.Checked = (
                selectedEdge.constraint == EdgeConstraint.ConstantLength
            );
            bezierRadioButton.Checked = (selectedEdge.constraint == EdgeConstraint.Bezier);

            if (selectedEdge.constraint == EdgeConstraint.ConstantLength)
            {
                textBox1.Text = selectedEdge.fixedLength.ToString();
            }
        }
    }
}
