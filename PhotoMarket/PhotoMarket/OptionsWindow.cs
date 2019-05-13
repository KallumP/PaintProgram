using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PhotoMarket.DrawingClasses;

namespace PhotoMarket {
    public partial class OptionsWindow : Form {

        Form1 parent;

        public OptionsWindow(Form1 _parent) {
            InitializeComponent();

            parent = _parent;
        }

        private void Cancel_btn_Click(object sender, EventArgs e) {
            Close();
        }

        private void Export_btn_Click(object sender, EventArgs e) {
            parent.ExportImage();
        }

        private void Save_btn_Click(object sender, EventArgs e) {
            parent.SaveProject();
        }

        private void Load_btn_Click(object sender, EventArgs e) {
            parent.LoadProject();
        }

        private void ChangeBackImg_btn_Click(object sender, EventArgs e) {
            parent.ChangeBackground();
        }

        private void RemoveBackground_btn_Click(object sender, EventArgs e) {
            parent.RemoveBackground();
        }

        private void button1_Click(object sender, EventArgs e) {
            if (Convert.ToInt16(newCompression_txt.Text) >= 0)
                PenDrawing.compressionDistance = Convert.ToInt16(newCompression_txt.Text);
            else
                MessageBox.Show("Please enter a value greater than or equal to 0");
        }
    }
}
