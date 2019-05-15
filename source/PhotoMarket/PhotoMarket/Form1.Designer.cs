namespace PhotoMarket
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.image_tool = new System.Windows.Forms.ToolStripDropDownButton();
            this.changeBackgroundImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeBackgroundImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.brushSizeChange_pic = new System.Windows.Forms.PictureBox();
            this.functionBtns_pic = new System.Windows.Forms.PictureBox();
            this.options_pic = new System.Windows.Forms.PictureBox();
            this.widthDemo_pic = new System.Windows.Forms.PictureBox();
            this.colorPallet_pic = new System.Windows.Forms.PictureBox();
            this.drawArea_pic = new System.Windows.Forms.PictureBox();
            this.file_tool = new System.Windows.Forms.ToolStripDropDownButton();
            this.exportImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Compress = new System.Windows.Forms.ToolStripButton();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.brushSizeChange_pic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.functionBtns_pic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.options_pic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.widthDemo_pic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorPallet_pic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drawArea_pic)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.file_tool,
            this.image_tool,
            this.Compress});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(584, 25);
            this.toolStrip.TabIndex = 24;
            this.toolStrip.Text = "toolStrip1";
            // 
            // image_tool
            // 
            this.image_tool.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeBackgroundImageToolStripMenuItem,
            this.removeBackgroundImageToolStripMenuItem});
            this.image_tool.Name = "image_tool";
            this.image_tool.Size = new System.Drawing.Size(53, 22);
            this.image_tool.Text = "Image";
            // 
            // changeBackgroundImageToolStripMenuItem
            // 
            this.changeBackgroundImageToolStripMenuItem.Name = "changeBackgroundImageToolStripMenuItem";
            this.changeBackgroundImageToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.changeBackgroundImageToolStripMenuItem.Text = "Change Background Image";
            this.changeBackgroundImageToolStripMenuItem.Click += new System.EventHandler(this.changeBackgroundImageToolStripMenuItem_Click);
            // 
            // removeBackgroundImageToolStripMenuItem
            // 
            this.removeBackgroundImageToolStripMenuItem.Name = "removeBackgroundImageToolStripMenuItem";
            this.removeBackgroundImageToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.removeBackgroundImageToolStripMenuItem.Text = "Remove Background Image";
            this.removeBackgroundImageToolStripMenuItem.Click += new System.EventHandler(this.removeBackgroundImageToolStripMenuItem_Click);
            // 
            // brushSizeChange_pic
            // 
            this.brushSizeChange_pic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.brushSizeChange_pic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.brushSizeChange_pic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.brushSizeChange_pic.Location = new System.Drawing.Point(540, 440);
            this.brushSizeChange_pic.Name = "brushSizeChange_pic";
            this.brushSizeChange_pic.Size = new System.Drawing.Size(40, 55);
            this.brushSizeChange_pic.TabIndex = 23;
            this.brushSizeChange_pic.TabStop = false;
            this.brushSizeChange_pic.Paint += new System.Windows.Forms.PaintEventHandler(this.BrushSizeChange_pic_Paint);
            this.brushSizeChange_pic.MouseClick += new System.Windows.Forms.MouseEventHandler(this.BrushSizeChange_pic_MouseClick);
            this.brushSizeChange_pic.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.BrushSizeChange_pic_MouseDoubleClick);
            // 
            // functionBtns_pic
            // 
            this.functionBtns_pic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.functionBtns_pic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.functionBtns_pic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.functionBtns_pic.Location = new System.Drawing.Point(490, 28);
            this.functionBtns_pic.Name = "functionBtns_pic";
            this.functionBtns_pic.Size = new System.Drawing.Size(90, 45);
            this.functionBtns_pic.TabIndex = 22;
            this.functionBtns_pic.TabStop = false;
            this.functionBtns_pic.Paint += new System.Windows.Forms.PaintEventHandler(this.FunctionBtns_pic_Paint);
            this.functionBtns_pic.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FunctionBtns_pic_MouseClick);
            // 
            // options_pic
            // 
            this.options_pic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.options_pic.Location = new System.Drawing.Point(10, 28);
            this.options_pic.Name = "options_pic";
            this.options_pic.Size = new System.Drawing.Size(354, 45);
            this.options_pic.TabIndex = 21;
            this.options_pic.TabStop = false;
            this.options_pic.Paint += new System.Windows.Forms.PaintEventHandler(this.Options_pic_Paint);
            this.options_pic.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Options_pic_MouseClick);
            // 
            // widthDemo_pic
            // 
            this.widthDemo_pic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.widthDemo_pic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.widthDemo_pic.InitialImage = null;
            this.widthDemo_pic.Location = new System.Drawing.Point(540, 509);
            this.widthDemo_pic.Name = "widthDemo_pic";
            this.widthDemo_pic.Size = new System.Drawing.Size(40, 40);
            this.widthDemo_pic.TabIndex = 18;
            this.widthDemo_pic.TabStop = false;
            this.widthDemo_pic.Paint += new System.Windows.Forms.PaintEventHandler(this.WidthDemo_pic_Paint);
            // 
            // colorPallet_pic
            // 
            this.colorPallet_pic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.colorPallet_pic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.colorPallet_pic.Location = new System.Drawing.Point(535, 79);
            this.colorPallet_pic.Name = "colorPallet_pic";
            this.colorPallet_pic.Size = new System.Drawing.Size(45, 324);
            this.colorPallet_pic.TabIndex = 10;
            this.colorPallet_pic.TabStop = false;
            this.colorPallet_pic.Paint += new System.Windows.Forms.PaintEventHandler(this.ColorPallet_pic_Paint);
            this.colorPallet_pic.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ColorPallet_pic_MouseClick);
            // 
            // drawArea_pic
            // 
            this.drawArea_pic.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.drawArea_pic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.drawArea_pic.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.drawArea_pic.Location = new System.Drawing.Point(10, 79);
            this.drawArea_pic.Name = "drawArea_pic";
            this.drawArea_pic.Size = new System.Drawing.Size(520, 470);
            this.drawArea_pic.TabIndex = 0;
            this.drawArea_pic.TabStop = false;
            this.drawArea_pic.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawArea_pic_Paint);
            this.drawArea_pic.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DrawArea_pic_MouseDown);
            this.drawArea_pic.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DrawArea_pic_MouseMove);
            this.drawArea_pic.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DrawArea_pic_MouseUp);
            // 
            // file_tool
            // 
            this.file_tool.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportImageToolStripMenuItem,
            this.saveProjectToolStripMenuItem,
            this.loadProjectToolStripMenuItem});
            this.file_tool.Name = "file_tool";
            this.file_tool.Size = new System.Drawing.Size(38, 22);
            this.file_tool.Text = "File";
            // 
            // exportImageToolStripMenuItem
            // 
            this.exportImageToolStripMenuItem.Name = "exportImageToolStripMenuItem";
            this.exportImageToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exportImageToolStripMenuItem.Text = "Export Image";
            this.exportImageToolStripMenuItem.Click += new System.EventHandler(this.ExportImageToolStripMenuItem_Click);
            // 
            // saveProjectToolStripMenuItem
            // 
            this.saveProjectToolStripMenuItem.Name = "saveProjectToolStripMenuItem";
            this.saveProjectToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveProjectToolStripMenuItem.Text = "Save Project";
            this.saveProjectToolStripMenuItem.Click += new System.EventHandler(this.SaveProjectToolStripMenuItem_Click);
            // 
            // loadProjectToolStripMenuItem
            // 
            this.loadProjectToolStripMenuItem.Name = "loadProjectToolStripMenuItem";
            this.loadProjectToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.loadProjectToolStripMenuItem.Text = "Load Project";
            this.loadProjectToolStripMenuItem.Click += new System.EventHandler(this.LoadProjectToolStripMenuItem_Click);
            // 
            // Compress
            // 
            this.Compress.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Compress.Image = ((System.Drawing.Image)(resources.GetObject("Compress.Image")));
            this.Compress.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Compress.Name = "Compress";
            this.Compress.Size = new System.Drawing.Size(81, 22);
            this.Compress.Text = "Compression";
            this.Compress.Click += new System.EventHandler(this.Compress_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.brushSizeChange_pic);
            this.Controls.Add(this.functionBtns_pic);
            this.Controls.Add(this.options_pic);
            this.Controls.Add(this.widthDemo_pic);
            this.Controls.Add(this.colorPallet_pic);
            this.Controls.Add(this.drawArea_pic);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(600, 600);
            this.Name = "Form1";
            this.Text = "PhotoMarket";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.brushSizeChange_pic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.functionBtns_pic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.options_pic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.widthDemo_pic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorPallet_pic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drawArea_pic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox drawArea_pic;
        private System.Windows.Forms.PictureBox colorPallet_pic;
        private System.Windows.Forms.PictureBox widthDemo_pic;
        private System.Windows.Forms.PictureBox options_pic;
        private System.Windows.Forms.PictureBox functionBtns_pic;
        private System.Windows.Forms.PictureBox brushSizeChange_pic;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripDropDownButton image_tool;
        private System.Windows.Forms.ToolStripMenuItem changeBackgroundImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeBackgroundImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton file_tool;
        private System.Windows.Forms.ToolStripMenuItem exportImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton Compress;
    }
}

