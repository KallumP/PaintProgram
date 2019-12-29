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
    public partial class LayerRename : Form {

        MainWindow main;
        LayerControlWindow parent;
        int indexToChange;

        public LayerRename(MainWindow _main, LayerControlWindow _parent, int _index) {
            InitializeComponent();
            main = _main;
            parent = _parent;
            indexToChange = _index;
        }

        private void cancel_btn_Click(object sender, EventArgs e) {
            Close();
        }

        private void confirm_btn_Click(object sender, EventArgs e) {
            if (newName_txt.Text != "") {
                main.layers[indexToChange].name = newName_txt.Text;
                parent.UpdateListBox();
                Close();
            } else
                MessageBox.Show("Error, please enter a name");

        }
    }
}
