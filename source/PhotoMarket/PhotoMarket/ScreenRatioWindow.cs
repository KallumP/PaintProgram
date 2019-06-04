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
    public partial class ScreenRatioWindow : Form {

        Form1 parent;


        public ScreenRatioWindow(Form1 _parent) {
            parent = _parent;
            InitializeComponent();
        }


        private void Confirm_btn_Click(object sender, EventArgs e) {

            int xValue, yValue;

            if (xRatio_txt.ToString() != "" && yRatio_txt.ToString() != "") {

                //checks to see if the values entered were numbers
                if (Int32.TryParse(xRatio_txt.Text.ToString(), out xValue) && Int32.TryParse(yRatio_txt.Text.ToString(), out yValue)) {

                    //checks to see if the entered values are not negative
                    if (xValue < 0 || yValue < 0) {
                        MessageBox.Show("Please enter values greater then 0");


                        //checks to see if the numbers entered were not 0
                    } else if (xValue != 0 && yValue != 0) {

                        parent.ratioBind = true;
                        parent.ratio = (float)xValue / yValue;

                        parent.ResizeHandler();
                        Close();


                        //if the entered values were 0
                    } else {

                        //sets the binds to nothing
                        parent.ratioBind = false;
                        parent.ResizeHandler();
                        Close();

                    }

                } else {
                    MessageBox.Show("Please enter number values");

                }
            } else {
                MessageBox.Show("Please enter a value into both boxes");
            }


        }

        private void Cancel_btn_Click(object sender, EventArgs e) {
            Close();
        }
    }
}
