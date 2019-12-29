namespace PhotoMarket {
    partial class LayerControlWindow {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LayerControlWindow));
            this.layersList = new System.Windows.Forms.ListBox();
            this.layerUp_btn = new System.Windows.Forms.Button();
            this.layerDown_btn = new System.Windows.Forms.Button();
            this.deleteLayer_btn = new System.Windows.Forms.Button();
            this.newLayer_btn = new System.Windows.Forms.Button();
            this.currentlyDrawingTo_lbl = new System.Windows.Forms.Label();
            this.renameLayer_btn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // layersList
            // 
            this.layersList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.layersList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layersList.FormattingEnabled = true;
            this.layersList.ItemHeight = 20;
            this.layersList.Location = new System.Drawing.Point(13, 13);
            this.layersList.Name = "layersList";
            this.layersList.Size = new System.Drawing.Size(294, 404);
            this.layersList.TabIndex = 0;
            this.layersList.SelectedIndexChanged += new System.EventHandler(this.layersList_SelectedIndexChanged);
            // 
            // layerUp_btn
            // 
            this.layerUp_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.layerUp_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.layerUp_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layerUp_btn.Location = new System.Drawing.Point(324, 13);
            this.layerUp_btn.Name = "layerUp_btn";
            this.layerUp_btn.Size = new System.Drawing.Size(113, 40);
            this.layerUp_btn.TabIndex = 1;
            this.layerUp_btn.Text = "Move Up";
            this.layerUp_btn.UseVisualStyleBackColor = false;
            this.layerUp_btn.Click += new System.EventHandler(this.layerUp_btn_Click);
            // 
            // layerDown_btn
            // 
            this.layerDown_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.layerDown_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.layerDown_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layerDown_btn.Location = new System.Drawing.Point(324, 59);
            this.layerDown_btn.Name = "layerDown_btn";
            this.layerDown_btn.Size = new System.Drawing.Size(113, 40);
            this.layerDown_btn.TabIndex = 2;
            this.layerDown_btn.Text = "Move Down";
            this.layerDown_btn.UseVisualStyleBackColor = false;
            this.layerDown_btn.Click += new System.EventHandler(this.layerDown_btn_Click);
            // 
            // deleteLayer_btn
            // 
            this.deleteLayer_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.deleteLayer_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteLayer_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteLayer_btn.Location = new System.Drawing.Point(324, 377);
            this.deleteLayer_btn.Name = "deleteLayer_btn";
            this.deleteLayer_btn.Size = new System.Drawing.Size(113, 40);
            this.deleteLayer_btn.TabIndex = 3;
            this.deleteLayer_btn.Text = "Delete Layer";
            this.deleteLayer_btn.UseVisualStyleBackColor = false;
            this.deleteLayer_btn.Click += new System.EventHandler(this.deleteLayer_btn_Click);
            // 
            // newLayer_btn
            // 
            this.newLayer_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.newLayer_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.newLayer_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newLayer_btn.Location = new System.Drawing.Point(324, 239);
            this.newLayer_btn.Name = "newLayer_btn";
            this.newLayer_btn.Size = new System.Drawing.Size(113, 40);
            this.newLayer_btn.TabIndex = 4;
            this.newLayer_btn.Text = "Add Layer";
            this.newLayer_btn.UseVisualStyleBackColor = false;
            this.newLayer_btn.Click += new System.EventHandler(this.newLayer_btn_Click);
            // 
            // currentlyDrawingTo_lbl
            // 
            this.currentlyDrawingTo_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentlyDrawingTo_lbl.Location = new System.Drawing.Point(324, 116);
            this.currentlyDrawingTo_lbl.Name = "currentlyDrawingTo_lbl";
            this.currentlyDrawingTo_lbl.Size = new System.Drawing.Size(113, 53);
            this.currentlyDrawingTo_lbl.TabIndex = 5;
            this.currentlyDrawingTo_lbl.Text = "Drawing To";
            // 
            // renameLayer_btn
            // 
            this.renameLayer_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.renameLayer_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.renameLayer_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.renameLayer_btn.Location = new System.Drawing.Point(324, 285);
            this.renameLayer_btn.Name = "renameLayer_btn";
            this.renameLayer_btn.Size = new System.Drawing.Size(113, 40);
            this.renameLayer_btn.TabIndex = 6;
            this.renameLayer_btn.Text = "Rename";
            this.renameLayer_btn.UseVisualStyleBackColor = false;
            this.renameLayer_btn.Click += new System.EventHandler(this.renameLayer_btn_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(324, 331);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 40);
            this.button1.TabIndex = 7;
            this.button1.Text = "Select Layer";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.selectLayer_Click);
            // 
            // LayerControlWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(458, 433);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.renameLayer_btn);
            this.Controls.Add(this.currentlyDrawingTo_lbl);
            this.Controls.Add(this.newLayer_btn);
            this.Controls.Add(this.deleteLayer_btn);
            this.Controls.Add(this.layerDown_btn);
            this.Controls.Add(this.layerUp_btn);
            this.Controls.Add(this.layersList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LayerControlWindow";
            this.Text = "LayerControl";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox layersList;
        private System.Windows.Forms.Button layerUp_btn;
        private System.Windows.Forms.Button layerDown_btn;
        private System.Windows.Forms.Button deleteLayer_btn;
        private System.Windows.Forms.Button newLayer_btn;
        private System.Windows.Forms.Label currentlyDrawingTo_lbl;
        private System.Windows.Forms.Button renameLayer_btn;
        private System.Windows.Forms.Button button1;
    }
}