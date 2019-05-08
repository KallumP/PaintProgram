﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using PhotoMarket.DrawingClasses;


namespace PhotoMarket {
    public partial class Form1 : Form {
        enum DrawingMode { Mouse, Pen, Square, Circle, Line, Image };
        DrawingMode drawType;

        public int penWidth;
        public Color penColor;
        Pen globalPen;

        //creates lists of drawing objects
        List<PenDrawing> penDrawings = new List<PenDrawing>();
        List<SquareDrawings> squareDrawings = new List<SquareDrawings>();
        List<CircleDrawings> circleDrawings = new List<CircleDrawings>();
        List<LineDrawings> lineDrawings = new List<LineDrawings>();
        List<ImageDrawing> imageDrawings = new List<ImageDrawing>();
        ImageDrawing background;

        //creates a list of drawing modes to be used to order each drawing
        List<DrawingMode> drawOrder = new List<DrawingMode>();

        //a variable that lets the program know that mouse has been held down
        bool mouseClickedDown = false;

        string projectExtension = ".txt";

        //constructor
        public Form1() {
            InitializeComponent();
        }

        //initial loading code
        private void Form1_Load(object sender, EventArgs e) {

            //maximises the form
            WindowState = FormWindowState.Maximized;

            //sets the drawing mode for the user (starts off as pen)
            drawType = DrawingMode.Pen;

            //sets the color of the pen
            penColor = Color.Black;

            //sets the width of the pen
            penWidth = 1;

            //creates a global pen with the chosen color and width
            UpdateGlobalPen(penColor, penWidth);

            //updates the location of objects and updates labels
            InvalidateAll();
            UpdateObjectLocations();
        }

        //normalizes the resize function
        private void Form1_Resize(object sender, EventArgs e) {

            //resizes the drawing area when the window resizes
            if (Height < 600) {
                Height = 600;
            }
            if (Width < 600) {
                Width = 600;
            }
            UpdateObjectLocations();
        }

        //updates the location of all the objects in the program. used for scalability
        void UpdateObjectLocations() {
            drawArea_pic.Size = new Size(Width - 80, Height - 100);
            colorPallet_pic.Location = new Point(Width - 65, 50);
            brushSizeChange_pic.Location = new Point(Width - 60, Height - 160);
            widthDemo_pic.Location = new Point(Width - 60, Height - 91);
            functionBtns_pic.Location = new Point(Width - 110, 2);
            InvalidateAll();
        }

        //updates the user on what drawing mode they are using
        public void InvalidateAll() {
            drawArea_pic.Invalidate();
            colorPallet_pic.Invalidate();
            widthDemo_pic.Invalidate();
        }



        //Paint Inputs----------------------------------------------------------------------------------------------------------------------------------------------------------

        //deals with mouse inputs
        private void DrawArea_pic_MouseDown(object sender, MouseEventArgs e) {

            //deals with clicking down
            if (mouseClickedDown == false) {
                if (drawType == DrawingMode.Pen) {
                    PenClickDown(e);
                } else if (drawType == DrawingMode.Square) {
                    SquareClickDown(e);
                } else if (drawType == DrawingMode.Circle) {
                    CircleClickDown(e);
                } else if (drawType == DrawingMode.Line) {
                    LineClickDown(e);
                }
            }

            if (drawType == DrawingMode.Image)
                ImageClickDown(e);

            drawArea_pic.Invalidate();
        }
        private void DrawArea_pic_MouseUp(object sender, MouseEventArgs e) {

            //deals with letting go of click
            if (mouseClickedDown == true) {
                if (drawType == DrawingMode.Pen) {
                    PenClickUp(e);
                } else if (drawType == DrawingMode.Square) {
                    SquareClickUp(e);
                } else if (drawType == DrawingMode.Circle) {
                    CircleClickUp(e);
                } else if (drawType == DrawingMode.Line) {
                    LineClickUp(e);
                }
            }

            drawArea_pic.Invalidate();
        }
        private void DrawArea_pic_MouseMove(object sender, MouseEventArgs e) {

            //deals with mouse movements while the mouse is held down
            if (mouseClickedDown == true) {
                if (drawType == DrawingMode.Pen)
                    PenClickMove(e);
                else if (drawType == DrawingMode.Square)
                    SquareClickMove(e);
                else if (drawType == DrawingMode.Circle)
                    CircleClickMove(e);
                else if (drawType == DrawingMode.Line)
                    LineClickMove(e);
            }

            if (drawType == DrawingMode.Image)
                ImageMouseMove(e);

            drawArea_pic.Invalidate();
        }

