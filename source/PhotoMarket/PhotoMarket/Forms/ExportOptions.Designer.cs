namespace PhotoMarket.Forms {
    partial class ExportOptions {
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
            this.defaultSize_btn = new System.Windows.Forms.Button();
            this.saveImage_btn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.height_txt = new System.Windows.Forms.TextBox();
            this.width_txt = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // defaultSize_btn
            // 
            this.defaultSize_btn.BackColor = System.Drawing.Color.Transparent;
            this.defaultSize_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.defaultSize_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.defaultSize_btn.ForeColor = System.Drawing.Color.Black;
            this.defaultSize_btn.Location = new System.Drawing.Point(41, 13);
            this.defaultSize_btn.Name = "defaultSize_btn";
            this.defaultSize_btn.Size = new System.Drawing.Size(172, 54);
            this.defaultSize_btn.TabIndex = 11;
            this.defaultSize_btn.Text = "Choose project canvas size";
            this.defaultSize_btn.UseVisualStyleBackColor = false;
            this.defaultSize_btn.Click += new System.EventHandler(this.defaultSize_btn_Click);
            // 
            // saveImage_btn
            // 
            this.saveImage_btn.BackColor = System.Drawing.Color.Transparent;
            this.saveImage_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveImage_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveImage_btn.ForeColor = System.Drawing.Color.Black;
            this.saveImage_btn.Location = new System.Drawing.Point(41, 249);
            this.saveImage_btn.Name = "saveImage_btn";
            this.saveImage_btn.Size = new System.Drawing.Size(172, 36);
            this.saveImage_btn.TabIndex = 10;
            this.saveImage_btn.Text = "Save";
            this.saveImage_btn.UseVisualStyleBackColor = false;
            this.saveImage_btn.Click += new System.EventHandler(this.saveImage_btn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(37, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Height (px)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(37, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Width (px)";
            // 
            // height_txt
            // 
            this.height_txt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.height_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.height_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.height_txt.ForeColor = System.Drawing.Color.Black;
            this.height_txt.Location = new System.Drawing.Point(41, 181);
            this.height_txt.Name = "height_txt";
            this.height_txt.Size = new System.Drawing.Size(172, 26);
            this.height_txt.TabIndex = 7;
            // 
            // width_txt
            // 
            this.width_txt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.width_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.width_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.width_txt.ForeColor = System.Drawing.Color.Black;
            this.width_txt.Location = new System.Drawing.Point(41, 112);
            this.width_txt.Name = "width_txt";
            this.width_txt.Size = new System.Drawing.Size(172, 26);
            this.width_txt.TabIndex = 6;
            // 
            // ExportOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(250, 298);
            this.Controls.Add(this.defaultSize_btn);
            this.Controls.Add(this.saveImage_btn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.height_txt);
            this.Controls.Add(this.width_txt);
            this.Name = "ExportOptions";
            this.Text = "ExportOptions";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button defaultSize_btn;
        private System.Windows.Forms.Button saveImage_btn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox height_txt;
        private System.Windows.Forms.TextBox width_txt;
    }
}