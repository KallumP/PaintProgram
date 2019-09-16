using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotoMarket
{
    public partial class BrushSize : Form
    {
        MainWindow main;
        int newSize;

        //constructor
        public BrushSize(MainWindow m) {

            InitializeComponent();

            //sets an instance of the main window
            main = m;

            //gets what the current brush size is
            newSize = main.penWidth;

            //updates the window to show the current brush size
            brushSize_bar.Value = newSize;
            newSize_txt.Text = newSize.ToString(); ;
        }

        //deals with the scroll bar
        private void BrushSize_bar_Scroll(object sender, EventArgs e) {

            //updates the text box to show what brush size was selected
            newSize_txt.Text = brushSize_bar.Value.ToString();
        }

        //lets the user enter their own values
        private void NewSize_txt_TextChanged(object sender, EventArgs e) {

            int textValue;

            Int32.TryParse(newSize_txt.Text, out textValue);

            //makes sure that a valid number was entered
            if (textValue > 0) {

                newSize = textValue;

                //lets the user enter a value thats larger than what the scroll bar allows
                if (newSize > brushSize_bar.Maximum)
                    brushSize_bar.Value = brushSize_bar.Maximum;
                else
                    brushSize_bar.Value = newSize;

            } else

                //reverts the change if an invalid change was made
                newSize_txt.Text = newSize.ToString();
        }

        //lets the user go back without making changes
        private void Cancel_btn_Click(object sender, EventArgs e) {

            //closes the window without changing the size in the main window
            Close();
        }

        //lets the user select the new size
        private void Select_btn_Click(object sender, EventArgs e) {

            //changes the size in the main window
            main.penWidth = newSize;


            main.UpdateGlobalPen(main.penColor, newSize);

            //closes the window
            Close();
        }
    }
}