        //deals with inputs for the pen drawing mode
        void PenClickDown(MouseEventArgs e) {

            //lets the program know that the mouse is being held down
            mouseClickedDown = true;

            //creates a new object of penDrawings to store all the coordinates of the new line
            penDrawings.Add(new PenDrawing(globalPen, this));

            //adds the first line
            penDrawings[penDrawings.Count() - 1].addNewCoordinate(new Point(e.X, e.Y));


            //lets the program know to draw a pen drawing next
            drawOrder.Add(DrawingMode.Pen);
        }
        void PenClickUp(MouseEventArgs e) {

            //adds a new coordinate to the coordinate list of the current index of the pen drawing list
            penDrawings[penDrawings.Count() - 1].addNewCoordinate(new Point(e.X, e.Y));

            //lets the program know that click is no longer being held down
            mouseClickedDown = false;
        }
        void PenClickMove(MouseEventArgs e) {

            //adds a new coordinate to the coordinate list of the current index of the pen drawing list
            penDrawings[penDrawings.Count() - 1].addNewCoordinate(new Point(e.X, e.Y));
        }

        //deals with inputs for the square drawing mode
        void SquareClickDown(MouseEventArgs e) {

            //lets the program know that the mouse is held down
            mouseClickedDown = true;

            //creates a new instance of the square drawing
            squareDrawings.Add(new SquareDrawings(new Point(e.X, e.Y), globalPen, this));

            //lets the program know to draw a square drawing next
            drawOrder.Add(DrawingMode.Square);
        }
        void SquareClickUp(MouseEventArgs e) {

            //lets the program know that click has been let go of
            mouseClickedDown = false;

            //adds in the final position of the mouse and parses if shift was pressed
            if (ModifierKeys == Keys.Shift)
                squareDrawings[squareDrawings.Count - 1].setEndPoint(new PointF(e.X, e.Y), true, true);
            else
                squareDrawings[squareDrawings.Count - 1].setEndPoint(new PointF(e.X, e.Y), false, true);

            //makes the screen redraw
            drawArea_pic.Invalidate();
        }
        void SquareClickMove(MouseEventArgs e) {

            //adds in the final position of the mouse and parses if shift was pressed
            if (ModifierKeys == Keys.Shift)
                squareDrawings[squareDrawings.Count - 1].setEndPoint(new PointF(e.X, e.Y), true, false);
            else
                squareDrawings[squareDrawings.Count - 1].setEndPoint(new PointF(e.X, e.Y), false, false);

            //makes the screen redraw
            drawArea_pic.Invalidate();
        }

        //deals with inputs for the circle drawing mode
        void CircleClickDown(MouseEventArgs e) {

            //lets the program know that the mouse is held down
            mouseClickedDown = true;

            //creates a new instance of the square drawing
            circleDrawings.Add(new CircleDrawings(new PointF(e.X, e.Y), globalPen, this));

            //lets the program know to draw a circle drawing next
            drawOrder.Add(DrawingMode.Circle);
        }
        void CircleClickUp(MouseEventArgs e) {

            //lets the program know that click has been let go of
            mouseClickedDown = false;

            //adds in the final position of the mouse and parses if shift was pressed
            if (ModifierKeys == Keys.Shift)
                circleDrawings[circleDrawings.Count - 1].setEndPoint(new PointF(e.X, e.Y), true, true);
            else
                circleDrawings[circleDrawings.Count - 1].setEndPoint(new PointF(e.X, e.Y), false, true);

            //makes the screen redraw
            drawArea_pic.Invalidate();
        }
        void CircleClickMove(MouseEventArgs e) {

            //adds in the final position of the mouse and parses if shift was pressed
            if (ModifierKeys == Keys.Shift)
                circleDrawings[circleDrawings.Count - 1].setEndPoint(new PointF(e.X, e.Y), true, false);
            else
                circleDrawings[circleDrawings.Count - 1].setEndPoint(new PointF(e.X, e.Y), false, false);

            //makes the screen redraw
            drawArea_pic.Invalidate();
        }

