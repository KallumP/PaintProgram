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
    public partial class SaveChecker : Form {

        Form1 parent;

        public SaveChecker(Form1 _parent) {
            InitializeComponent();

            parent = _parent;
        }

        private void cancel_btn_Click(object sender, EventArgs e) {
            Close();
        }

        private void Export_btn_Click(object sender, EventArgs e) {
            parent.exportImage();
            Close();
        }

        private void save_btn_Click(object sender, EventArgs e) {
            parent.saveProject();
            Close();
        }
    }
}
