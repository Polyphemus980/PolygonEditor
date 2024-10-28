namespace PolygonEditor
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            contextMenu = new ContextMenuStrip(components);
            addVertexToolStripMenuItem = new ToolStripMenuItem();
            removeVertexToolStripMenuItem = new ToolStripMenuItem();
            addVertexConstraintToolStripMenuItem = new ToolStripMenuItem();
            g0ToolStripMenuItem = new ToolStripMenuItem();
            g1ToolStripMenuItem = new ToolStripMenuItem();
            c1ToolStripMenuItem = new ToolStripMenuItem();
            tableLayoutPanel1 = new TableLayoutPanel();
            groupBox3 = new GroupBox();
            ImplementationButton = new Button();
            tutorialButton = new Button();
            newPolygonButton = new Button();
            groupBox1 = new GroupBox();
            LibraryButton = new RadioButton();
            label1 = new Label();
            BresenhamButton = new RadioButton();
            groupBox2 = new GroupBox();
            bezierRadioButton = new RadioButton();
            textBox1 = new TextBox();
            clearButton = new Button();
            constantRadioButton = new RadioButton();
            verticalRadioButton = new RadioButton();
            horizontalRadioButton = new RadioButton();
            label2 = new Label();
            EditingPanel = new Panel();
            tableLayoutPanel2 = new TableLayoutPanel();
            contextMenu.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // contextMenu
            // 
            contextMenu.ImageScalingSize = new Size(20, 20);
            contextMenu.Items.AddRange(new ToolStripItem[] { addVertexToolStripMenuItem, removeVertexToolStripMenuItem, addVertexConstraintToolStripMenuItem });
            contextMenu.Name = "contextMenu";
            contextMenu.Size = new Size(229, 76);
            // 
            // addVertexToolStripMenuItem
            // 
            addVertexToolStripMenuItem.Name = "addVertexToolStripMenuItem";
            addVertexToolStripMenuItem.Size = new Size(228, 24);
            addVertexToolStripMenuItem.Text = "Add vertex (mid edge)";
            addVertexToolStripMenuItem.Click += addVertexToolStripMenuItem_Click;
            // 
            // removeVertexToolStripMenuItem
            // 
            removeVertexToolStripMenuItem.Name = "removeVertexToolStripMenuItem";
            removeVertexToolStripMenuItem.Size = new Size(228, 24);
            removeVertexToolStripMenuItem.Text = "Remove vertex";
            removeVertexToolStripMenuItem.Click += removeVertex_Click;
            // 
            // addVertexConstraintToolStripMenuItem
            // 
            addVertexConstraintToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { g0ToolStripMenuItem, g1ToolStripMenuItem, c1ToolStripMenuItem });
            addVertexConstraintToolStripMenuItem.Name = "addVertexConstraintToolStripMenuItem";
            addVertexConstraintToolStripMenuItem.Size = new Size(228, 24);
            addVertexConstraintToolStripMenuItem.Text = "Add vertex constraint";
            // 
            // g0ToolStripMenuItem
            // 
            g0ToolStripMenuItem.Name = "g0ToolStripMenuItem";
            g0ToolStripMenuItem.Size = new Size(110, 26);
            g0ToolStripMenuItem.Text = "G0";
            g0ToolStripMenuItem.Click += g0ToolStripMenuItem_Click;
            // 
            // g1ToolStripMenuItem
            // 
            g1ToolStripMenuItem.Name = "g1ToolStripMenuItem";
            g1ToolStripMenuItem.Size = new Size(110, 26);
            g1ToolStripMenuItem.Text = "G1";
            g1ToolStripMenuItem.Click += g1ToolStripMenuItem_Click;
            // 
            // c1ToolStripMenuItem
            // 
            c1ToolStripMenuItem.Name = "c1ToolStripMenuItem";
            c1ToolStripMenuItem.Size = new Size(110, 26);
            c1ToolStripMenuItem.Text = "C1";
            c1ToolStripMenuItem.Click += c1ToolStripMenuItem_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(groupBox3, 0, 2);
            tableLayoutPanel1.Controls.Add(groupBox1, 0, 0);
            tableLayoutPanel1.Controls.Add(groupBox2, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(884, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 150F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 147F));
            tableLayoutPanel1.Size = new Size(244, 515);
            tableLayoutPanel1.TabIndex = 4;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(ImplementationButton);
            groupBox3.Controls.Add(tutorialButton);
            groupBox3.Controls.Add(newPolygonButton);
            groupBox3.Dock = DockStyle.Fill;
            groupBox3.Location = new Point(3, 371);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(238, 141);
            groupBox3.TabIndex = 3;
            groupBox3.TabStop = false;
            groupBox3.Text = "Other";
            // 
            // ImplementationButton
            // 
            ImplementationButton.Location = new Point(6, 106);
            ImplementationButton.Name = "ImplementationButton";
            ImplementationButton.Size = new Size(185, 29);
            ImplementationButton.TabIndex = 9;
            ImplementationButton.Text = "Implementation details";
            ImplementationButton.UseVisualStyleBackColor = true;
            ImplementationButton.Click += ImplementationButton_Click;
            // 
            // tutorialButton
            // 
            tutorialButton.Location = new Point(6, 71);
            tutorialButton.Name = "tutorialButton";
            tutorialButton.Size = new Size(185, 29);
            tutorialButton.TabIndex = 8;
            tutorialButton.Text = "Tutorial";
            tutorialButton.UseVisualStyleBackColor = true;
            tutorialButton.Click += tutorialButton_Click;
            // 
            // newPolygonButton
            // 
            newPolygonButton.Location = new Point(6, 26);
            newPolygonButton.Name = "newPolygonButton";
            newPolygonButton.Size = new Size(185, 29);
            newPolygonButton.TabIndex = 7;
            newPolygonButton.Text = "New polygon";
            newPolygonButton.UseVisualStyleBackColor = true;
            newPolygonButton.Click += newPolygonButton_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(LibraryButton);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(BresenhamButton);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(238, 144);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            // 
            // LibraryButton
            // 
            LibraryButton.AutoSize = true;
            LibraryButton.ForeColor = SystemColors.ActiveCaptionText;
            LibraryButton.Location = new Point(18, 95);
            LibraryButton.Name = "LibraryButton";
            LibraryButton.Size = new Size(144, 24);
            LibraryButton.TabIndex = 1;
            LibraryButton.Text = "Library algorithm";
            LibraryButton.UseVisualStyleBackColor = true;
            LibraryButton.CheckedChanged += libraryButton_CheckedChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.ActiveCaptionText;
            label1.Location = new Point(18, 23);
            label1.Name = "label1";
            label1.Size = new Size(185, 20);
            label1.TabIndex = 2;
            label1.Text = "Choose drawing algorithm";
            // 
            // BresenhamButton
            // 
            BresenhamButton.AutoSize = true;
            BresenhamButton.Checked = true;
            BresenhamButton.ForeColor = SystemColors.ActiveCaptionText;
            BresenhamButton.Location = new Point(18, 65);
            BresenhamButton.Name = "BresenhamButton";
            BresenhamButton.Size = new Size(103, 24);
            BresenhamButton.TabIndex = 0;
            BresenhamButton.TabStop = true;
            BresenhamButton.Text = "Bresenham";
            BresenhamButton.UseVisualStyleBackColor = true;
            BresenhamButton.CheckedChanged += bresenhamButton_CheckedChanged;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(bezierRadioButton);
            groupBox2.Controls.Add(textBox1);
            groupBox2.Controls.Add(clearButton);
            groupBox2.Controls.Add(constantRadioButton);
            groupBox2.Controls.Add(verticalRadioButton);
            groupBox2.Controls.Add(horizontalRadioButton);
            groupBox2.Controls.Add(label2);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Location = new Point(3, 153);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(238, 212);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            // 
            // bezierRadioButton
            // 
            bezierRadioButton.AutoSize = true;
            bezierRadioButton.Location = new Point(18, 145);
            bezierRadioButton.Name = "bezierRadioButton";
            bezierRadioButton.Size = new Size(71, 24);
            bezierRadioButton.TabIndex = 6;
            bezierRadioButton.TabStop = true;
            bezierRadioButton.Text = "Bezier";
            bezierRadioButton.UseVisualStyleBackColor = true;
            bezierRadioButton.CheckedChanged += bezierRadioButton_CheckedChanged;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(161, 114);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(62, 27);
            textBox1.TabIndex = 5;
            textBox1.KeyPress += textBox1_KeyPress;
            // 
            // clearButton
            // 
            clearButton.Location = new Point(6, 174);
            clearButton.Name = "clearButton";
            clearButton.Size = new Size(185, 29);
            clearButton.TabIndex = 4;
            clearButton.Text = "Clear constraints";
            clearButton.UseVisualStyleBackColor = true;
            clearButton.Click += clearButton_Click;
            // 
            // constantRadioButton
            // 
            constantRadioButton.AutoSize = true;
            constantRadioButton.Location = new Point(18, 115);
            constantRadioButton.Name = "constantRadioButton";
            constantRadioButton.Size = new Size(137, 24);
            constantRadioButton.TabIndex = 3;
            constantRadioButton.TabStop = true;
            constantRadioButton.Text = "Constant Length";
            constantRadioButton.UseVisualStyleBackColor = true;
            constantRadioButton.CheckedChanged += constantRadioButton_CheckedChanged;
            // 
            // verticalRadioButton
            // 
            verticalRadioButton.AutoSize = true;
            verticalRadioButton.Location = new Point(18, 85);
            verticalRadioButton.Name = "verticalRadioButton";
            verticalRadioButton.Size = new Size(79, 24);
            verticalRadioButton.TabIndex = 2;
            verticalRadioButton.TabStop = true;
            verticalRadioButton.Text = "Vertical";
            verticalRadioButton.UseVisualStyleBackColor = true;
            verticalRadioButton.CheckedChanged += verticalRadioButton_CheckedChanged;
            // 
            // horizontalRadioButton
            // 
            horizontalRadioButton.AutoSize = true;
            horizontalRadioButton.Location = new Point(18, 55);
            horizontalRadioButton.Name = "horizontalRadioButton";
            horizontalRadioButton.Size = new Size(100, 24);
            horizontalRadioButton.TabIndex = 1;
            horizontalRadioButton.TabStop = true;
            horizontalRadioButton.Text = "Horizontal";
            horizontalRadioButton.UseVisualStyleBackColor = true;
            horizontalRadioButton.CheckedChanged += horizontalRadioButton_CheckedChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 23);
            label2.Name = "label2";
            label2.Size = new Size(105, 20);
            label2.TabIndex = 0;
            label2.Text = "Set constraints";
            // 
            // EditingPanel
            // 
            EditingPanel.BackColor = SystemColors.ActiveCaptionText;
            EditingPanel.ContextMenuStrip = contextMenu;
            EditingPanel.Dock = DockStyle.Fill;
            EditingPanel.Location = new Point(3, 3);
            EditingPanel.Name = "EditingPanel";
            EditingPanel.Size = new Size(875, 515);
            EditingPanel.TabIndex = 0;
            EditingPanel.Paint += EditingPanel_Paint;
            EditingPanel.MouseClick += EditingPanel_MouseClick;
            EditingPanel.MouseDoubleClick += EditingPanel_MouseDoubleClick;
            EditingPanel.MouseDown += EditingPanel_MouseDown;
            EditingPanel.MouseMove += EditingPanel_MouseMove;
            EditingPanel.MouseUp += EditingPanel_MouseUp;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 250F));
            tableLayoutPanel2.Controls.Add(tableLayoutPanel1, 1, 0);
            tableLayoutPanel2.Controls.Add(EditingPanel, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(1131, 521);
            tableLayoutPanel2.TabIndex = 3;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1131, 521);
            Controls.Add(tableLayoutPanel2);
            Name = "Form1";
            Text = "Form1";
            contextMenu.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private ContextMenuStrip contextMenu;
        private ToolStripMenuItem addVertexToolStripMenuItem;
        private ToolStripMenuItem removeVertexToolStripMenuItem;
        private TableLayoutPanel tableLayoutPanel1;
        private GroupBox groupBox1;
        private RadioButton LibraryButton;
        private Label label1;
        private RadioButton BresenhamButton;
        private GroupBox groupBox2;
        private Button clearButton;
        private RadioButton constantRadioButton;
        private RadioButton verticalRadioButton;
        private RadioButton horizontalRadioButton;
        private Label label2;
        private Panel EditingPanel;
        private TableLayoutPanel tableLayoutPanel2;
        private TextBox textBox1;
        private RadioButton bezierRadioButton;
        private ToolStripMenuItem addVertexConstraintToolStripMenuItem;
        private ToolStripMenuItem g0ToolStripMenuItem;
        private ToolStripMenuItem g1ToolStripMenuItem;
        private ToolStripMenuItem c1ToolStripMenuItem;
        private Button newPolygonButton;
        private GroupBox groupBox3;
        private Button ImplementationButton;
        private Button tutorialButton;
    }
}