        //deals with inputs for the line drawing mode
        void LineClickDown(MouseEventArgs e) {

            //lets the program know that the mouse is held down
            mouseClickedDown = true;

            //lets the program know that the mouse is held down
            lineDrawings.Add(new LineDrawings(new PointF(e.X, e.Y), globalPen, this));

            //lets the program know to draw a line drawing next
            drawOrder.Add(DrawingMode.Line);
        }
        void LineClickUp(MouseEventArgs e) {

            //lets the program know that click has been let go of
            mouseClickedDown = false;

            //adds in the final position of the mouse and parses if shift was pressed
            if (ModifierKeys == Keys.Shift)
                lineDrawings[lineDrawings.Count - 1].setEnd(new PointF(e.X, e.Y), true, false, true);
            else if (ModifierKeys == Keys.Control)
                lineDrawings[lineDrawings.Count - 1].setEnd(new PointF(e.X, e.Y), false, true, true);
            else
                lineDrawings[lineDrawings.Count - 1].setEnd(new PointF(e.X, e.Y), false, false, true);

            //makes the screen redraw
            drawArea_pic.Invalidate();
        }
        void LineClickMove(MouseEventArgs e) {

            //adds in the position of the mouse and parses if shift was pressed
            if (ModifierKeys == Keys.Shift)
                lineDrawings[lineDrawings.Count - 1].setEnd(new PointF(e.X, e.Y), true, false, false);
            else if (ModifierKeys == Keys.Control)
                lineDrawings[lineDrawings.Count - 1].setEnd(new PointF(e.X, e.Y), false, true, false);
            else
                lineDrawings[lineDrawings.Count - 1].setEnd(new PointF(e.X, e.Y), false, false, false);

            //makes the screen redraw
            drawArea_pic.Invalidate();
        }

        //lets the user choose where to put an image
        void ImageClickDown(MouseEventArgs e) {

            //lets the program know that the mouse is held down
            imageDrawings[imageDrawings.Count - 1].SetStartPoint(new PointF(e.X, e.Y));

            //sets the draw mode back to mouse
            drawType = DrawingMode.Mouse;
        }
        void ImageMouseMove(MouseEventArgs e) {
            //lets the program know that the mouse is held down
            imageDrawings[imageDrawings.Count - 1].SetStartPoint(new PointF(e.X, e.Y));
        }


        //Brushes----------------------------------------------------------------------------------------------------------------------------------------------------------

        //changes the sizes of the pen
        private void BrushSizeChange_pic_MouseClick(object sender, MouseEventArgs e) {
            if (e.Y < 25)
                IncreasePenWidth();
            else if (e.Y > 30 && e.Y < 55)
                DecreasePenWidth();
        }
        private void BrushSizeChange_pic_MouseDoubleClick(object sender, MouseEventArgs e) {
            if (e.Y < 27)
                IncreasePenWidth();
            else if (e.Y >= 27)
                DecreasePenWidth();
        }
        private void DecreasePenWidth() {
            if (ModifierKeys == Keys.Shift) {

                //decreases the width of the pen for normal click
                penWidth /= 2;
            } else {

                //fine decrease for shift click
                penWidth -= 1;
            }

            //stops the pen from being smaller than 1
            if (penWidth < 1)
                penWidth = 1;

            //updates the brush and the labels
            UpdateGlobalPen(penColor, penWidth);
            InvalidateAll();
            widthDemo_pic.Invalidate();
        }
        private void IncreasePenWidth() {
            if (ModifierKeys == Keys.Shift) {

                //increase the width of the pen for normal click
                penWidth *= 2;

            } else {

                //fine increase for shift click
                penWidth += 1;
            }

            //stops the pen width from being bigger than 38
            if (penWidth > 38)
                penWidth = 38;

            //updates the brush and the labels
            UpdateGlobalPen(penColor, penWidth);
            InvalidateAll();
            widthDemo_pic.Invalidate();
        }

