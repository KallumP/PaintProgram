using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;

namespace PhotoMarket {
    class CircleDrawings : DeepCopy {
        Point startPoint;
        Point endPoint;

        RectangleF toDraw;

        Pen pen;

        bool temp = true;

        //constructors
        public CircleDrawings(Point _startCoord, Pen _pen) {
            startPoint = _startCoord;
            pen = _pen;
            deepCopy(_pen);
        }
        public CircleDrawings() {

        }

        //gets the end point for the rectangle
        public void setEndPoint(Point _endPoint, bool shiftDown, bool finalPoint) {

            //gets the final position of the mouse
            if (shiftDown == false)
                endPoint = _endPoint;
            else {

                //if shift was pressed, then the end point distance from the start is equal in x and y
                endPoint.X = _endPoint.X;
                endPoint.Y = startPoint.Y + (endPoint.X - startPoint.X);

            }

            //creates the rectangle to draw
            createRectangle();

            if (finalPoint == true)
                temp = false;
            //lets the program know that the final point has been placed
        }

        //creates the rectangle used to draw the circle
        public void createRectangle() {

            //creates a rectangle to be used to draw the circle out
            toDraw = RectangleF.FromLTRB(startPoint.X, startPoint.Y, endPoint.X, endPoint.Y);
        }

        //draws out the circle using the rectangle made in the set end point
        public void drawCircle(PaintEventArgs g) {
            if (temp == true)
                g.Graphics.DrawEllipse(tempPen, toDraw);
            else
                g.Graphics.DrawEllipse(pen, toDraw);
        }

        //draws out the circle using the rectangle made in the set end point to the bitmap
        public void exportCircle(Graphics g) {
            if (temp == true)
                g.DrawEllipse(tempPen, toDraw);
            else
                g.DrawEllipse(pen, toDraw);
        }

        //saves the data abou this object
        public void saveData(StreamWriter sw) {

            //saves the rectangle used to draw the circle
            sw.WriteLine(startPoint.X);
            sw.WriteLine(startPoint.Y);
            sw.WriteLine(endPoint.X);
            sw.WriteLine(endPoint.Y);

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

            //sets the rectangle used to draw the circle

            startPoint.X = Convert.ToInt16(sr.ReadLine());
            startPoint.Y = Convert.ToInt16(sr.ReadLine());
            endPoint.X = Convert.ToInt16(sr.ReadLine());
            endPoint.Y = Convert.ToInt16(sr.ReadLine());

            createRectangle();

            //sets the pen's color
            pen = new Pen(
                Color.FromArgb(
                    Convert.ToInt16(sr.ReadLine()),
                    Convert.ToInt16(sr.ReadLine()),
                    Convert.ToInt16(sr.ReadLine()),
                    Convert.ToInt16(sr.ReadLine())));

            //sets the pen's width
            pen.Width = Convert.ToInt16(sr.ReadLine());

            //sets up the pen
            pen.SetLineCap(
                System.Drawing.Drawing2D.LineCap.Round,
                System.Drawing.Drawing2D.LineCap.Round,
                System.Drawing.Drawing2D.DashCap.Round);

            //lets the program know not to draw the dashed lines
            temp = false;
        }
    }
}
