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

        private void SetConstraint(EdgeConstraint constraint)
        {
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
                    int pos1X =
                        (selectedEdge.start.X + selectedEdge.end.X) / 2
                        - Math.Min(20, selectedEdge.length / 3);
                    int pos1Y =
                        (selectedEdge.start.Y + selectedEdge.end.Y) / 2
                        - Math.Min(20, selectedEdge.length / 3);
                    int pos2X =
                        (selectedEdge.start.X + selectedEdge.end.X) / 2
                        + Math.Min(selectedEdge.length / 3, 20);
                    int pos2Y =
                        (selectedEdge.start.Y + selectedEdge.end.Y) / 2
                        + Math.Min(20, selectedEdge.length / 3);
                    selectedEdge.p1 = new BezierControlPoint(pos1X, pos1Y);
                    selectedEdge.p2 = new BezierControlPoint(pos2X, pos2Y);
                    break;
            }
            EditingPanel.Invalidate();
        }

        private void verticalRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (verticalRadioButton.Checked)
                SetConstraint(EdgeConstraint.Vertical);
        }

        private void horizontalRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (horizontalRadioButton.Checked)
                SetConstraint(EdgeConstraint.Horizontal);
        }

        private void constantRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (constantRadioButton.Checked)
                SetConstraint(EdgeConstraint.ConstantLength);
        }

        private void bezierRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (bezierRadioButton.Checked)
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
