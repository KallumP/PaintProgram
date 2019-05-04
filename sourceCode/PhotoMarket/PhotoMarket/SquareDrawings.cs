using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PhotoMarket {
    class SquareDrawings : DeepCopy {
        Point startPoint;
        Point endPoint;

        Pen pen;

        bool temp = true;

        //constructors
        public SquareDrawings(Point _startCoord, Pen _pen) {
            startPoint = _startCoord;
            pen = _pen;
            deepCopy(_pen);
        }
        public SquareDrawings() {

        }

        //gets the end point for the rectangle
        public void setEndPoint(Point _endPoint, bool shiftDown, bool lastPoint) {

            //gets the final position of the mouse
            if (shiftDown == false)
                endPoint = _endPoint;
            else {

                //if shift was pressed, then the end point distance from the start is equal in x and y
                endPoint.X = _endPoint.X;
                endPoint.Y = startPoint.Y + (endPoint.X - startPoint.X);
            }

            //lets the program know that the final point has been placed
            if (lastPoint == true)
                temp = false;
        }

        //draws out the rectangle using lines
        public void drawSquare(PaintEventArgs g) {
            if (temp == true) {
                g.Graphics.DrawLine(tempPen, startPoint.X, startPoint.Y, startPoint.X, endPoint.Y);
                g.Graphics.DrawLine(tempPen, startPoint.X, startPoint.Y, endPoint.X, startPoint.Y);
                g.Graphics.DrawLine(tempPen, startPoint.X, endPoint.Y, endPoint.X, endPoint.Y);
                g.Graphics.DrawLine(tempPen, endPoint.X, startPoint.Y, endPoint.X, endPoint.Y);
            } else {
                g.Graphics.DrawLine(pen, startPoint.X, startPoint.Y, startPoint.X, endPoint.Y);
                g.Graphics.DrawLine(pen, startPoint.X, startPoint.Y, endPoint.X, startPoint.Y);
                g.Graphics.DrawLine(pen, startPoint.X, endPoint.Y, endPoint.X, endPoint.Y);
                g.Graphics.DrawLine(pen, endPoint.X, startPoint.Y, endPoint.X, endPoint.Y);
            }
        }

        //draws out the rectangle using lines
        public void exportSquare(Graphics g) {
            if (temp == true) {
                g.DrawLine(tempPen, startPoint.X, startPoint.Y, startPoint.X, endPoint.Y);
                g.DrawLine(tempPen, startPoint.X, startPoint.Y, endPoint.X, startPoint.Y);
                g.DrawLine(tempPen, startPoint.X, endPoint.Y, endPoint.X, endPoint.Y);
                g.DrawLine(tempPen, endPoint.X, startPoint.Y, endPoint.X, endPoint.Y);
            } else {
                g.DrawLine(pen, startPoint.X, startPoint.Y, startPoint.X, endPoint.Y);
                g.DrawLine(pen, startPoint.X, startPoint.Y, endPoint.X, startPoint.Y);
                g.DrawLine(pen, startPoint.X, endPoint.Y, endPoint.X, endPoint.Y);
                g.DrawLine(pen, endPoint.X, startPoint.Y, endPoint.X, endPoint.Y);
            }
        }

        //saves the data about this object
        public void saveData(StreamWriter sw) {

            //saves the start and end points (x then y)
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

            //sets the start and end points
            startPoint.X = Convert.ToInt16(sr.ReadLine());
            startPoint.Y = Convert.ToInt16(sr.ReadLine());
            endPoint.X = Convert.ToInt16(sr.ReadLine());
            endPoint.Y = Convert.ToInt16(sr.ReadLine());

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

            //lets the program know not to draw the dashed lines
            temp = false;
        }
    }
}
