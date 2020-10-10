using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotoMarket.Forms {
    public partial class ExportOptions : Form {

        Point defaultSize;
        MainWindow parent;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="_parent">A refference to the window opening this</param>
        /// <param name="_defaultSize">The size of the project's canvas</param>
        public ExportOptions(MainWindow _parent, Point _defaultSize) {
            parent = _parent;
            defaultSize = _defaultSize;
            InitializeComponent();
        }

        private void defaultSize_btn_Click(object sender, EventArgs e) {
            height_txt.Text = defaultSize.Y.ToString();
            width_txt.Text = defaultSize.X.ToString();
        }

        private void saveImage_btn_Click(object sender, EventArgs e) {
            Save();
        }

        void Save() {

            //checks if the inputs were empty
            if (width_txt.Text != "" || height_txt.Text != "") {


                int chosenHeight = 0;
                int chosenWidth = 0;

                //checks if both of the inputs were numbers
                if (Int32.TryParse(width_txt.Text, out chosenWidth) && Int32.TryParse(height_txt.Text, out chosenHeight)) {

                    //creates a save file dialog
                    SaveFileDialog saver = new SaveFileDialog();

                    //makes it so that the user can only save as png
                    saver.Filter = "PNG(*.PNG)|*.png|JPG(*.JPG)|*.jpg";

                    //makes the user choose where to save the file
                    if (saver.ShowDialog() == DialogResult.OK) {

                        //creates a bitmap which will be drawn to
                        Bitmap toSave = new Bitmap(chosenWidth, chosenHeight);

                        //uses a graphics library to draw to the file
                        using (Graphics g = Graphics.FromImage(toSave)) {

                            //checks to see if the background should be tranparent
                            if (!parent.transparentBackground)

                                g.FillRectangle(Brushes.White, 0, 0, chosenWidth, chosenHeight);

                            if (parent.background != null)
                                parent.background.Draw(g, chosenWidth, chosenHeight);

                            //goes through and draws the content from each layer
                            foreach (Layer l in parent.layers)
                                l.Export(g, chosenWidth, chosenHeight);
                        }

                        //saves the image
                        toSave.Save(saver.FileName);

                        this.Close();
                    }

                }
            }

        }
    }
}
