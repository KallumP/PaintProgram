using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PhotoMarket {
    class PenDrawing {
        List<PointF> coords = new List<PointF>();
        Pen pen;

        Form1 parent;

        string finishedIndicator = "END";

        //constructors
        public PenDrawing(Pen color, Form1 _parent) {
            pen = color;
            parent = _parent;
        }
        public PenDrawing(Form1 _parent) {
            parent = _parent;
        }

        //adds a new item to the list of coordinates
        public void addNewCoordinate(PointF newCoords) {
            coords.Add(new PointF(parent.Width/newCoords.X, parent.Height/newCoords.Y));
        }

        //shows the drawing
        public void showDrawings(PaintEventArgs g) {

            //loops through all of the points
            for (int i = 0; i < coords.Count() - 1; i++) {

                //draws out a line between each of the coordinates in the list
                g.Graphics.DrawLine(
                    pen,
                    parent.Width/coords[i].X,
                    parent.Height/coords[i].Y,
                    parent.Width/coords[i + 1].X,
                    parent.Height/coords[i + 1].Y);
            }
        }

        //draws out the drawing to the bitmap
        public void exportDrawings(Graphics g) {

            //loops through all of the points
            for (int i = 0; i < coords.Count() - 1; i++) {

                //draws out a line between each of the coordinates in the list
                g.DrawLine(
                    pen,
                    parent.Width / coords[i].X,
                    parent.Height / coords[i].Y,
                    parent.Width / coords[i + 1].X,
                    parent.Height / coords[i + 1].Y);
            }
        }

        //saves the data about this object
        public void saveData(StreamWriter sw) {

            //saves the all of the drawing points
            foreach (PointF p in coords) {
                sw.WriteLine(p.X);
                sw.WriteLine(p.Y);
            }

            //lets the program know that the end of the points has been reached
            sw.WriteLine(finishedIndicator);

            //saves the different argb values of the pen
            sw.WriteLine(pen.Color.A);
            sw.WriteLine(pen.Color.R);
            sw.WriteLine(pen.Color.G);
            sw.WriteLine(pen.Color.B);

            //saves the width of the pen
            sw.WriteLine(pen.Width);
        }

        //loads in each value for the object from a file
        public void loadData(StreamReader sr) {

            string checkForEnd;

            bool finished = false;

            //keeps looping until the end of the points has been found
            while (!finished) {
                
                //saves the next line to be check and used
                checkForEnd = sr.ReadLine();

                //checks to see if the next line was the end, or just another point
                if (checkForEnd != finishedIndicator)
                    coords.Add(new PointF(Convert.ToSingle(checkForEnd), Convert.ToSingle(sr.ReadLine())));
                else
                    finished = true;
            }

            //sets the pen's color
            pen = new Pen(
                Color.FromArgb(
                    Convert.ToInt16(sr.ReadLine()),
                    Convert.ToInt16(sr.ReadLine()),
                    Convert.ToInt16(sr.ReadLine()),
                    Convert.ToInt16(sr.ReadLine())));

            //sets the pen's width
            pen.Width = Convert.ToInt32(sr.ReadLine());

            //sets up the pen
            pen.SetLineCap(
                System.Drawing.Drawing2D.LineCap.Round,
                System.Drawing.Drawing2D.LineCap.Round,
                System.Drawing.Drawing2D.DashCap.Round);
        }

    }
}
