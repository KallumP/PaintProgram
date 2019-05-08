using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PhotoMarket.DrawingClasses {
    class SquareDrawings : DeepCopier {
        PointF startRatio;
        PointF endRatio;

        Form1 parent;

        Pen pen;

        bool temp = true;

        //constructors
        public SquareDrawings(PointF _startCoord, Pen _pen, Form1 _parent) {
            parent = _parent;
            startRatio = new PointF(parent.Width / _startCoord.X, parent.Height / _startCoord.Y);
            pen = _pen;
            DeepCopy(_pen);
        }
        public SquareDrawings(Form1 _parent) {
            parent = _parent;
        }

        //gets the end point for the rectangle
        public void SetEndPoint(PointF _endPoint, bool shiftDown, bool lastPoint) {

            //gets the final position of the mouse
            if (shiftDown == false)
                endRatio = new PointF(parent.Width / _endPoint.X, parent.Height / _endPoint.Y);
            else {

                //if shift was pressed, then the end point distance from the start is equal in x and y
                endRatio.X = parent.Width / _endPoint.X;
                endRatio.Y = parent.Height / (startRatio.Y + (endRatio.X - startRatio.X));
            }

            //lets the program know that the final point has been placed
            if (lastPoint == true)
                temp = false;
        }

        //draws out the rectangle using lines
        public void Draw(PaintEventArgs g) {
            if (startRatio.X != 0 && startRatio.Y != 0 && endRatio.X != 0 && endRatio.Y != 0) {
                if (temp == true) {
                    g.Graphics.DrawLine(tempPen, parent.Width / startRatio.X, parent.Height / startRatio.Y, parent.Width / startRatio.X, parent.Height / endRatio.Y);
                    g.Graphics.DrawLine(tempPen, parent.Width / startRatio.X, parent.Height / startRatio.Y, parent.Width / endRatio.X, parent.Height / startRatio.Y);
                    g.Graphics.DrawLine(tempPen, parent.Width / startRatio.X, parent.Height / endRatio.Y, parent.Width / endRatio.X, parent.Height / endRatio.Y);
                    g.Graphics.DrawLine(tempPen, parent.Width / endRatio.X, parent.Height / startRatio.Y, parent.Width / endRatio.X, parent.Height / endRatio.Y);
                } else {
                    g.Graphics.DrawLine(pen, parent.Width / startRatio.X, parent.Height / startRatio.Y, parent.Width / startRatio.X, parent.Height / endRatio.Y);
                    g.Graphics.DrawLine(pen, parent.Width / startRatio.X, parent.Height / startRatio.Y, parent.Width / endRatio.X, parent.Height / startRatio.Y);
                    g.Graphics.DrawLine(pen, parent.Width / startRatio.X, parent.Height / endRatio.Y, parent.Width / endRatio.X, parent.Height / endRatio.Y);
                    g.Graphics.DrawLine(pen, parent.Width / endRatio.X, parent.Height / startRatio.Y, parent.Width / endRatio.X, parent.Height / endRatio.Y);
                }
            }
        }

        //draws out the rectangle using lines
        public void Export(Graphics g) {
            if (startRatio.X != 0 && startRatio.Y != 0 && endRatio.X != 0 && endRatio.Y != 0) {
                if (temp == true) {
                    g.DrawLine(tempPen, parent.Width / startRatio.X, parent.Height / startRatio.Y, parent.Width / startRatio.X, parent.Height / endRatio.Y);
                    g.DrawLine(tempPen, parent.Width / startRatio.X, parent.Height / startRatio.Y, parent.Width / endRatio.X, parent.Height / startRatio.Y);
                    g.DrawLine(tempPen, parent.Width / startRatio.X, parent.Height / endRatio.Y, parent.Width / endRatio.X, parent.Height / endRatio.Y);
                    g.DrawLine(tempPen, parent.Width / endRatio.X, parent.Height / startRatio.Y, parent.Width / endRatio.X, parent.Height / endRatio.Y);
                } else
                    g.DrawLine(pen, parent.Width / startRatio.X, parent.Height / startRatio.Y, parent.Width / startRatio.X, parent.Height / endRatio.Y);
                g.DrawLine(pen, parent.Width / startRatio.X, parent.Height / startRatio.Y, parent.Width / endRatio.X, parent.Height / startRatio.Y);
                g.DrawLine(pen, parent.Width / startRatio.X, parent.Height / endRatio.Y, parent.Width / endRatio.X, parent.Height / endRatio.Y);
                g.DrawLine(pen, parent.Width / endRatio.X, parent.Height / startRatio.Y, parent.Width / endRatio.X, parent.Height / endRatio.Y);
            }
        }

        //saves the data about this object
        public void SaveData(StreamWriter sw) {

            //saves the start and end points (x then y)
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
        public void LoadData(StreamReader sr) {

            //sets the start and end points
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