        //finds out where on the options was clicked, and sets the draw type accordingly
        private void Options_pic_MouseClick(object sender, MouseEventArgs e) {
            if (e.X < 45) {
                drawType = DrawingMode.Mouse;
            } else if (e.X < 90) {
                drawType = DrawingMode.Pen;
            } else if (e.X < 135) {
                drawType = DrawingMode.Square;
            } else if (e.X < 180) {
                drawType = DrawingMode.Circle;
            } else if (e.X < 225) {
                drawType = DrawingMode.Line;
            } else if (e.X < 270) {

                //makes the user open a project
                OpenFileDialog opener = new OpenFileDialog();
                if (opener.ShowDialog() == DialogResult.OK) {

                    //makes sure that the right type of file was entered
                    if (opener.FileName.ToLower().Contains(".png") || opener.FileName.ToLower().Contains(".jpg")) {

                        //sets up an image with the chosen path
                        imageDrawings.Add(new ImageDrawing(opener.FileName, this));

                        drawOrder.Add(DrawingMode.Image);

                        drawType = DrawingMode.Image;
                    }
                }
            }

            options_pic.Invalidate();
            InvalidateAll();
        }

        //updates the global pen
        public void UpdateGlobalPen(Color newColor, float newWidth) {

            //sets the color and width of the pen
            globalPen = new Pen(newColor, newWidth);

            //makes the start and the end of the line rounded
            globalPen.SetLineCap(
                System.Drawing.Drawing2D.LineCap.Round,
                System.Drawing.Drawing2D.LineCap.Round,
                System.Drawing.Drawing2D.DashCap.Round);
        }

        //checks to see what color was chosen when clicking on the color pallet
        private void ColorPallet_pic_MouseClick(object sender, MouseEventArgs e) {

            //sets the color of the pen
            if (e.Y < 40)
                penColor = Color.Black;
            else if (e.Y < 80)
                penColor = Color.Red;
            else if (e.Y < 120)
                penColor = Color.Blue;
            else if (e.Y < 160)
                penColor = Color.Green;
            else if (e.Y < 200)
                penColor = Color.Yellow;
            else if (e.Y < 240)
                penColor = Color.Brown;
            else if (e.Y < 280)
                penColor = Color.White;
            else if (e.Y < 320) {
                ColorPicker cp = new ColorPicker(this);
                cp.Show();
                string newColor = "#000000";
                penColor = ColorTranslator.FromHtml(newColor);
            }

            //updates the global pen
            UpdateGlobalPen(penColor, penWidth);
            InvalidateAll();

            //updates the brush picture (showing the size and color of the brush)
            widthDemo_pic.Invalidate();
            colorPallet_pic.Invalidate();
        }



        //Invalidates----------------------------------------------------------------------------------------------------------------------------------------------------------

