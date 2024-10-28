using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PolygonEditor
{
    public partial class TutorialForm : Form
    {
        public TutorialForm()
        {
            InitializeComponent();
        }

        void AppendFormattedText(RichTextBox rtb, string text, Font font, Color color)
        {
            rtb.SelectionStart = rtb.TextLength;
            rtb.SelectionLength = 0;
            rtb.SelectionFont = font;
            rtb.SelectionColor = color;
            rtb.AppendText(text);
            rtb.SelectionColor = rtb.ForeColor;
        }

        public void formatTutorial()
        {
            Font headingFont = new Font("Arial", 12, FontStyle.Bold);
            Font subHeadingFont = new Font("Arial", 10, FontStyle.Bold);
            Font bodyFont = new Font("Arial", 10, FontStyle.Regular);
            Color headingColor = Color.DarkBlue;
            Color subHeadingColor = Color.DarkGreen;
            Color bodyColor = Color.Black;

            RichTextBox tutorialRichTextBox = richTextBox1;
            AppendFormattedText(tutorialRichTextBox, "1. New Polygon\n", headingFont, headingColor);
            AppendFormattedText(
                tutorialRichTextBox,
                "To create a new polygon, click the New Polygon button. This will allow you to create new vertices in the place where you click on the main panel. Clicking near the first vertex created will end the process of adding new vertices and allow you to begin editing the polygon.\n\n",
                bodyFont,
                bodyColor
            );
            AppendFormattedText(
                tutorialRichTextBox,
                "2. Moving Vertices\n",
                headingFont,
                headingColor
            );
            AppendFormattedText(
                tutorialRichTextBox,
                "To move a vertex, press the left mouse button (LMB) near the desired vertex, and then move your mouse while holding the LMB.\n\n",
                bodyFont,
                bodyColor
            );

            AppendFormattedText(
                tutorialRichTextBox,
                "3. Moving Whole Polygon\n",
                headingFont,
                headingColor
            );
            AppendFormattedText(
                tutorialRichTextBox,
                "To move the whole polygon, press CTRL + LMB and proceed as you would when moving vertices.\n\n",
                bodyFont,
                bodyColor
            );

            AppendFormattedText(
                tutorialRichTextBox,
                "4. Selecting an Edge\n",
                headingFont,
                headingColor
            );
            AppendFormattedText(
                tutorialRichTextBox,
                "To select an edge, double-click the LMB near the desired edge. For Bezier curves, press the LMB near the start or end edge of the Bezier polygon.\n\n",
                bodyFont,
                bodyColor
            );

            AppendFormattedText(
                tutorialRichTextBox,
                "4a. Setting Constraints on Selected Edge\n",
                subHeadingFont,
                subHeadingColor
            );
            AppendFormattedText(
                tutorialRichTextBox,
                "To set a constraint on the selected edge, choose one of the radio buttons in the side panel under 'Set Constraint'. To clear all constraints, press the 'Clear Constraints' button.\n\n",
                bodyFont,
                bodyColor
            );

            AppendFormattedText(
                tutorialRichTextBox,
                "4b. Set Width of a Constant Width Edge\n",
                subHeadingFont,
                subHeadingColor
            );
            AppendFormattedText(
                tutorialRichTextBox,
                "To set the width of a constant width edge, enter the desired length in the text box to the right of the constant width radio button and press Enter.\n\n",
                bodyFont,
                bodyColor
            );

            AppendFormattedText(
                tutorialRichTextBox,
                "5. Opening Context Menu\n",
                headingFont,
                headingColor
            );
            AppendFormattedText(
                tutorialRichTextBox,
                "To open the context menu, press the right mouse button (RMB) while the mouse is on the editing panel.\n\n",
                bodyFont,
                bodyColor
            );

            AppendFormattedText(
                tutorialRichTextBox,
                "5a. Add Vertex\n",
                subHeadingFont,
                subHeadingColor
            );
            AppendFormattedText(
                tutorialRichTextBox,
                "To add a vertex, select an edge and choose 'Add Vertex' from the context menu.\n\n",
                bodyFont,
                bodyColor
            );

            AppendFormattedText(
                tutorialRichTextBox,
                "5b. Remove Vertex\n",
                subHeadingFont,
                subHeadingColor
            );
            AppendFormattedText(
                tutorialRichTextBox,
                "To remove a vertex, choose 'Remove Vertex' from the context menu, which must be opened near the desired vertex.\n\n",
                bodyFont,
                bodyColor
            );

            AppendFormattedText(
                tutorialRichTextBox,
                "5c. Add Vertex Constraint\n",
                subHeadingFont,
                subHeadingColor
            );
            AppendFormattedText(
                tutorialRichTextBox,
                "To add a constraint to a vertex, choose 'Add vertex constraint' from the context menu, which must be opened near the desired vertex and then choose the desired constraint.\n \n",
                bodyFont,
                bodyColor
            );
            AppendFormattedText(
                tutorialRichTextBox,
                "6. Changing Drawing Method\n",
                headingFont,
                headingColor
            );
            AppendFormattedText(
                tutorialRichTextBox,
                "To change the drawing method, select one of the radio buttons in the 'Choose Drawing Method' section on the side panel.\n",
                bodyFont,
                bodyColor
            );
        }

        public void formatImplementation()
        {
            Font headingFont = new Font("Arial", 12, FontStyle.Bold);
            Font subHeadingFont = new Font("Arial", 10, FontStyle.Bold);
            Font bodyFont = new Font("Arial", 10, FontStyle.Regular);
            Color headingColor = Color.DarkBlue;
            Color subHeadingColor = Color.DarkGreen;
            Color bodyColor = Color.Black;
            RichTextBox tutorialRichTextBox = richTextBox1;
            AppendFormattedText(
                tutorialRichTextBox,
                "1. Class Structure\n",
                headingFont,
                headingColor
            );

            AppendFormattedText(
                tutorialRichTextBox,
                "1a. Vertices\n",
                subHeadingFont,
                subHeadingColor
            );
            AppendFormattedText(
                tutorialRichTextBox,
                "A vertex contains its position and the edges that it is a part of. The vertices can also have constraints such as G0, G1, or C1.\n\n",
                bodyFont,
                bodyColor
            );

            AppendFormattedText(
                tutorialRichTextBox,
                "1b. Edges\n",
                subHeadingFont,
                subHeadingColor
            );
            AppendFormattedText(
                tutorialRichTextBox,
                "An edge contains its start and end vertices, and if it is a Bezier curve, it includes control points. The edge can also have constraints, such as Horizontal, Vertical, or Constant Length.\n\n",
                bodyFont,
                bodyColor
            );

            AppendFormattedText(
                tutorialRichTextBox,
                "2. Algorithm Design\n",
                headingFont,
                headingColor
            );

            AppendFormattedText(
                tutorialRichTextBox,
                "2a. Moving Vertices Algorithm\n",
                subHeadingFont,
                subHeadingColor
            );
            AppendFormattedText(
                tutorialRichTextBox,
                "When moving a vertex, a chain of functions is called. The first two functions iteratively move through each vertex in the polygon, adjusting their position to maintain edge constraints, starting from the moved vertex. The difference between the two functions is the direction of movement. They stop when they reach an edge with no constraint or return to the starting vertex.\n\n",
                bodyFont,
                bodyColor
            );
            AppendFormattedText(
                tutorialRichTextBox,
                "The other two functions adjust the Bezier control points to maintain vertex constraints. They work similarly to the first two but do not stop until they reach the starting vertex, regardless of constraints.\n\n",
                bodyFont,
                bodyColor
            );

            AppendFormattedText(
                tutorialRichTextBox,
                "2b. Moving Bezier Control Points Algorithm\n",
                subHeadingFont,
                subHeadingColor
            );
            AppendFormattedText(
                tutorialRichTextBox,
                "When moving a Bezier control point, this algorithm adjusts either the control point of the other edge of the closest vertex or the closest vertex itself.\n\n",
                bodyFont,
                bodyColor
            );
        }
    }
}
