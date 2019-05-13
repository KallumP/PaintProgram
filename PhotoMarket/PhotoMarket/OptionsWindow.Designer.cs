namespace PhotoMarket {
    partial class OptionsWindow {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsWindow));
            this.label1 = new System.Windows.Forms.Label();
            this.Export_btn = new System.Windows.Forms.Button();
            this.save_btn = new System.Windows.Forms.Button();
            this.cancel_btn = new System.Windows.Forms.Button();
            this.changeBackImg_btn = new System.Windows.Forms.Button();
            this.load_btn = new System.Windows.Forms.Button();
            this.removeBackground_btn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.newCompression_txt = new System.Windows.Forms.TextBox();
            this.changeCompression_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(386, 77);
            this.label1.TabIndex = 0;
            this.label1.Text = "Would you like to save the project, or export the image?";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Export_btn
            // 
            this.Export_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Export_btn.Location = new System.Drawing.Point(12, 89);
            this.Export_btn.Name = "Export_btn";
            this.Export_btn.Size = new System.Drawing.Size(119, 53);
            this.Export_btn.TabIndex = 1;
            this.Export_btn.Text = "Export Image";
            this.Export_btn.UseVisualStyleBackColor = true;
            this.Export_btn.Click += new System.EventHandler(this.Export_btn_Click);
            // 
            // save_btn
            // 
            this.save_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.save_btn.Location = new System.Drawing.Point(146, 89);
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(119, 53);
            this.save_btn.TabIndex = 2;
            this.save_btn.Text = "Save Project";
            this.save_btn.UseVisualStyleBackColor = true;
            this.save_btn.Click += new System.EventHandler(this.Save_btn_Click);
            // 
            // cancel_btn
            // 
            this.cancel_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancel_btn.Location = new System.Drawing.Point(277, 148);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(119, 79);
            this.cancel_btn.TabIndex = 3;
            this.cancel_btn.Text = "Close";
            this.cancel_btn.UseVisualStyleBackColor = true;
            this.cancel_btn.Click += new System.EventHandler(this.Cancel_btn_Click);
            // 
            // changeBackImg_btn
            // 
            this.changeBackImg_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.changeBackImg_btn.Location = new System.Drawing.Point(12, 148);
            this.changeBackImg_btn.Name = "changeBackImg_btn";
            this.changeBackImg_btn.Size = new System.Drawing.Size(119, 79);
            this.changeBackImg_btn.TabIndex = 4;
            this.changeBackImg_btn.Text = "Change Background Image";
            this.changeBackImg_btn.UseVisualStyleBackColor = true;
            this.changeBackImg_btn.Click += new System.EventHandler(this.ChangeBackImg_btn_Click);
            // 
            // load_btn
            // 
            this.load_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.load_btn.Location = new System.Drawing.Point(277, 89);
            this.load_btn.Name = "load_btn";
            this.load_btn.Size = new System.Drawing.Size(119, 53);
            this.load_btn.TabIndex = 5;
            this.load_btn.Text = "Load Project";
            this.load_btn.UseVisualStyleBackColor = true;
            this.load_btn.Click += new System.EventHandler(this.Load_btn_Click);
            // 
            // removeBackground_btn
            // 
            this.removeBackground_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removeBackground_btn.Location = new System.Drawing.Point(146, 148);
            this.removeBackground_btn.Name = "removeBackground_btn";
            this.removeBackground_btn.Size = new System.Drawing.Size(119, 79);
            this.removeBackground_btn.TabIndex = 6;
            this.removeBackground_btn.Text = "Remove Background Image";
            this.removeBackground_btn.UseVisualStyleBackColor = true;
            this.removeBackground_btn.Click += new System.EventHandler(this.RemoveBackground_btn_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 271);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(241, 50);
            this.label2.TabIndex = 7;
            this.label2.Text = "Change pen compression length (enter 0 for no compression)";
            // 
            // newCompression_txt
            // 
            this.newCompression_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newCompression_txt.Location = new System.Drawing.Point(13, 331);
            this.newCompression_txt.Name = "newCompression_txt";
            this.newCompression_txt.Size = new System.Drawing.Size(119, 26);
            this.newCompression_txt.TabIndex = 8;
            // 
            // changeCompression_btn
            // 
            this.changeCompression_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.changeCompression_btn.Location = new System.Drawing.Point(161, 317);
            this.changeCompression_btn.Name = "changeCompression_btn";
            this.changeCompression_btn.Size = new System.Drawing.Size(89, 40);
            this.changeCompression_btn.TabIndex = 9;
            this.changeCompression_btn.Text = "Change";
            this.changeCompression_btn.UseVisualStyleBackColor = true;
            this.changeCompression_btn.Click += new System.EventHandler(this.button1_Click);
            // 
            // OptionsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 411);
            this.Controls.Add(this.changeCompression_btn);
            this.Controls.Add(this.newCompression_txt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.removeBackground_btn);
            this.Controls.Add(this.load_btn);
            this.Controls.Add(this.changeBackImg_btn);
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.save_btn);
            this.Controls.Add(this.Export_btn);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OptionsWindow";
            this.Text = "Options";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Export_btn;
        private System.Windows.Forms.Button save_btn;
        private System.Windows.Forms.Button cancel_btn;
        private System.Windows.Forms.Button changeBackImg_btn;
        private System.Windows.Forms.Button load_btn;
        private System.Windows.Forms.Button removeBackground_btn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox newCompression_txt;
        private System.Windows.Forms.Button changeCompression_btn;
    }
}