        //draws the screen
        private void DrawArea_pic_Paint(object sender, PaintEventArgs e) {

            //makes the background white
            e.Graphics.FillRectangle(Brushes.White, 0, 0, drawArea_pic.Width, drawArea_pic.Height);

            if (background != null)
                background.Draw(e);

            //an if statement to make sure that there are drawing to draw before trying to draw
            if (drawOrder.Count() != 0) {

                //numbers used to store which order each drawing list is at 
                int penOrder = 0;
                int squareOrder = 0;
                int circleOrder = 0;
                int lineOrder = 0;
                int imageOrder = 0;

                //goes through the order to draw
                for (int i = 0; i < drawOrder.Count(); i++) {

                    //draws the next pen drawing
                    if (drawOrder[i] == DrawingMode.Pen) {
                        penDrawings[penOrder].Draw(e);
                        penOrder++;

                        //draws the next square drawing
                    } else if (drawOrder[i] == DrawingMode.Square) {
                        squareDrawings[squareOrder].Draw(e);
                        squareOrder++;

                        //draws the next circle drawing
                    } else if (drawOrder[i] == DrawingMode.Circle) {
                        circleDrawings[circleOrder].Draw(e);
                        circleOrder++;

                        //draws the next line drawing
                    } else if (drawOrder[i] == DrawingMode.Line) {
                        lineDrawings[lineOrder].Draw(e);
                        lineOrder++;

                        //draws the next image drawing
                    } else if (drawOrder[i] == DrawingMode.Image) {
                        imageDrawings[imageOrder].Draw(e);
                        imageOrder++;
                    }
                }
            }
        }

        //draws color pallet
        private void ColorPallet_pic_Paint(object sender, PaintEventArgs e) {

            //draws a small indicator for the color being used
            if (globalPen.Color == Color.Black)
                e.Graphics.FillRectangle(Brushes.LightGreen, 0, 10, 4, 20);
            else if (globalPen.Color == Color.Red)
                e.Graphics.FillRectangle(Brushes.LightGreen, 0, 50, 4, 20);
            else if (globalPen.Color == Color.Blue)
                e.Graphics.FillRectangle(Brushes.LightGreen, 0, 90, 4, 20);
            else if (globalPen.Color == Color.Green)
                e.Graphics.FillRectangle(Brushes.LightGreen, 0, 130, 4, 20);
            else if (globalPen.Color == Color.Yellow)
                e.Graphics.FillRectangle(Brushes.LightGreen, 0, 170, 4, 20);
            else if (globalPen.Color == Color.Brown)
                e.Graphics.FillRectangle(Brushes.LightGreen, 0, 210, 4, 20);
            else if (globalPen.Color == Color.White)
                e.Graphics.FillRectangle(Brushes.LightGreen, 0, 250, 4, 20);
            else
                e.Graphics.FillRectangle(Brushes.LightGreen, 0, 290, 4, 20);

            //draws out the different colors that can be chosen
            e.Graphics.FillRectangle(Brushes.Black, 4, 0, 40, 40);
            e.Graphics.DrawRectangle(Pens.Black, 4, 0, 40, 40);

            e.Graphics.FillRectangle(Brushes.Red, 4, 40, 40, 40);
            e.Graphics.DrawRectangle(Pens.Black, 4, 40, 40, 40);

            e.Graphics.FillRectangle(Brushes.Blue, 4, 80, 40, 40);
            e.Graphics.DrawRectangle(Pens.Black, 4, 80, 40, 40);

            e.Graphics.FillRectangle(Brushes.Green, 4, 120, 40, 40);
            e.Graphics.DrawRectangle(Pens.Black, 4, 120, 40, 40);

            e.Graphics.FillRectangle(Brushes.Yellow, 4, 160, 40, 40);
            e.Graphics.DrawRectangle(Pens.Black, 4, 160, 40, 40);

            e.Graphics.FillRectangle(Brushes.Brown, 4, 200, 40, 40);
            e.Graphics.DrawRectangle(Pens.Black, 4, 200, 40, 40);

            e.Graphics.FillRectangle(Brushes.White, 4, 240, 40, 40);
            e.Graphics.DrawRectangle(Pens.Black, 4, 240, 40, 40);

            e.Graphics.DrawImage(Properties.Resources._ColorPicker, 4, 280, 40, 40);
            e.Graphics.DrawRectangle(Pens.Black, 4, 280, 40, 40);
        }

        //draws out the increase and decrease buttons
        private void BrushSizeChange_pic_Paint(object sender, PaintEventArgs e) {
            e.Graphics.DrawLine(Pens.Black, 0, brushSizeChange_pic.Height / 2, brushSizeChange_pic.Width, brushSizeChange_pic.Height / 2);
            e.Graphics.DrawString("+", DefaultFont, Brushes.Black, -7 + brushSizeChange_pic.Width / 2, -6 + brushSizeChange_pic.Height / 4);
            e.Graphics.DrawString("-", DefaultFont, Brushes.Black, -6 + brushSizeChange_pic.Width / 2, -6 + brushSizeChange_pic.Height * 3 / 4);
        }

