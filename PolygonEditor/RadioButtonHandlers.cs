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

        public enum EdgeConstraint
        {
            None,
            Vertical,
            Horizontal,
            ConstantLength,
            Bezier,
        }

        private void SetConstraint(EdgeConstraint constraint)
        {
            selectedEdge.isVertical = false;
            selectedEdge.isHorizontal = false;
            selectedEdge.isConstantLength = false;
            selectedEdge.isBezier = false;
            selectedEdge.p1 = null;
            selectedEdge.p2 = null;

            switch (constraint)
            {
                case EdgeConstraint.Vertical:
                    selectedEdge.isVertical = true;
                    MoveVertexAPI(selectedEdge.end, selectedEdge.start.X, selectedEdge.end.Y);
                    break;

                case EdgeConstraint.Horizontal:
                    selectedEdge.isHorizontal = true;
                    MoveVertexAPI(selectedEdge.end, selectedEdge.end.X, selectedEdge.start.Y);
                    break;

                case EdgeConstraint.ConstantLength:
                    selectedEdge.fixedLength = selectedEdge.length;
                    selectedEdge.isConstantLength = true;
                    textBox1.Text = selectedEdge.length.ToString();
                    break;

                case EdgeConstraint.Bezier:
                    int pos1X = (selectedEdge.start.X + selectedEdge.end.X) / 2 - 20;
                    int pos1Y = (selectedEdge.start.Y + selectedEdge.end.Y) / 2 - 50;
                    int pos2X = (selectedEdge.start.X + selectedEdge.end.X) / 2 + 50;
                    int pos2Y = (selectedEdge.start.Y + selectedEdge.end.Y) / 2 + 20;
                    selectedEdge.p1 = new BezierControlPoint(pos1X, pos1Y);
                    selectedEdge.p2 = new BezierControlPoint(pos2X, pos2Y);
                    selectedEdge.isBezier = true;
                    break;
            }
            EditingPanel.Invalidate();
        }

        private void verticalRadioButton_CheckedChanged(object sender, EventArgs e)
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

        private void horizontalRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (horizontalRadioButton.Checked)
            {
                selectedEdge.isVertical = false;
                selectedEdge.isHorizontal = true;
                selectedEdge.isBezier = false;
                selectedEdge.p1 = null;
                selectedEdge.p2 = null;
                textBox1.Clear();
                MoveVertexAPI(selectedEdge.end, selectedEdge.end.X, selectedEdge.start.Y);
                EditingPanel.Invalidate();
                selectedEdge.isConstantLength = false;
            }
        }

        private void constantRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (constantRadioButton.Checked)
            {
                selectedEdge.fixedLength = selectedEdge.length;
                selectedEdge.isVertical = false;
                selectedEdge.isHorizontal = false;
                selectedEdge.isBezier = false;
                selectedEdge.p1 = null;
                selectedEdge.p2 = null;
                textBox1.Text = selectedEdge.length.ToString();
                selectedEdge.isConstantLength = true;
                EditingPanel.Invalidate();
            }
        }

        private void bezierRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (bezierRadioButton.Checked)
            {
                int pos1X = (selectedEdge.start.X + selectedEdge.end.X) / 2 - 20;
                int pos1Y = (selectedEdge.start.Y + selectedEdge.end.Y) / 2 - 50;
                int pos2X = (selectedEdge.start.X + selectedEdge.end.X) / 2 + 50;
                int pos2Y = (selectedEdge.start.Y + selectedEdge.end.Y) / 2 + 20;
                selectedEdge.p1 = new BezierControlPoint(pos1X, pos2Y);
                selectedEdge.p2 = new BezierControlPoint(pos2X, pos2Y);
                selectedEdge.isBezier = true;
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
            textBox1.Clear();
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
                textBox1.Text = selectedEdge.fixedLength.ToString();
            }
            else if (selectedEdge.isHorizontal)
            {
                horizontalRadioButton.Checked = true;
            }
            else if (selectedEdge.isBezier)
            {
                bezierRadioButton.Checked = true;
            }
            else
            {
                horizontalRadioButton.Checked = false;
                verticalRadioButton.Checked = false;
                constantRadioButton.Checked = false;
                bezierRadioButton.Checked = false;
            }
        }
    }
}
