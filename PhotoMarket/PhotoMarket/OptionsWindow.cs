using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            Close();
        }

        private void Save_btn_Click(object sender, EventArgs e) {
            parent.SaveProject();
            Close();
        }

        private void Load_btn_Click(object sender, EventArgs e) {
            parent.LoadProject();
            Close();
        }

        private void ChangeBackImg_btn_Click(object sender, EventArgs e) {
            parent.ChangeBackground();
            Close();
        }

        private void RemoveBackground_btn_Click(object sender, EventArgs e) {
            parent.RemoveBackground();
            Close();
        }
    }
}
