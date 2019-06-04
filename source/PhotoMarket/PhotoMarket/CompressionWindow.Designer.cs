namespace PhotoMarket {
    partial class CompressionWindow {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompressionWindow));
            this.label1 = new System.Windows.Forms.Label();
            this.cancel_btn = new System.Windows.Forms.Button();
            this.newCompression_txt = new System.Windows.Forms.TextBox();
            this.changeCompression_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(386, 77);
            this.label1.TabIndex = 0;
            this.label1.Text = "Change pen compression length (enter 0 for no compression)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cancel_btn
            // 
            this.cancel_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancel_btn.Location = new System.Drawing.Point(277, 95);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(119, 40);
            this.cancel_btn.TabIndex = 3;
            this.cancel_btn.Text = "Close";
            this.cancel_btn.UseVisualStyleBackColor = true;
            this.cancel_btn.Click += new System.EventHandler(this.Cancel_btn_Click);
            // 
            // newCompression_txt
            // 
            this.newCompression_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newCompression_txt.Location = new System.Drawing.Point(12, 102);
            this.newCompression_txt.Name = "newCompression_txt";
            this.newCompression_txt.Size = new System.Drawing.Size(119, 26);
            this.newCompression_txt.TabIndex = 8;
            // 
            // changeCompression_btn
            // 
            this.changeCompression_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.changeCompression_btn.Location = new System.Drawing.Point(137, 95);
            this.changeCompression_btn.Name = "changeCompression_btn";
            this.changeCompression_btn.Size = new System.Drawing.Size(134, 40);
            this.changeCompression_btn.TabIndex = 9;
            this.changeCompression_btn.Text = "Change";
            this.changeCompression_btn.UseVisualStyleBackColor = true;
            this.changeCompression_btn.Click += new System.EventHandler(this.button1_Click);
            // 
            // CompressionWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 148);
            this.Controls.Add(this.changeCompression_btn);
            this.Controls.Add(this.newCompression_txt);
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CompressionWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Compression Change";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cancel_btn;
        private System.Windows.Forms.TextBox newCompression_txt;
        private System.Windows.Forms.Button changeCompression_btn;
    }
}