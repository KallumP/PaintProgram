using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PhotoMarket.DrawingClasses {
    class LineDrawing : DeepCopier {
        PointF startRatio;
        PointF endRatio;
        Pen pen;

        PointF startCoord;
        PointF endCoord;

        Form1 parent;

        bool temp = true;

        bool ctrlDown;
        bool shiftDown;

        //constructors
        public LineDrawing(PointF _start, Pen _pen, Form1 _parent) {
            parent = _parent;
            startRatio = new PointF(parent.Width / _start.X, parent.Height / _start.Y);
            startCoord = _start;
            pen = _pen;
            DeepCopy(_pen);
        }
        public LineDrawing(Form1 _parent) {
            parent = _parent;
        }

        //sets the final position of the mouse
        public void SetEnd(PointF _end, bool _shiftDown, bool _ctrlDown, bool finalPoint) {
            endCoord = _end;
            shiftDown = _shiftDown;
            ctrlDown = _ctrlDown;
            AngleFix();

            if (endCoord.X > 0 && endCoord.Y > 0)
                //sets the ratios after the angle fix
                endRatio = new PointF(parent.Width / endCoord.X, parent.Height / endCoord.Y);

            //lets the program know that the final point has been placed
            if (finalPoint == true)
                temp = false;
        }

        //fixes the end point if shift is held down
        public void AngleFix() {

            //a check to see if shift was pressed down
            if (shiftDown == true) {

                //snaps the line end to 90 degrees
                if (Math.Abs(startCoord.Y - endCoord.Y) > Math.Abs(startCoord.X - endCoord.X))
                    endCoord.X = startCoord.X;
                else
                    endCoord.Y = startCoord.Y;

                //a check to see if control was pressed down
            } else if (ctrlDown == true) {

                //snaps the line end to 45 degrees
                if (startCoord.Y - endCoord.Y > 0 && startCoord.X - endCoord.X > 0)
                    endCoord.X = startCoord.X - (startCoord.Y - endCoord.Y);
                else if ((startCoord.Y - endCoord.Y) < 0 && (startCoord.X - endCoord.X) < 0)
                    endCoord.X = startCoord.X - (startCoord.Y - endCoord.Y);
                else if (startCoord.Y - endCoord.Y > 0 && startCoord.X - endCoord.X < 0)
                    endCoord.X = startCoord.X + startCoord.Y - endCoord.Y;
                else if (startCoord.Y - endCoord.Y < 0 && startCoord.X - endCoord.X > 0)
                    endCoord.X = startCoord.X + startCoord.Y - endCoord.Y;
            }
        }

        //draws out the line
        public void Draw(PaintEventArgs g) {

            if (startRatio.X != 0 && startRatio.Y != 0 && endRatio.X != 0 && endRatio.Y != 0) {
                if (temp == true)
                    g.Graphics.DrawLine(tempPen, parent.Width / startRatio.X, parent.Height / startRatio.Y, parent.Width / endRatio.X, parent.Height / endRatio.Y);
                else
                    g.Graphics.DrawLine(pen, parent.Width / startRatio.X, parent.Height / startRatio.Y, parent.Width / endRatio.X, parent.Height / endRatio.Y);
            }
        }

        //draws the line to the bitmap out the line
        public void Export(Graphics g) {
            if (temp == true)
                g.DrawLine(tempPen, parent.Width / startRatio.X, parent.Height / startRatio.Y, parent.Width / endRatio.X, parent.Height / endRatio.Y);
            else
                g.DrawLine(pen, parent.Width / startRatio.X, parent.Height / startRatio.Y, parent.Width / endRatio.X, parent.Height / endRatio.Y);
        }

        //saves the data abou this object
        public void SaveData(StreamWriter sw) {

            //saves the start and end points of the line
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

            //sets the start and end points of the line
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
