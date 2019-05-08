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

        private Form mainForm;

        //constructors
        public ColorPicker() {
            InitializeComponent();
        }
        public ColorPicker(Form f) {
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

        //deals with mouse movement in the over the color picker picture box
        private void colorPicker_pic_MouseDown(object sender, MouseEventArgs e) {

            //lets the form know that mouse is held down
            clicked = true;

            //gets the mouse coordinates of the click
            setMouseCoord(e.X, e.Y);

            //updates the "chosenColor"
            updateColor(true);
        }
        private void colorPicker_pic_MouseMove(object sender, MouseEventArgs e) {

            //only gets the color if mouse was held down
            if (clicked == true) {

                //gets the mouse location of the mouse
                setMouseCoord(e.X, e.Y);

                //updates the "chosenColor"
                updateColor(true);
            }
        }
        private void colorPicker_pic_MouseUp(object sender, MouseEventArgs e) {

            //gets the mouse coordinates of the click
            setMouseCoord(e.X, e.Y);

            //updates the "chosenColor"
            updateColor(true);

            //lets the form know that mouse is not being held down anymore
            clicked = false;
        }

        //lets the user enter a hex value for their chosen color
        private void checkHex_btn_Click(object sender, EventArgs e) {

            //gets the input hex value
            inputHexValue = "#" + hexValue_txt.Text;

            //updates the chosenColor
            updateColor(false);
        }

        //sets the chosen color and shows the user what color was chosen
        void updateColor(bool mouse) {
            if (mouse == true) {

                //gets the color of the pixel of the mouse location
                chosenColor = colorPickerBitmap.GetPixel(mouseCoord.X, mouseCoord.Y);

            } else {

                //sets the chosen color from what the input hex value was
                chosenColor = ColorTranslator.FromHtml(inputHexValue);
            }

            //shows the use what color has been chosen by displaying the "show" picture box as a solid chosen color
            showColor_pic.BackColor = chosenColor;

            //lets the use know what the hex value of the chosen color is
            chosenColor_lbl.Text =
                chosenColor.A.ToString("X") + " - " +
                chosenColor.R.ToString("X") + " - " +
                chosenColor.G.ToString("X") + " - " +
                chosenColor.B.ToString("X");
        }

        //sends the new color back to the old form
        void updateMainFormColor() {
            ((Form1)mainForm).penColor = chosenColor;
            ((Form1)mainForm).UpdateGlobalPen(chosenColor, ((Form1)mainForm).penWidth);
            ((Form1)mainForm).InvalidateAll();
            this.Close();
        }

        //gets the mouse coordinates
        void setMouseCoord(int X, int Y) {

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

        //lets the user set the color that they chose
        private void chooseColor_btn_Click(object sender, EventArgs e) {
            updateMainFormColor();
        }
    }
}
