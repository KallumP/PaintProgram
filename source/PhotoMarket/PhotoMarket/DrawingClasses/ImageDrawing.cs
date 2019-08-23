using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace PhotoMarket.DrawingClasses {
    public class ImageDrawing {

        MainWindow parent;

        string imagePath;
        PointF startRatio;
        PointF endRatio;

        //Constructors
        //used for setting up a background image
        public ImageDrawing(PointF _startPoint, PointF _endPoint, string _path, MainWindow _parent) {
            parent = _parent;
            startRatio = new PointF(parent.canvasSizeX / _startPoint.X, parent.canvasSizeY / _startPoint.Y);
            endRatio = new PointF(parent.canvasSizeX / _endPoint.X, parent.canvasSizeY / _endPoint.Y);
            imagePath = _path;

        }
        //used for creating an image (before the location is made)
        public ImageDrawing(string _path, MainWindow _parent) {
            parent = _parent;
            startRatio = new PointF(0f, 0f);
            imagePath = _path;

        }
        //used for loading up an image from a project file
        public ImageDrawing(MainWindow _parent) {
            parent = _parent;
        }

        //used to set up where to draw the image
        public void SetStartPoint(PointF newStart) {

            startRatio = new PointF(parent.canvasSizeX / newStart.X, parent.canvasSizeY / newStart.Y);

        }

        public void SetEndPoint(PointF endPoint) {
            endRatio = new PointF(parent.canvasSizeX / endPoint.X, parent.canvasSizeY / endPoint.Y);
        }

        //Draws out the image drawing
        public void Draw(Graphics g) {

            //makes sure that the ratios arent 0
            if (startRatio.X != 0 && startRatio.Y != 0 && endRatio.X != 0 && endRatio.Y != 0) {
                if (File.Exists(imagePath)) {
                    Image todraw = Image.FromFile(imagePath);

                    g.DrawImage(
                        todraw,
                        parent.canvasSizeX / startRatio.X,
                        parent.canvasSizeY / startRatio.Y,
                        parent.canvasSizeX / endRatio.X - parent.canvasSizeX / startRatio.X,
                        parent.canvasSizeY / endRatio.Y - parent.canvasSizeY / startRatio.Y);

                } else
                    Console.WriteLine("Image not found");
            }
        }

        //writes out the data to a text file
        public void SaveData(StreamWriter sw) {
            sw.WriteLine(imagePath);
            sw.WriteLine(startRatio.X);
            sw.WriteLine(startRatio.Y);
            sw.WriteLine(endRatio.X);
            sw.WriteLine(endRatio.Y);
        }

        //loads up data from a text file
        public void LoadData(StreamReader sr) {

            imagePath = sr.ReadLine();
            startRatio = new PointF(Convert.ToSingle(sr.ReadLine()), Convert.ToSingle(sr.ReadLine()));
            endRatio = new PointF(Convert.ToSingle(sr.ReadLine()), Convert.ToSingle(sr.ReadLine()));
        }
    }
}
