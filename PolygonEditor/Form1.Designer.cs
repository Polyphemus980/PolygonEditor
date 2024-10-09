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
            EditingPanel = new Panel();
            contextMenu = new ContextMenuStrip(components);
            addVertexToolStripMenuItem = new ToolStripMenuItem();
            removeVertexToolStripMenuItem = new ToolStripMenuItem();
            label1 = new Label();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            menuStrip1 = new MenuStrip();
            polygonToolStripMenuItem = new ToolStripMenuItem();
            newPolygon = new ToolStripMenuItem();
            removePolygon = new ToolStripMenuItem();
            groupBox1 = new GroupBox();
            EditingPanel.SuspendLayout();
            contextMenu.SuspendLayout();
            menuStrip1.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // EditingPanel
            // 
            EditingPanel.BackColor = SystemColors.ActiveCaptionText;
            EditingPanel.ContextMenuStrip = contextMenu;
            EditingPanel.Controls.Add(groupBox1);
            EditingPanel.Dock = DockStyle.Fill;
            EditingPanel.Location = new Point(0, 28);
            EditingPanel.Name = "EditingPanel";
            EditingPanel.Size = new Size(800, 422);
            EditingPanel.TabIndex = 0;
            EditingPanel.Paint += EditingPanel_Paint;
            EditingPanel.MouseDoubleClick += EditingPanel_MouseDoubleClick;
            EditingPanel.MouseDown += EditingPanel_MouseDown;
            EditingPanel.MouseMove += EditingPanel_MouseMove;
            EditingPanel.MouseUp += EditingPanel_MouseUp;
            // 
            // contextMenu
            // 
            contextMenu.ImageScalingSize = new Size(20, 20);
            contextMenu.Items.AddRange(new ToolStripItem[] { addVertexToolStripMenuItem, removeVertexToolStripMenuItem });
            contextMenu.Name = "contextMenu";
            contextMenu.Size = new Size(177, 52);
            // 
            // addVertexToolStripMenuItem
            // 
            addVertexToolStripMenuItem.Name = "addVertexToolStripMenuItem";
            addVertexToolStripMenuItem.Size = new Size(176, 24);
            addVertexToolStripMenuItem.Text = "Add vertex";
            addVertexToolStripMenuItem.Click += addVertexToolStripMenuItem_Click;
            // 
            // removeVertexToolStripMenuItem
            // 
            removeVertexToolStripMenuItem.Name = "removeVertexToolStripMenuItem";
            removeVertexToolStripMenuItem.Size = new Size(176, 24);
            removeVertexToolStripMenuItem.Text = "Remove vertex";
            removeVertexToolStripMenuItem.Click += removeVertex_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(18, 23);
            label1.Name = "label1";
            label1.Size = new Size(185, 20);
            label1.TabIndex = 2;
            label1.Text = "Choose drawing algorithm";
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.ForeColor = SystemColors.ButtonHighlight;
            radioButton2.Location = new Point(18, 95);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(144, 24);
            radioButton2.TabIndex = 1;
            radioButton2.TabStop = true;
            radioButton2.Text = "Library algorithm";
            radioButton2.UseVisualStyleBackColor = true;
            radioButton2.CheckedChanged += radioButton2_CheckedChanged;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.ForeColor = SystemColors.ButtonHighlight;
            radioButton1.Location = new Point(18, 65);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(103, 24);
            radioButton1.TabIndex = 0;
            radioButton1.TabStop = true;
            radioButton1.Text = "Bresenham";
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { polygonToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 28);
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
            // groupBox1
            // 
            groupBox1.Controls.Add(radioButton2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(radioButton1);
            groupBox1.Location = new Point(12, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(250, 125);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "groupBox1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(EditingPanel);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            EditingPanel.ResumeLayout(false);
            contextMenu.ResumeLayout(false);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel EditingPanel;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem polygonToolStripMenuItem;
        private ToolStripMenuItem newPolygon;
        private ToolStripMenuItem removePolygon;
        private ContextMenuStrip contextMenu;
        private ToolStripMenuItem addVertexToolStripMenuItem;
        private ToolStripMenuItem removeVertexToolStripMenuItem;
        private Label label1;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private GroupBox groupBox1;
    }
}