        //draws out the different options that can be used
        private void Options_pic_Paint(object sender, PaintEventArgs e) {

            //shows what option has been selected
            if (drawType == DrawingMode.Mouse)
                e.Graphics.FillRectangle(Brushes.PaleVioletRed, 10, 40, 20, 4);
            else if (drawType == DrawingMode.Pen)
                e.Graphics.FillRectangle(Brushes.PaleVioletRed, 55, 40, 20, 4);
            else if (drawType == DrawingMode.Square)
                e.Graphics.FillRectangle(Brushes.PaleVioletRed, 100, 40, 20, 4);
            else if (drawType == DrawingMode.Circle)
                e.Graphics.FillRectangle(Brushes.PaleVioletRed, 145, 40, 20, 4);
            else if (drawType == DrawingMode.Line)
                e.Graphics.FillRectangle(Brushes.PaleVioletRed, 190, 40, 20, 4);
            else if (drawType == DrawingMode.Image)
                e.Graphics.FillRectangle(Brushes.PaleVioletRed, 235, 40, 20, 4);

            //draws a box around each option
            for (int i = 0; i < 6; i++)
                e.Graphics.DrawRectangle(Pens.Black, i * 45, 0, 40, 40);

            //draws each option
            e.Graphics.DrawImage(Properties.Resources._Mouse, 0, 0, 40, 40);
            e.Graphics.DrawImage(Properties.Resources._Brush, 45, 0, 40, 40);
            e.Graphics.DrawImage(Properties.Resources._Square, 90, 0, 40, 40);
            e.Graphics.DrawImage(Properties.Resources._Circle, 135, 0, 40, 40);
            e.Graphics.DrawImage(Properties.Resources._Line, 180, 0, 40, 40);
            e.Graphics.DrawImage(Properties.Resources._Image, 225, 0, 40, 40);
        }

        //shows the thickness of the brush
        private void WidthDemo_pic_Paint(object sender, PaintEventArgs e) {
            SolidBrush brush = new SolidBrush(penColor);
            e.Graphics.FillEllipse(brush, 19 - (penWidth / 2), 19 - (penWidth / 2), penWidth, penWidth);
        }

        //draws in the function images
        private void FunctionBtns_pic_Paint(object sender, PaintEventArgs e) {
            e.Graphics.DrawImage(Properties.Resources._Delete, 0, 0, 40, 40);
            e.Graphics.DrawImage(Properties.Resources._Options, 50, 0, 40, 40);
        }



        //Functions----------------------------------------------------------------------------------------------------------------------------------------------------------

        //finds out what save option the user wants
        private void OpenOptions() {
            OptionsWindow s = new OptionsWindow(this);

            s.Show();
        }

