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
    public partial class ColorPicker : Form {
        Color chosenColor;
        bool clicked = false;
        Point mouseCoord;
        Bitmap colorPickerBitmap;
        string inputHexValue;

        MainWindow mainForm;

        //constructors
        public ColorPicker() {
            InitializeComponent();
        }
        public ColorPicker(MainWindow f) {
            InitializeComponent();
            mainForm = f;
        }

        //loads up the form
        private void ColorPicker_Load(object sender, EventArgs e) {

            //sets the image of the picturebox
            colorPicker_pic.Image = Properties.Resources._ColorPicker;

            //redraws the pictureboxes
            colorPicker_pic.Invalidate();
            showColor_pic.Invalidate();

            //creates a bitmap of the image in the picturebox
            colorPickerBitmap = new Bitmap(colorPicker_pic.Image);
        }



        //color picker input ----------------------------------------------------------------------------------

        //deals with mouse movement in the over the color picker picture box
        private void ColorPicker_pic_MouseDown(object sender, MouseEventArgs e) {

            //lets the form know that mouse is held down
            clicked = true;

            //gets the mouse coordinates of the click
            SetMouseCoord(e.X, e.Y);

            //updates the "chosenColor"
            UpdateColor(true);
        }
        private void ColorPicker_pic_MouseMove(object sender, MouseEventArgs e) {

            //only gets the color if mouse was held down
            if (clicked == true) {

                //gets the mouse location of the mouse
                SetMouseCoord(e.X, e.Y);

                //updates the "chosenColor"
                UpdateColor(true);
            }
        }
        private void ColorPicker_pic_MouseUp(object sender, MouseEventArgs e) {

            //gets the mouse coordinates of the click
            SetMouseCoord(e.X, e.Y);

            //updates the "chosenColor"
            UpdateColor(true);

            //lets the form know that mouse is not being held down anymore
            clicked = false;
        }

        //gets the mouse coordinates
        void SetMouseCoord(int X, int Y) {

            //sets the mouse coordinates
            mouseCoord.X = X;
            mouseCoord.Y = Y;

            //constrains the mouse to the picture box dimensions
            if (mouseCoord.X >= colorPicker_pic.Width)
                mouseCoord.X = colorPicker_pic.Width - 1;
            if (mouseCoord.Y >= colorPicker_pic.Height)
                mouseCoord.Y = colorPicker_pic.Height - 1;
            if (mouseCoord.X <= 0)
                mouseCoord.X = 1;
            if (mouseCoord.Y <= 0)
                mouseCoord.Y = 1;
        }



        //text box input ----------------------------------------------------------------------------------

        //lets the user enter a hex value for their chosen color
        private void CheckHex_btn_Click(object sender, EventArgs e) {

            //gets the input hex value as long as there was an input to check
            if (hexValue_txt.Text != "")
                inputHexValue = "#" + hexValue_txt.Text;

            //updates the chosenColor
            UpdateColor(false);
        }



        //slider input ----------------------------------------------------------------------------------

        //allows the user to use the sliders to choose a color
        private void Alpha_bar_Scroll(object sender, EventArgs e) {
            TakeScrollInputs();
        }
        private void Red_bar_Scroll(object sender, EventArgs e) {
            TakeScrollInputs();
        }
        private void Green_bar_Scroll(object sender, EventArgs e) {
            TakeScrollInputs();
        }
        private void Blue_bar_Scroll(object sender, EventArgs e) {
            TakeScrollInputs();
        }
        
        //takes in the values from the sliders
        void TakeScrollInputs() {

            string alpha, red, green, blue;

            //forces the hex value to be two digits
            if (Alpha_bar.Value < 16)
                alpha = "0" + Alpha_bar.Value.ToString("X");
            else
                alpha = Alpha_bar.Value.ToString("X");

            if (Red_bar.Value < 16)
                red = "0" + Red_bar.Value.ToString("X");
            else
                red = Red_bar.Value.ToString("X");

            if (Green_bar.Value < 16)
                green = "0" + Green_bar.Value.ToString("X");
            else
                green = Green_bar.Value.ToString("X");

            if (Blue_bar.Value < 16)
                blue = "0" + Blue_bar.Value.ToString("X");
            else
                blue = Blue_bar.Value.ToString("X");

            //sets up the input hexvalue string
            inputHexValue = "#" + alpha + red + green + blue;

            UpdateColor(false);
        }


        //sets the chosen color and shows the user what color was chosen
        void UpdateColor(bool imageChoice) {

            //checks to see what type of input there was
            if (imageChoice == true) 

                //gets the color of the pixel of the mouse location
                chosenColor = colorPickerBitmap.GetPixel(mouseCoord.X, mouseCoord.Y);

             else 

                //sets the chosen color from what the input hex value was
                chosenColor = ColorTranslator.FromHtml(inputHexValue);
            
            //shows the use what color has been chosen by displaying the "show" picture box as a solid chosen color
            showColor_pic.BackColor = chosenColor;

            //lets the use know what the hex value of the chosen color is
            chosenColor_lbl.Text =
                chosenColor.A.ToString("X") + " - " +
                chosenColor.R.ToString("X") + " - " +
                chosenColor.G.ToString("X") + " - " +
                chosenColor.B.ToString("X");

            Alpha_bar.Value = chosenColor.A;
            Red_bar.Value = chosenColor.R;
            Green_bar.Value = chosenColor.G;
            Blue_bar.Value = chosenColor.B;

        }

        //lets the user choose the color that they chose
        private void ChooseColor_btn_Click(object sender, EventArgs e) {
            mainForm.penColor = chosenColor;
            mainForm.UpdateGlobalPen(chosenColor, mainForm.penWidth);
            mainForm.InvalidateAll();
            Close();
        }
    }
}
