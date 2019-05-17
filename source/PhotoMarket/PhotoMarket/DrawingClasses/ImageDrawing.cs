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
        PointF endRatio;

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

        public void SetEndPoint(PointF endPoint) {
            endRatio = new PointF(parent.Width / endPoint.X, parent.Height / endPoint.Y);
        }

        //Draws out the image
        public void Draw(PaintEventArgs g) {
            if (endRatio.X == 0 && endRatio.Y == 0) {

                Image todraw = Image.FromFile(imagePath);

                //draws out the full sized image, because an endpoint hasnt been determined yet
                g.Graphics.DrawImage(todraw, new PointF(parent.Width / startRatio.X, parent.Height / startRatio.Y));

            } else {

                //makes sure that the ratios arent 0
                if (startRatio.X != 0 && startRatio.Y != 0 && endRatio.X != 0 && endRatio.Y != 0) {
                    if (File.Exists(imagePath)) {
                        Image todraw = Image.FromFile(imagePath);

                        g.Graphics.DrawImage(
                            todraw, 
                            parent.Width / startRatio.X,
                            parent.Height / startRatio.Y, 
                            parent.Width / endRatio.X - parent.Width / startRatio.X, 
                            parent.Height / endRatio.Y - parent.Height / startRatio.Y);

                    } else {
                        Console.WriteLine("Image not found");
                    }
                }
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
    }
}
