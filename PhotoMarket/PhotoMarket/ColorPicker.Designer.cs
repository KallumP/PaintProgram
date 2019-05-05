namespace PhotoMarket {
    partial class ColorPicker {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ColorPicker));
            this.label1 = new System.Windows.Forms.Label();
            this.chosenColor_lbl = new System.Windows.Forms.Label();
            this.hexValue_txt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkHex_btn = new System.Windows.Forms.Button();
            this.showColor_pic = new System.Windows.Forms.PictureBox();
            this.colorPicker_pic = new System.Windows.Forms.PictureBox();
            this.chooseColor_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.showColor_pic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorPicker_pic)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 380);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "This will be your color:";
            // 
            // chosenColor_lbl
            // 
            this.chosenColor_lbl.AutoSize = true;
            this.chosenColor_lbl.Location = new System.Drawing.Point(127, 380);
            this.chosenColor_lbl.Name = "chosenColor_lbl";
            this.chosenColor_lbl.Size = new System.Drawing.Size(35, 13);
            this.chosenColor_lbl.TabIndex = 3;
            this.chosenColor_lbl.Text = "label2";
            // 
            // hexValue_txt
            // 
            this.hexValue_txt.Location = new System.Drawing.Point(91, 326);
            this.hexValue_txt.Name = "hexValue_txt";
            this.hexValue_txt.Size = new System.Drawing.Size(147, 20);
            this.hexValue_txt.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 329);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Choose a hex:";
            // 
            // checkHex_btn
            // 
            this.checkHex_btn.Location = new System.Drawing.Point(244, 325);
            this.checkHex_btn.Name = "checkHex_btn";
            this.checkHex_btn.Size = new System.Drawing.Size(69, 22);
            this.checkHex_btn.TabIndex = 6;
            this.checkHex_btn.Text = "Check";
            this.checkHex_btn.UseVisualStyleBackColor = true;
            this.checkHex_btn.Click += new System.EventHandler(this.checkHex_btn_Click);
            // 
            // showColor_pic
            // 
            this.showColor_pic.Location = new System.Drawing.Point(223, 366);
            this.showColor_pic.Name = "showColor_pic";
            this.showColor_pic.Size = new System.Drawing.Size(90, 44);
            this.showColor_pic.TabIndex = 2;
            this.showColor_pic.TabStop = false;
            // 
            // colorPicker_pic
            // 
            this.colorPicker_pic.Image = global::PhotoMarket.Properties.Resources._ColorPicker;
            this.colorPicker_pic.Location = new System.Drawing.Point(13, 13);
            this.colorPicker_pic.Name = "colorPicker_pic";
            this.colorPicker_pic.Size = new System.Drawing.Size(300, 300);
            this.colorPicker_pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.colorPicker_pic.TabIndex = 0;
            this.colorPicker_pic.TabStop = false;
            this.colorPicker_pic.MouseDown += new System.Windows.Forms.MouseEventHandler(this.colorPicker_pic_MouseDown);
            this.colorPicker_pic.MouseMove += new System.Windows.Forms.MouseEventHandler(this.colorPicker_pic_MouseMove);
            this.colorPicker_pic.MouseUp += new System.Windows.Forms.MouseEventHandler(this.colorPicker_pic_MouseUp);
            // 
            // chooseColor_btn
            // 
            this.chooseColor_btn.Location = new System.Drawing.Point(91, 425);
            this.chooseColor_btn.Name = "chooseColor_btn";
            this.chooseColor_btn.Size = new System.Drawing.Size(147, 39);
            this.chooseColor_btn.TabIndex = 7;
            this.chooseColor_btn.Text = "Choose Color";
            this.chooseColor_btn.UseVisualStyleBackColor = true;
            this.chooseColor_btn.Click += new System.EventHandler(this.chooseColor_btn_Click);
            // 
            // ColorPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 476);
            this.Controls.Add(this.chooseColor_btn);
            this.Controls.Add(this.checkHex_btn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.hexValue_txt);
            this.Controls.Add(this.chosenColor_lbl);
            this.Controls.Add(this.showColor_pic);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.colorPicker_pic);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ColorPicker";
            this.Text = "ColorPicker";
            this.Load += new System.EventHandler(this.ColorPicker_Load);
            ((System.ComponentModel.ISupportInitialize)(this.showColor_pic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorPicker_pic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox colorPicker_pic;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox showColor_pic;
        private System.Windows.Forms.Label chosenColor_lbl;
        private System.Windows.Forms.TextBox hexValue_txt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button checkHex_btn;
        private System.Windows.Forms.Button chooseColor_btn;
    }
}