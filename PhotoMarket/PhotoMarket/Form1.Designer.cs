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
            this.drawArea_pic = new System.Windows.Forms.PictureBox();
            this.colorPallet_pic = new System.Windows.Forms.PictureBox();
            this.widthDemo_pic = new System.Windows.Forms.PictureBox();
            this.options_pic = new System.Windows.Forms.PictureBox();
            this.functionBtns_pic = new System.Windows.Forms.PictureBox();
            this.brushSizeChange_pic = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.drawArea_pic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorPallet_pic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.widthDemo_pic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.options_pic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.functionBtns_pic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.brushSizeChange_pic)).BeginInit();
            this.SuspendLayout();
            // 
            // drawArea_pic
            // 
            this.drawArea_pic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.drawArea_pic.Cursor = System.Windows.Forms.Cursors.Cross;
            this.drawArea_pic.Location = new System.Drawing.Point(10, 50);
            this.drawArea_pic.Name = "drawArea_pic";
            this.drawArea_pic.Size = new System.Drawing.Size(1200, 620);
            this.drawArea_pic.TabIndex = 0;
            this.drawArea_pic.TabStop = false;
            this.drawArea_pic.Paint += new System.Windows.Forms.PaintEventHandler(this.drawArea_pic_Paint);
            this.drawArea_pic.MouseDown += new System.Windows.Forms.MouseEventHandler(this.drawArea_pic_MouseDown);
            this.drawArea_pic.MouseMove += new System.Windows.Forms.MouseEventHandler(this.drawArea_pic_MouseMove);
            this.drawArea_pic.MouseUp += new System.Windows.Forms.MouseEventHandler(this.drawArea_pic_MouseUp);
            // 
            // colorPallet_pic
            // 
            this.colorPallet_pic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.colorPallet_pic.Location = new System.Drawing.Point(1215, 50);
            this.colorPallet_pic.Name = "colorPallet_pic";
            this.colorPallet_pic.Size = new System.Drawing.Size(45, 340);
            this.colorPallet_pic.TabIndex = 10;
            this.colorPallet_pic.TabStop = false;
            this.colorPallet_pic.Paint += new System.Windows.Forms.PaintEventHandler(this.colorPallet_pic_Paint);
            this.colorPallet_pic.MouseClick += new System.Windows.Forms.MouseEventHandler(this.colorPallet_pic_MouseClick);
            // 
            // widthDemo_pic
            // 
            this.widthDemo_pic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.widthDemo_pic.InitialImage = null;
            this.widthDemo_pic.Location = new System.Drawing.Point(1220, 629);
            this.widthDemo_pic.Name = "widthDemo_pic";
            this.widthDemo_pic.Size = new System.Drawing.Size(40, 40);
            this.widthDemo_pic.TabIndex = 18;
            this.widthDemo_pic.TabStop = false;
            this.widthDemo_pic.Paint += new System.Windows.Forms.PaintEventHandler(this.widthDemo_pic_Paint);
            // 
            // options_pic
            // 
            this.options_pic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.options_pic.Location = new System.Drawing.Point(10, 2);
            this.options_pic.Name = "options_pic";
            this.options_pic.Size = new System.Drawing.Size(354, 45);
            this.options_pic.TabIndex = 21;
            this.options_pic.TabStop = false;
            this.options_pic.Paint += new System.Windows.Forms.PaintEventHandler(this.options_pic_Paint);
            this.options_pic.MouseClick += new System.Windows.Forms.MouseEventHandler(this.options_pic_MouseClick);
            // 
            // functionBtns_pic
            // 
            this.functionBtns_pic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.functionBtns_pic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.functionBtns_pic.Location = new System.Drawing.Point(1120, 2);
            this.functionBtns_pic.Name = "functionBtns_pic";
            this.functionBtns_pic.Size = new System.Drawing.Size(140, 45);
            this.functionBtns_pic.TabIndex = 22;
            this.functionBtns_pic.TabStop = false;
            this.functionBtns_pic.Paint += new System.Windows.Forms.PaintEventHandler(this.functionBtns_pic_Paint);
            this.functionBtns_pic.MouseClick += new System.Windows.Forms.MouseEventHandler(this.functionBtns_pic_MouseClick);
            // 
            // brushSizeChange_pic
            // 
            this.brushSizeChange_pic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.brushSizeChange_pic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.brushSizeChange_pic.Location = new System.Drawing.Point(1220, 560);
            this.brushSizeChange_pic.Name = "brushSizeChange_pic";
            this.brushSizeChange_pic.Size = new System.Drawing.Size(40, 55);
            this.brushSizeChange_pic.TabIndex = 23;
            this.brushSizeChange_pic.TabStop = false;
            this.brushSizeChange_pic.Paint += new System.Windows.Forms.PaintEventHandler(this.brushSizeChange_pic_Paint);
            this.brushSizeChange_pic.MouseClick += new System.Windows.Forms.MouseEventHandler(this.brushSizeChange_pic_MouseClick);
            this.brushSizeChange_pic.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.brushSizeChange_pic_MouseDoubleClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.brushSizeChange_pic);
            this.Controls.Add(this.functionBtns_pic);
            this.Controls.Add(this.options_pic);
            this.Controls.Add(this.widthDemo_pic);
            this.Controls.Add(this.colorPallet_pic);
            this.Controls.Add(this.drawArea_pic);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "PhotoMarket";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.drawArea_pic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorPallet_pic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.widthDemo_pic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.options_pic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.functionBtns_pic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.brushSizeChange_pic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox drawArea_pic;
        private System.Windows.Forms.PictureBox colorPallet_pic;
        private System.Windows.Forms.PictureBox widthDemo_pic;
        private System.Windows.Forms.PictureBox options_pic;
        private System.Windows.Forms.PictureBox functionBtns_pic;
        private System.Windows.Forms.PictureBox brushSizeChange_pic;
    }
}