        //exports the data as an image
        public void ExportImage() {

            //creates a save file dialog
            SaveFileDialog saver = new SaveFileDialog();

            //makes it so that the user can only save as png
            saver.Filter = "PNG(*.PNG)|*.png|JPG(*.JPG)|*.jpg";

            //makes the user choose where to save the file
            if (saver.ShowDialog() == DialogResult.OK) {

                //creates a bitmap which will be drawn to
                Bitmap toSave = new Bitmap(drawArea_pic.Width, drawArea_pic.Height);

                //uses a graphics library to draw to the file
                using (Graphics g = Graphics.FromImage(toSave)) {

                    //makes the background white
                    g.FillRectangle(Brushes.White, 0, 0, drawArea_pic.Width, drawArea_pic.Height);

                    if (background != null)
                        background.Export(g);

                    if (drawOrder.Count() != 0) {

                        //numbers used to store which order each drawing list is at 
                        int penOrder = 0;
                        int squareOrder = 0;
                        int circleOrder = 0;
                        int lineOrder = 0;
                        int imageOrder = 0;

                        //goes through the order to draw
                        for (int i = 0; i < drawOrder.Count(); i++) {

                            //draws the next pen drawing
                            if (drawOrder[i] == DrawingMode.Pen) {
                                penDrawings[penOrder].Export(g);
                                penOrder++;

                                //draws the next square drawing                           
                            } else if (drawOrder[i] == DrawingMode.Square) {
                                squareDrawings[squareOrder].Export(g);
                                squareOrder++;

                                //draws the next circle drawing
                            } else if (drawOrder[i] == DrawingMode.Circle) {
                                circleDrawings[circleOrder].Export(g);
                                circleOrder++;

                                //draws the next line drawing
                            } else if (drawOrder[i] == DrawingMode.Line) {
                                lineDrawings[lineOrder].Export(g);
                                lineOrder++;

                                //draws the next image
                            } else if (drawOrder[i] == DrawingMode.Image) {
                                imageDrawings[imageOrder].Export(g);
                                imageOrder++;
                            }
                        }
                    }
                }

                //saves the image
                toSave.Save(saver.FileName);
            }
        }

        //saves the data as a project file
        public void SaveProject() {

            SaveFileDialog saver = new SaveFileDialog();

            //makes it so that the user can only save as png
            saver.Filter = "TXT(*.TXT)|*.txt";

            //makes the user choose a file path to save to
            if (saver.ShowDialog() == DialogResult.OK) {

                //opens up the text file
                StreamWriter sw = new StreamWriter(saver.FileName);

                //starts to go through the different drawings in the project
                if (drawOrder.Count != 0) {

                    //numbers used to store which order each drawing list is at 
                    int penOrder = 0;
                    int squareOrder = 0;
                    int circleOrder = 0;
                    int lineOrder = 0;

                    for (int i = 0; i < drawOrder.Count; i++) {
                        if (i == drawOrder.Count - 1)
                            sw.WriteLine(drawOrder[i]);
                        else
                            sw.Write(drawOrder[i] + ",");
                    }

                    //goes through the order to draw
                    for (int i = 0; i < drawOrder.Count(); i++) {

                        //draws the next pen drawing
                        if (drawOrder[i] == DrawingMode.Pen) {
                            penDrawings[penOrder].saveData(sw);
                            penOrder++;

                            //draws the next square drawing                           
                        } else if (drawOrder[i] == DrawingMode.Square) {
                            squareDrawings[squareOrder].saveData(sw);
                            squareOrder++;

                            //draws the next circle drawing
                        } else if (drawOrder[i] == DrawingMode.Circle) {
                            circleDrawings[circleOrder].saveData(sw);
                            circleOrder++;

                            //draws the next line drawing
                        } else if (drawOrder[i] == DrawingMode.Line) {
                            lineDrawings[lineOrder].saveData(sw);
                            lineOrder++;

                        }
                    }

                    //closes the file
                    sw.Close();
                }
            }
        }

