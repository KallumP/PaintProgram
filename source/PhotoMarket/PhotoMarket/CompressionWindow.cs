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
    public partial class CompressionWindow : Form {

        MainWindow parent;

        public CompressionWindow(MainWindow _parent) {
            InitializeComponent();

            parent = _parent;
        }

        private void Cancel_btn_Click(object sender, EventArgs e) {
            Close();
        }

        private void button1_Click(object sender, EventArgs e) {

            int enteredValue;

            //Makes sure that a value was entered
            if (newCompression_txt.Text != "")

                //makes sure that the entered value was a number
                if (Int32.TryParse(newCompression_txt.Text, out enteredValue))

                    //makes sure that the valid number was bigger than or equal to 0
                    if (enteredValue >= 0)
                        PenDrawing.compressionDistance = enteredValue;

                    else
                        MessageBox.Show("Please enter a number greater than or equal to 0");

                else
                    MessageBox.Show("Please enter a number");

            else
                MessageBox.Show("Please enter a value");

        }
    }
}
