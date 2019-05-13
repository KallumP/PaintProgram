using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace PhotoMarket.DrawingClasses {
    class ImageDrawing {

        Form1 parent;

        string imagePath;
        PointF startRatio;

        //Constructors
        //used for setting up a background image
        public ImageDrawing(PointF _startPoint, string _path, Form1 _parent) {
            parent = _parent;
            startRatio = new PointF(parent.Width / _startPoint.X, parent.Height / _startPoint.Y);
            imagePath = _path;

        }
        //used for creating an image (before the location is made)
        public ImageDrawing(string _path, Form1 _parent) {
            parent = _parent;
            startRatio = new PointF(0f, 0f);
            imagePath = _path;

        }
        //used for loading up an image from a project file
        public ImageDrawing(Form1 _parent) {
            parent = _parent;
        }

        //used to set up where to draw the image
        public void SetStartPoint(PointF newStart) {
            startRatio = new PointF(parent.Width / newStart.X, parent.Height / newStart.Y);

        }

        //Draws out the image
        public void Draw(PaintEventArgs g) {
            if (startRatio.X != 0 && startRatio.Y != 0) {
                Image todraw = Image.FromFile(imagePath);

                g.Graphics.DrawImage(todraw, new PointF(parent.Width / startRatio.X, parent.Height / startRatio.Y));
            }
        }

        //exports the image to the final image file
        public void Export(Graphics g) {

            Image todraw = Image.FromFile(imagePath);

            g.DrawImage(todraw, new PointF(parent.Width / startRatio.X, parent.Height / startRatio.Y));
        }

        //writes out the data to a text file
        public void SaveData(StreamWriter sw) {
            sw.WriteLine(imagePath);
            sw.WriteLine(startRatio.X);
            sw.WriteLine(startRatio.Y);
        }

        //loads up data from a text file
        public void LoadData(StreamReader sr) {

            imagePath = sr.ReadLine();
            startRatio = new PointF(Convert.ToSingle(sr.ReadLine()), Convert.ToSingle(sr.ReadLine()));

        }

        //public static Image resizeImage(Image imgToResize, Size size) {
        //    return (Image)(new Bitmap(imgToResize, size));
        //}

        //yourImage = resizeImage(yourImage, new Size(50,50));
    }
}
