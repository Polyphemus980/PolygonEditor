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
                textBox1.Text = selectedEdge.length.ToString();
                selectedEdge.isConstantLength = true;
                EditingPanel.Invalidate();
            }
        }

        private void bezierRadioButton_CheckedChanged(object sender, EventArgs e) { }

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
            else
            {
                horizontalRadioButton.Checked = false;
                verticalRadioButton.Checked = false;
                constantRadioButton.Checked = false;
            }
        }
    }
}