        //loads up a project
        public void LoadProject() {

            OpenFileDialog opener = new OpenFileDialog();

            //makes the user open a project
            if (opener.ShowDialog() == DialogResult.OK) {

                //makes sure that the right type of file was entered
                if (opener.FileName.Contains(projectExtension)) {

                    //clears the drawings ready for the new project
                    ClearDrawings();

                    //opens the file in the program
                    StreamReader sr = new StreamReader(opener.FileName);

                    //gets the first line from the file and splits it into an array (ready to make the draw orders)
                    string rawOrder = sr.ReadLine();
                    string[] orderArray = rawOrder.Split(',');

                    //goes through the array, and adds the correct drawing mode to the drawOrder list
                    foreach (string s in orderArray) {
                        if (s == "Square")
                            drawOrder.Add(DrawingMode.Square);
                        else if (s == "Circle")
                            drawOrder.Add(DrawingMode.Circle);
                        else if (s == "Line")
                            drawOrder.Add(DrawingMode.Line);
                        else if (s == "Pen")
                            drawOrder.Add(DrawingMode.Pen);
                    }

                    //makes sure that the drawOrder has atleast one value in it
                    if (drawOrder.Count != 0) {

                        //numbers used to store which order each drawing list is at 
                        int penOrder = 0;
                        int squareOrder = 0;
                        int circleOrder = 0;
                        int lineOrder = 0;

                        //goes through the order to add drawings
                        for (int i = 0; i < drawOrder.Count(); i++) {

                            //adds the next pen drawing
                            if (drawOrder[i] == DrawingMode.Pen) {
                                penDrawings.Add(new PenDrawing(this));
                                penDrawings[penOrder].loadData(sr);
                                penOrder++;

                                //adds the next square drawing                           
                            } else if (drawOrder[i] == DrawingMode.Square) {
                                squareDrawings.Add(new SquareDrawings(this));
                                squareDrawings[squareOrder].loadData(sr);
                                squareOrder++;

                                //adds the next circle drawing
                            } else if (drawOrder[i] == DrawingMode.Circle) {
                                circleDrawings.Add(new CircleDrawings(this));
                                circleDrawings[circleOrder].loadData(sr);
                                circleOrder++;

                                //adds the next line drawing
                            } else if (drawOrder[i] == DrawingMode.Line) {
                                lineDrawings.Add(new LineDrawings(this));
                                lineDrawings[lineOrder].loadData(sr);
                                lineOrder++;

                            }
                        }
                    }
                    //closes the file
                    sr.Close();

                    //redraws the picture
                    drawArea_pic.Invalidate();

                }
            }
        }

        //changes the background image
        public void ChangeBackground() {

            string path = "";

            OpenFileDialog opener = new OpenFileDialog();

            //makes the user open a project
            if (opener.ShowDialog() == DialogResult.OK) {
                if (opener.FileName.ToLower().Contains(".jpg") || opener.FileName.ToLower().Contains(".png")) {

                    path = opener.FileName;
                    background = new ImageDrawing(new PointF(0f, 0f), path, this);
                }
            }

        }

        //removes the background image
        public void RemoveBackground() {
            background = null;
        }

        //ensures that the user wants to clear the drawing
        private void EnsureClearDrawing() {
            Warning w = new Warning(this);

            w.Show();
        }

        //clears out the paint area
        public void ClearDrawings() {

            //removes all elements from the list
            penDrawings.Clear();
            squareDrawings.Clear();
            circleDrawings.Clear();
            lineDrawings.Clear();
            imageDrawings.Clear();
            drawOrder.Clear();

            //makes the screen redraw (now as a blank screen)
            drawArea_pic.Invalidate();
        }

        //deals with the function buttons
        private void FunctionBtns_pic_MouseClick(object sender, MouseEventArgs e) {
            if (e.X < 40)
                EnsureClearDrawing();
            else if (e.X > 50 && e.X < 90)
                OpenOptions();
        }

        //lets the user use number inputs to change the draw type
        private void Form1_KeyDown(object sender, KeyEventArgs e) {

            //makes sure that the mode can't be switched mid drawing
            if (mouseClickedDown == false) {
                if (e.KeyCode == Keys.D1)
                    drawType = DrawingMode.Mouse;
                else if (e.KeyCode == Keys.D2)
                    drawType = DrawingMode.Pen;
                else if (e.KeyCode == Keys.D3)
                    drawType = DrawingMode.Square;
                else if (e.KeyCode == Keys.D4)
                    drawType = DrawingMode.Circle;
                else if (e.KeyCode == Keys.D5)
                    drawType = DrawingMode.Line;
                else if (e.KeyCode == Keys.Add)
                    IncreasePenWidth();
                else if (e.KeyCode == Keys.Oemplus)
                    IncreasePenWidth();
                else if (e.KeyCode == Keys.Subtract)
                    DecreasePenWidth();
                else if (e.KeyCode == Keys.OemMinus)
                    DecreasePenWidth();
            }

            options_pic.Invalidate();
            InvalidateAll();
        }
    }
}
