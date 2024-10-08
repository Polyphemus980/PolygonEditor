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
            menuStrip1 = new MenuStrip();
            polygonToolStripMenuItem = new ToolStripMenuItem();
            newPolygon = new ToolStripMenuItem();
            removePolygon = new ToolStripMenuItem();
            contextMenu.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // EditingPanel
            // 
            EditingPanel.BackColor = SystemColors.ActiveCaption;
            EditingPanel.ContextMenuStrip = contextMenu;
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
            removePolygon.Click += removeVertex_Click;
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
            contextMenu.ResumeLayout(false);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
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
    }
}
