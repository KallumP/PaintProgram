using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PhotoMarket {
    class LineDrawings : DeepCopy {
        Point start, end;
        Pen pen;

        bool temp = true;

        bool ctrlDown;
        bool shiftDown;

        //constructors
        public LineDrawings(Point _start, Pen _pen) {
            start = _start;
            pen = _pen;
            deepCopy(_pen);
        }
        public LineDrawings() {

        }

        //sets the final position of the mouse
        public void setEnd(Point _end, bool _shiftDown, bool _ctrlDown, bool finalPoint) {
            end = _end;
            shiftDown = _shiftDown;
            ctrlDown = _ctrlDown;
            angleFix();

            //lets the program know that the final point has been placed
            if (finalPoint == true)
                temp = false;
        }

        //fixes the end point if shift is held down
        public void angleFix() {

            //a check to see if shift was pressed down
            if (shiftDown == true) {

                //snaps the line end to 90 degrees
                if (Math.Abs(start.Y - end.Y) > Math.Abs(start.X - end.X)) {
                    end.X = start.X;
                } else {
                    end.Y = start.Y;
                }

                //a check to see if control was pressed down
            } else if (ctrlDown == true) {

                //snaps the line end to 45 degrees
                if (start.Y - end.Y > 0 && start.X - end.X > 0) {
                    end.X = start.X - (start.Y - end.Y);
                } else if ((start.Y - end.Y) < 0 && (start.X - end.X) < 0) {
                    end.X = start.X - (start.Y - end.Y);
                } else if (start.Y - end.Y > 0 && start.X - end.X < 0) {
                    end.X = start.X + start.Y - end.Y;
                } else if (start.Y - end.Y < 0 && start.X - end.X > 0) {
                    end.X = start.X + start.Y - end.Y;
                }
            }
        }

        //draws out the line
        public void drawLine(PaintEventArgs g) {
            if (temp == true) {
                g.Graphics.DrawLine(tempPen, start, end);

            } else
                g.Graphics.DrawLine(pen, start, end);
        }

        //draws the line to the bitmap out the line
        public void exportLine(Graphics g) {
            if (temp == true) {
                g.DrawLine(tempPen, start, end);

            } else
                g.DrawLine(pen, start, end);
        }

        //saves the data abou this object
        public void saveData(StreamWriter sw) {

            //saves the start and end points of the line
            sw.WriteLine(start.X);
            sw.WriteLine(start.Y);
            sw.WriteLine(end.X);
            sw.WriteLine(end.Y);

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

            //sets the start and end points of the line
            start.X = Convert.ToInt16(sr.ReadLine());
            start.Y = Convert.ToInt16(sr.ReadLine());
            end.X = Convert.ToInt16(sr.ReadLine());
            end.Y = Convert.ToInt16(sr.ReadLine());

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
