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

        MainWindow parent;

        public Warning(MainWindow _parent) {
            InitializeComponent();

            parent = _parent;
        }

        //closes the warning window without doing anything
        private void Cancel_btn_Click(object sender, EventArgs e) {
            Close();
        }

        //clears the drawings, then closes the warning window
        private void Clear_btn_Click(object sender, EventArgs e) {

            parent.ClearDrawings();
            Close();
        }
    }
}
