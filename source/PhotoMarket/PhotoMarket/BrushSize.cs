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

        int inputTimeout = 1000;
        int inputTime;

        //constructor
        public BrushSize(MainWindow m)
        {

            InitializeComponent();

            //sets an instance of the main window
            main = m;

            //gets what the current brush size is
            newSize = main.penWidth;

            //updates the window to show the current brush size
            newSize_txt.Text = newSize.ToString();

            //makes sure that the curernt size does not go past the maximum value of the scroll bar
            if (newSize > brushSize_bar.Maximum)
                brushSize_bar.Value = brushSize_bar.Maximum;
            else
                brushSize_bar.Value = newSize;
            
        }

        //deals with the scroll bar
        private void BrushSize_bar_Scroll(object sender, EventArgs e)
        {

            //updates the text box to show what brush size was selected
            newSize_txt.Text = brushSize_bar.Value.ToString();

            //sets the new size of the brush
            newSize = brushSize_bar.Value;
        }

        //starts a timer as soon as a key button is let go of
        private void NewSize_txt_KeyUp(object sender, KeyEventArgs e)
        {

            //resets the time since last keypress
            inputTime = 0;

            //starts the timer;
            inputTimer.Start();
        }

        private void InputTimer_Tick(object sender, EventArgs e)
        {

            //keeps track of how much time has passed since the last keypress
            inputTime += inputTimer.Interval;

            //if the user has stopped typing it sets the new size
            if (inputTime >= inputTimeout)
            {
                UpdateTextBrushSize();

                inputTimer.Stop();
            }
        }

        //sets the new size from the text box value
        void UpdateTextBrushSize()
        {

            int textValue;

            //checks to see if the text input was a number
            Int32.TryParse(newSize_txt.Text, out textValue);

            //makes sure that a valid number was entered
            if (textValue > 0)
            {

                newSize = textValue;

                //lets the user enter a value thats larger than what the scroll bar allows
                if (newSize > brushSize_bar.Maximum)
                    brushSize_bar.Value = brushSize_bar.Maximum;
                else
                    brushSize_bar.Value = newSize;

            }
            else
            {

                //reverts the change if an invalid change was made
                newSize_txt.Text = newSize.ToString();
            }
        }

        //lets the user go back without making changes
        private void Cancel_btn_Click(object sender, EventArgs e)
        {

            //closes the window without changing the size in the main window
            Close();
        }

        //lets the user select the new size
        private void Select_btn_Click(object sender, EventArgs e)
        {
            //Lets the user click select before the timer registers that they have stopped typing
            UpdateTextBrushSize();

            //changes the size in the main window
            main.penWidth = newSize;

            //updates the pen in the main window
            main.UpdateGlobalPen(main.penColor, newSize);

            //closes the window
            Close();
        }
    }
}
