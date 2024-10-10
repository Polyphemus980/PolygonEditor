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
            menuStrip1 = new MenuStrip();
            polygonToolStripMenuItem = new ToolStripMenuItem();
            newPolygon = new ToolStripMenuItem();
            removePolygon = new ToolStripMenuItem();
            tableLayoutPanel1 = new TableLayoutPanel();
            groupBox1 = new GroupBox();
            radioButton2 = new RadioButton();
            label1 = new Label();
            radioButton1 = new RadioButton();
            groupBox2 = new GroupBox();
            clearButton = new Button();
            constantRadioButton = new RadioButton();
            verticalRadioButton = new RadioButton();
            horizontalRadioButton = new RadioButton();
            label2 = new Label();
            EditingPanel = new Panel();
            tableLayoutPanel2 = new TableLayoutPanel();
            contextMenu.SuspendLayout();
            menuStrip1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // contextMenu
            // 
            contextMenu.ImageScalingSize = new Size(20, 20);
            contextMenu.Items.AddRange(new ToolStripItem[] { addVertexToolStripMenuItem, removeVertexToolStripMenuItem });
            contextMenu.Name = "contextMenu";
            contextMenu.Size = new Size(229, 52);
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
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { polygonToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1131, 28);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // polygonToolStripMenuItem
            // 
            polygonToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newPolygon, removePolygon });
            polygonToolStripMenuItem.Name = "polygonToolStripMenuItem";
            polygonToolStripMenuItem.Size = new Size(76, 24);
            polygonToolStripMenuItem.Text = "Polygon";
            // 
            // newPolygon
            // 
            newPolygon.Name = "newPolygon";
            newPolygon.Size = new Size(146, 26);
            newPolygon.Text = "New";
            newPolygon.Click += newPolygon_Click;
            // 
            // removePolygon
            // 
            removePolygon.Name = "removePolygon";
            removePolygon.Size = new Size(146, 26);
            removePolygon.Text = "Remove";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(groupBox1, 0, 0);
            tableLayoutPanel1.Controls.Add(groupBox2, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(884, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 150F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(244, 487);
            tableLayoutPanel1.TabIndex = 4;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radioButton2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(radioButton1);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(238, 144);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.ForeColor = SystemColors.ActiveCaptionText;
            radioButton2.Location = new Point(18, 95);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(144, 24);
            radioButton2.TabIndex = 1;
            radioButton2.Text = "Library algorithm";
            radioButton2.UseVisualStyleBackColor = true;
            radioButton2.CheckedChanged += radioButton2_CheckedChanged;
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
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Checked = true;
            radioButton1.ForeColor = SystemColors.ActiveCaptionText;
            radioButton1.Location = new Point(18, 65);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(103, 24);
            radioButton1.TabIndex = 0;
            radioButton1.TabStop = true;
            radioButton1.Text = "Bresenham";
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(clearButton);
            groupBox2.Controls.Add(constantRadioButton);
            groupBox2.Controls.Add(verticalRadioButton);
            groupBox2.Controls.Add(horizontalRadioButton);
            groupBox2.Controls.Add(label2);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Location = new Point(3, 153);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(238, 331);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            // 
            // clearButton
            // 
            clearButton.Location = new Point(18, 157);
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
            constantRadioButton.CheckedChanged += ConstantRadioButton_CheckedChanged;
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
            verticalRadioButton.CheckedChanged += VerticalRadioButton_CheckedChanged;
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
            horizontalRadioButton.CheckedChanged += HorizontalRadioButton_CheckedChanged;
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
            EditingPanel.Size = new Size(875, 487);
            EditingPanel.TabIndex = 0;
            EditingPanel.Paint += EditingPanel_Paint;
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
            tableLayoutPanel2.Location = new Point(0, 28);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(1131, 493);
            tableLayoutPanel2.TabIndex = 3;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1131, 521);
            Controls.Add(tableLayoutPanel2);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            contextMenu.ResumeLayout(false);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MenuStrip menuStrip1;
        private ToolStripMenuItem polygonToolStripMenuItem;
        private ToolStripMenuItem newPolygon;
        private ToolStripMenuItem removePolygon;
        private ContextMenuStrip contextMenu;
        private ToolStripMenuItem addVertexToolStripMenuItem;
        private ToolStripMenuItem removeVertexToolStripMenuItem;
        private TableLayoutPanel tableLayoutPanel1;
        private GroupBox groupBox1;
        private RadioButton radioButton2;
        private Label label1;
        private RadioButton radioButton1;
        private GroupBox groupBox2;
        private Button clearButton;
        private RadioButton constantRadioButton;
        private RadioButton verticalRadioButton;
        private RadioButton horizontalRadioButton;
        private Label label2;
        private Panel EditingPanel;
        private TableLayoutPanel tableLayoutPanel2;
    }
}
