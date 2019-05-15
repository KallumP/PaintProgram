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
            this.showColor_pic = new System.Windows.Forms.PictureBox();
            this.colorPicker_pic = new System.Windows.Forms.PictureBox();
            this.chooseColor_btn = new System.Windows.Forms.Button();
            this.Alpha_bar = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Blue_bar = new System.Windows.Forms.TrackBar();
            this.Green_bar = new System.Windows.Forms.TrackBar();
            this.Red_bar = new System.Windows.Forms.TrackBar();
            this.hexValue_txt = new System.Windows.Forms.TextBox();
            this.CheckHex_btn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.showColor_pic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorPicker_pic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Alpha_bar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Blue_bar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Green_bar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Red_bar)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(233, 333);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "This will be your color:";
            // 
            // chosenColor_lbl
            // 
            this.chosenColor_lbl.AutoSize = true;
            this.chosenColor_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chosenColor_lbl.Location = new System.Drawing.Point(258, 365);
            this.chosenColor_lbl.Name = "chosenColor_lbl";
            this.chosenColor_lbl.Size = new System.Drawing.Size(112, 20);
            this.chosenColor_lbl.TabIndex = 3;
            this.chosenColor_lbl.Text = "XX-XX-XX-XX";
            // 
            // showColor_pic
            // 
            this.showColor_pic.Location = new System.Drawing.Point(237, 403);
            this.showColor_pic.Name = "showColor_pic";
            this.showColor_pic.Size = new System.Drawing.Size(156, 46);
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
            this.colorPicker_pic.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ColorPicker_pic_MouseDown);
            this.colorPicker_pic.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ColorPicker_pic_MouseMove);
            this.colorPicker_pic.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ColorPicker_pic_MouseUp);
            // 
            // chooseColor_btn
            // 
            this.chooseColor_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chooseColor_btn.Location = new System.Drawing.Point(461, 403);
            this.chooseColor_btn.Name = "chooseColor_btn";
            this.chooseColor_btn.Size = new System.Drawing.Size(141, 46);
            this.chooseColor_btn.TabIndex = 7;
            this.chooseColor_btn.Text = "Choose Color";
            this.chooseColor_btn.UseVisualStyleBackColor = true;
            this.chooseColor_btn.Click += new System.EventHandler(this.ChooseColor_btn_Click);
            // 
            // Alpha_bar
            // 
            this.Alpha_bar.Location = new System.Drawing.Point(341, 40);
            this.Alpha_bar.Maximum = 255;
            this.Alpha_bar.Name = "Alpha_bar";
            this.Alpha_bar.Size = new System.Drawing.Size(237, 45);
            this.Alpha_bar.TabIndex = 8;
            this.Alpha_bar.Scroll += new System.EventHandler(this.Alpha_bar_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(588, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Alpha";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(589, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Green";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(588, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Red";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(588, 265);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "Blue";
            // 
            // Blue_bar
            // 
            this.Blue_bar.Location = new System.Drawing.Point(341, 265);
            this.Blue_bar.Maximum = 255;
            this.Blue_bar.Name = "Blue_bar";
            this.Blue_bar.Size = new System.Drawing.Size(237, 45);
            this.Blue_bar.TabIndex = 13;
            this.Blue_bar.Scroll += new System.EventHandler(this.Blue_bar_Scroll);
            // 
            // Green_bar
            // 
            this.Green_bar.Location = new System.Drawing.Point(341, 190);
            this.Green_bar.Maximum = 255;
            this.Green_bar.Name = "Green_bar";
            this.Green_bar.Size = new System.Drawing.Size(237, 45);
            this.Green_bar.TabIndex = 14;
            this.Green_bar.Scroll += new System.EventHandler(this.Green_bar_Scroll);
            // 
            // Red_bar
            // 
            this.Red_bar.Location = new System.Drawing.Point(341, 115);
            this.Red_bar.Maximum = 255;
            this.Red_bar.Name = "Red_bar";
            this.Red_bar.Size = new System.Drawing.Size(237, 45);
            this.Red_bar.TabIndex = 15;
            this.Red_bar.Scroll += new System.EventHandler(this.Red_bar_Scroll);
            // 
            // hexValue_txt
            // 
            this.hexValue_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hexValue_txt.Location = new System.Drawing.Point(16, 365);
            this.hexValue_txt.Name = "hexValue_txt";
            this.hexValue_txt.Size = new System.Drawing.Size(163, 26);
            this.hexValue_txt.TabIndex = 16;
            // 
            // CheckHex_btn
            // 
            this.CheckHex_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckHex_btn.Location = new System.Drawing.Point(12, 403);
            this.CheckHex_btn.Name = "CheckHex_btn";
            this.CheckHex_btn.Size = new System.Drawing.Size(167, 46);
            this.CheckHex_btn.TabIndex = 17;
            this.CheckHex_btn.Text = "Check Hex";
            this.CheckHex_btn.UseVisualStyleBackColor = true;
            this.CheckHex_btn.Click += new System.EventHandler(this.CheckHex_btn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 333);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 20);
            this.label2.TabIndex = 18;
            this.label2.Text = "Enter a hex value here";
            // 
            // ColorPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 461);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CheckHex_btn);
            this.Controls.Add(this.hexValue_txt);
            this.Controls.Add(this.Red_bar);
            this.Controls.Add(this.Green_bar);
            this.Controls.Add(this.Blue_bar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Alpha_bar);
            this.Controls.Add(this.chooseColor_btn);
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
            ((System.ComponentModel.ISupportInitialize)(this.Alpha_bar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Blue_bar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Green_bar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Red_bar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox colorPicker_pic;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox showColor_pic;
        private System.Windows.Forms.Label chosenColor_lbl;
        private System.Windows.Forms.Button chooseColor_btn;
        private System.Windows.Forms.TrackBar Alpha_bar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TrackBar Blue_bar;
        private System.Windows.Forms.TrackBar Green_bar;
        private System.Windows.Forms.TrackBar Red_bar;
        private System.Windows.Forms.TextBox hexValue_txt;
        private System.Windows.Forms.Button CheckHex_btn;
        private System.Windows.Forms.Label label2;
    }
}