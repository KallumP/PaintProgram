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
    public partial class Warning : Form {

        Form1 parent;

        public Warning(Form1 _parent) {
            InitializeComponent();

            parent = _parent;
        }

        //closes the warning window without doing anything
        private void cancel_btn_Click(object sender, EventArgs e) {
            Close();
        }

        //clears the drawings, then closes the warning window
        private void clear_btn_Click(object sender, EventArgs e) {

            parent.clearDrawings();
            Close();
        }
    }
}
