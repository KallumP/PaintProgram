namespace PhotoMarket
{
    partial class BrushSize
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.brushSize_bar = new System.Windows.Forms.TrackBar();
            this.lable1 = new System.Windows.Forms.Label();
            this.newSize_txt = new System.Windows.Forms.TextBox();
            this.select_btn = new System.Windows.Forms.Button();
            this.cancel_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.brushSize_bar)).BeginInit();
            this.SuspendLayout();
            // 
            // brushSize_bar
            // 
            this.brushSize_bar.Location = new System.Drawing.Point(12, 25);
            this.brushSize_bar.Maximum = 100;
            this.brushSize_bar.Minimum = 1;
            this.brushSize_bar.Name = "brushSize_bar";
            this.brushSize_bar.Size = new System.Drawing.Size(442, 45);
            this.brushSize_bar.TabIndex = 0;
            this.brushSize_bar.Value = 1;
            this.brushSize_bar.Scroll += new System.EventHandler(this.BrushSize_bar_Scroll);
            // 
            // lable1
            // 
            this.lable1.AutoSize = true;
            this.lable1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lable1.Location = new System.Drawing.Point(12, 93);
            this.lable1.Name = "lable1";
            this.lable1.Size = new System.Drawing.Size(117, 20);
            this.lable1.TabIndex = 1;
            this.lable1.Text = "Brush size (px):";
            // 
            // newSize_txt
            // 
            this.newSize_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newSize_txt.Location = new System.Drawing.Point(135, 90);
            this.newSize_txt.Name = "newSize_txt";
            this.newSize_txt.Size = new System.Drawing.Size(74, 26);
            this.newSize_txt.TabIndex = 2;
            this.newSize_txt.TextChanged += new System.EventHandler(this.NewSize_txt_TextChanged);
            // 
            // select_btn
            // 
            this.select_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.select_btn.Location = new System.Drawing.Point(270, 86);
            this.select_btn.Name = "select_btn";
            this.select_btn.Size = new System.Drawing.Size(81, 34);
            this.select_btn.TabIndex = 3;
            this.select_btn.Text = "Select";
            this.select_btn.UseVisualStyleBackColor = true;
            this.select_btn.Click += new System.EventHandler(this.Select_btn_Click);
            // 
            // cancel_btn
            // 
            this.cancel_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancel_btn.Location = new System.Drawing.Point(374, 86);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(81, 34);
            this.cancel_btn.TabIndex = 4;
            this.cancel_btn.Text = "Cancel";
            this.cancel_btn.UseVisualStyleBackColor = true;
            this.cancel_btn.Click += new System.EventHandler(this.Cancel_btn_Click);
            // 
            // BrushSize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 146);
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.select_btn);
            this.Controls.Add(this.newSize_txt);
            this.Controls.Add(this.lable1);
            this.Controls.Add(this.brushSize_bar);
            this.Name = "BrushSize";
            this.Text = "BrushSize";
            ((System.ComponentModel.ISupportInitialize)(this.brushSize_bar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar brushSize_bar;
        private System.Windows.Forms.Label lable1;
        private System.Windows.Forms.TextBox newSize_txt;
        private System.Windows.Forms.Button select_btn;
        private System.Windows.Forms.Button cancel_btn;
    }
}