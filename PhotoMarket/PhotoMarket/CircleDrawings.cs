using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PhotoMarket {
    class CircleDrawings : DeepCopy {
        PointF startRatio;
        PointF endRatio;

        Form1 parent;

        RectangleF toDraw;

        Pen pen;

        bool temp = true;

        //constructors
        public CircleDrawings(PointF _startCoord, Pen _pen, Form1 _parent) {
            parent = _parent;
            startRatio = new PointF(parent.Width / _startCoord.X, parent.Height / _startCoord.Y);
            pen = _pen;
            deepCopy(_pen);
        }
        public CircleDrawings(Form1 _parent) {
            parent = _parent;
        }

        //gets the end point for the rectangle
        public void setEndPoint(PointF _endPoint, bool shiftDown, bool finalPoint) {

            //gets the final position of the mouse
            if (shiftDown == false)
                endRatio = new PointF(parent.Width / _endPoint.X, parent.Height / _endPoint.Y);
            else {

                //if shift was pressed, then the end point distance from the start is equal in x and y
                endRatio.X = parent.Width / _endPoint.X;
                endRatio.Y = parent.Height / (startRatio.Y + (endRatio.X - startRatio.X));
            }

            if (finalPoint == true)
                temp = false;
            //lets the program know that the final point has been placed
        }

        //creates the rectangle used to draw the circle
        public void createRectangle() {

            //creates a rectangle to be used to draw the circle out
            toDraw = RectangleF.FromLTRB(parent.Width / startRatio.X, parent.Height / startRatio.Y, parent.Width / endRatio.X, parent.Height / endRatio.Y);
        }

        //draws out the circle using the rectangle made in the set end point
        public void drawCircle(PaintEventArgs g) {

            //sets up the rectangle each time, incase there was a change in window size
            createRectangle();

            if (temp == true)
                g.Graphics.DrawEllipse(tempPen, toDraw);
            else
                g.Graphics.DrawEllipse(pen, toDraw);
        }

        //draws out the circle using the rectangle made in the set end point to the bitmap
        public void exportCircle(Graphics g) {

            //sets up the rectangle each time, incase there was a change in window size
            createRectangle();

            if (temp == true)
                g.DrawEllipse(tempPen, toDraw);
            else
                g.DrawEllipse(pen, toDraw);
        }

        //saves the data abou this object
        public void saveData(StreamWriter sw) {

            //saves the rectangle used to draw the circle
            sw.WriteLine(startRatio.X);
            sw.WriteLine(startRatio.Y);
            sw.WriteLine(endRatio.X);
            sw.WriteLine(endRatio.Y);

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

            startRatio.X = Convert.ToSingle(sr.ReadLine());
            startRatio.Y = Convert.ToSingle(sr.ReadLine());
            endRatio.X = Convert.ToSingle(sr.ReadLine());
            endRatio.Y = Convert.ToSingle(sr.ReadLine());

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
