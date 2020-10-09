using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PhotoMarket.DrawingClasses {
    public class SquareDrawing : DeepCopier {
        PointF startRatio;
        PointF endRatio;

        PointF startPoint;

        MainWindow parent;

        Pen pen;

        bool temp = true;

        //constructors
        public SquareDrawing(PointF _startCoord, Pen _pen, MainWindow _parent) {
            parent = _parent;
            startRatio = new PointF(parent.canvasSizeX / _startCoord.X, parent.canvasSizeY / _startCoord.Y);
            startPoint = _startCoord;
            pen = _pen;
            DeepCopy(_pen);
        }
        public SquareDrawing(MainWindow _parent) {
            parent = _parent;
        }

        //gets the end point for the rectangle
        public void SetEndPoint(PointF _endPoint, bool shiftDown, bool lastPoint) {

            //sets the new point with no formatting
            if (shiftDown == false)
                endRatio = new PointF(parent.canvasSizeX / _endPoint.X, parent.canvasSizeY / _endPoint.Y);
            else {

                //sets the new point trying to make the square with equal sides


                bool xBigger = false;

                //finds out which coord of the mouse was furthest from the original starting point
                if (Math.Pow(startPoint.X - _endPoint.X, 2) > Math.Pow(startPoint.Y - _endPoint.Y, 2))
                    xBigger = true;


                if (xBigger) {

                    //if x was bigger then y is set to same distance from the xstart as y is from the ystart
                    endRatio.X = parent.canvasSizeX / _endPoint.X;
                    endRatio.Y = parent.canvasSizeY / (startPoint.Y + (_endPoint.X - startPoint.X));

                } else {

                    //if y was bigger then x is set to same distance from the xstart as y is from the ystart
                    endRatio.Y = parent.canvasSizeY / _endPoint.Y;
                    endRatio.X = parent.canvasSizeX / (startPoint.X + (_endPoint.Y - startPoint.Y));
                }
            }

            //lets the program know that the final point has been placed
            if (lastPoint == true)
                temp = false;
        }

        //draws out the rectangle using lines
        public void Draw(Graphics g) {

            //makes sure that divides by zero doesnt happen
            if (startRatio.X != 0 && startRatio.Y != 0 && endRatio.X != 0 && endRatio.Y != 0)
                if (temp == true) {
                    g.DrawLine(tempPen, parent.canvasSizeX / startRatio.X, parent.canvasSizeY / startRatio.Y, parent.canvasSizeX / startRatio.X, parent.canvasSizeY / endRatio.Y);
                    g.DrawLine(tempPen, parent.canvasSizeX / startRatio.X, parent.canvasSizeY / startRatio.Y, parent.canvasSizeX / endRatio.X, parent.canvasSizeY / startRatio.Y);
                    g.DrawLine(tempPen, parent.canvasSizeX / startRatio.X, parent.canvasSizeY / endRatio.Y, parent.canvasSizeX / endRatio.X, parent.canvasSizeY / endRatio.Y);
                    g.DrawLine(tempPen, parent.canvasSizeX / endRatio.X, parent.canvasSizeY / startRatio.Y, parent.canvasSizeX / endRatio.X, parent.canvasSizeY / endRatio.Y);
                } else {
                    g.DrawLine(pen, parent.canvasSizeX / startRatio.X, parent.canvasSizeY / startRatio.Y, parent.canvasSizeX / startRatio.X, parent.canvasSizeY / endRatio.Y);
                    g.DrawLine(pen, parent.canvasSizeX / startRatio.X, parent.canvasSizeY / startRatio.Y, parent.canvasSizeX / endRatio.X, parent.canvasSizeY / startRatio.Y);
                    g.DrawLine(pen, parent.canvasSizeX / startRatio.X, parent.canvasSizeY / endRatio.Y, parent.canvasSizeX / endRatio.X, parent.canvasSizeY / endRatio.Y);
                    g.DrawLine(pen, parent.canvasSizeX / endRatio.X, parent.canvasSizeY / startRatio.Y, parent.canvasSizeX / endRatio.X, parent.canvasSizeY / endRatio.Y);
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
