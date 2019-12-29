using PhotoMarket.DrawingClasses;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Input;


namespace PhotoMarket {
    public partial class MainWindow : Form {

        enum DrawingMode { Mouse, Pen, Square, Circle, Line, Image };
        DrawingMode drawType;

        public int penWidth;
        public Color penColor;
        Pen globalPen;

        public bool ratioBind = false;
        public float ratio;
        public int canvasSizeX;
        public int canvasSizeY;

        //creates a list of layers to be used 
        public List<Layer> layers = new List<Layer>();
        public int currentLayer = 0;

        //the image used for a background
        ImageDrawing background;

        bool transparentBackground;

        //a variable that lets the program know that mouse has been held down
        bool mouseClickedDown = false;

        public string projectExtension = ".pain";

        string path;

        //constructor
        public MainWindow() {
            InitializeComponent();
            Layer.parent = this;
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

            //sets the saves the size of the canvas
            canvasSizeX = canvas.Width;
            canvasSizeY = canvas.Height;

            layers.Add(new Layer());

            //updates the location of objects and updates labels
            InvalidateAll();
        }

        //deals with what should happen when the form resizes
        private void Form1_Resize(object sender, EventArgs e) {
            ResizeHandler();
        }


        #region Paint Inputs
        //deals with mouse inputs
        private void Canvas_MouseDown(object sender, MouseEventArgs e) {

            //deals with clicking down
            if (mouseClickedDown == false) {
                if (drawType == DrawingMode.Pen)
                    PenMouseDown(e);
                else if (drawType == DrawingMode.Square)
                    SquareMouseDown(e);
                else if (drawType == DrawingMode.Circle)
                    CircleMouseDown(e);
                else if (drawType == DrawingMode.Line)
                    LineMouseDown(e);
                else if (drawType == DrawingMode.Image)
                    ImageMouseDown(e);
            }

            canvas.Invalidate();
        }
        private void Canvas_MouseUp(object sender, MouseEventArgs e) {

            //deals with letting go of click
            if (mouseClickedDown == true) {
                if (drawType == DrawingMode.Pen)
                    PenMouseUp(e);
                else if (drawType == DrawingMode.Square)
                    SquareMouseUp(e);
                else if (drawType == DrawingMode.Circle)
                    CircleMouseUp(e);
                else if (drawType == DrawingMode.Line)
                    LineMouseUp(e);
                else if (drawType == DrawingMode.Image)
                    ImageMouseUp(e);
            }

            canvas.Invalidate();
        }
        private void Canvas_MouseMove(object sender, MouseEventArgs e) {

            //deals with mouse movements while the mouse is held down
            if (mouseClickedDown == true) {
                if (drawType == DrawingMode.Pen)
                    PenMouseMove(e);
                else if (drawType == DrawingMode.Square)
                    SquareMouseMove(e);
                else if (drawType == DrawingMode.Circle)
                    CircleMouseMove(e);
                else if (drawType == DrawingMode.Line)
                    LineMouseMove(e);
                else if (drawType == DrawingMode.Image)
                    ImageMouseMove(e);
            } else {
                if (drawType == DrawingMode.Image)
                    ImageMouseMoveNoClick(e);
            }

            canvas.Invalidate();
        }

        //deals with inputs for the pen drawing mode
        void PenMouseDown(MouseEventArgs e) {

            //lets the program know that the mouse is being held down
            mouseClickedDown = true;

            //creates a new object of penDrawings to store all the coordinates of the new line
            layers[currentLayer].penDrawings.Add(new PenDrawing(globalPen, this));

            //adds the first line
            layers[currentLayer].penDrawings[layers[currentLayer].penDrawings.Count() - 1].AddNewCoordinate(new Point(e.X, e.Y));

            //lets the program know to draw a pen drawing next
            layers[currentLayer].drawOrder.Add(Layer.DrawingMode.Pen);

        }
        void PenMouseUp(MouseEventArgs e) {

            //adds a new coordinate to the coordinate list of the current index of the pen drawing list
            layers[currentLayer].penDrawings[layers[currentLayer].penDrawings.Count() - 1].AddNewCoordinate(new Point(e.X, e.Y));

            //lets the program know that click is no longer being held down
            mouseClickedDown = false;
        }
        void PenMouseMove(MouseEventArgs e) {

            //adds a new coordinate to the coordinate list of the current index of the pen drawing list
            layers[currentLayer].penDrawings[layers[currentLayer].penDrawings.Count() - 1].AddNewCoordinate(new Point(e.X, e.Y));
        }

        //deals with inputs for the square drawing mode
        void SquareMouseDown(MouseEventArgs e) {

            //lets the program know that the mouse is held down
            mouseClickedDown = true;

            //creates a new instance of the square drawing
            layers[currentLayer].squareDrawings.Add(new SquareDrawing(new Point(e.X, e.Y), globalPen, this));

            //lets the program know to draw a square drawing next
            layers[currentLayer].drawOrder.Add(Layer.DrawingMode.Square);
        }
        void SquareMouseUp(MouseEventArgs e) {

            //lets the program know that click has been let go of
            mouseClickedDown = false;

            //adds in the final position of the mouse and parses if shift was pressed
            if (ModifierKeys == Keys.Shift)
                layers[currentLayer].squareDrawings[layers[currentLayer].squareDrawings.Count - 1].SetEndPoint(new PointF(e.X, e.Y), true, true);
            else
                layers[currentLayer].squareDrawings[layers[currentLayer].squareDrawings.Count - 1].SetEndPoint(new PointF(e.X, e.Y), false, true);

            //makes the screen redraw
            canvas.Invalidate();
        }
        void SquareMouseMove(MouseEventArgs e) {

            //adds in the final position of the mouse and parses if shift was pressed
            if (ModifierKeys == Keys.Shift)
                layers[currentLayer].squareDrawings[layers[currentLayer].squareDrawings.Count - 1].SetEndPoint(new PointF(e.X, e.Y), true, false);
            else
                layers[currentLayer].squareDrawings[layers[currentLayer].squareDrawings.Count - 1].SetEndPoint(new PointF(e.X, e.Y), false, false);

            //makes the screen redraw
            canvas.Invalidate();
        }

        //deals with inputs for the circle drawing mode
        void CircleMouseDown(MouseEventArgs e) {

            //lets the program know that the mouse is held down
            mouseClickedDown = true;

            //creates a new instance of the square drawing
            layers[currentLayer].circleDrawings.Add(new CircleDrawing(new PointF(e.X, e.Y), globalPen, this));

            //lets the program know to draw a circle drawing next
            layers[currentLayer].drawOrder.Add(Layer.DrawingMode.Circle);
        }
        void CircleMouseUp(MouseEventArgs e) {

            //lets the program know that click has been let go of
            mouseClickedDown = false;

            //adds in the final position of the mouse and parses if shift was pressed
            if (ModifierKeys == Keys.Shift)
                layers[currentLayer].circleDrawings[layers[currentLayer].circleDrawings.Count - 1].SetEndPoint(new PointF(e.X, e.Y), true, true);
            else
                layers[currentLayer].circleDrawings[layers[currentLayer].circleDrawings.Count - 1].SetEndPoint(new PointF(e.X, e.Y), false, true);

            //makes the screen redraw
            canvas.Invalidate();
        }
        void CircleMouseMove(MouseEventArgs e) {

            //adds in the final position of the mouse and parses if shift was pressed
            if (ModifierKeys == Keys.Shift)
                layers[currentLayer].circleDrawings[layers[currentLayer].circleDrawings.Count - 1].SetEndPoint(new PointF(e.X, e.Y), true, false);
            else
                layers[currentLayer].circleDrawings[layers[currentLayer].circleDrawings.Count - 1].SetEndPoint(new PointF(e.X, e.Y), false, false);

            //makes the screen redraw
            canvas.Invalidate();
        }

        //deals with inputs for the line drawing mode
        void LineMouseDown(MouseEventArgs e) {

            //lets the program know that the mouse is held down
            mouseClickedDown = true;

            //lets the program know that the mouse is held down
            layers[currentLayer].lineDrawings.Add(new LineDrawing(new PointF(e.X, e.Y), globalPen, this));

            //lets the program know to draw a line drawing next
            layers[currentLayer].drawOrder.Add(Layer.DrawingMode.Line);
        }
        void LineMouseUp(MouseEventArgs e) {

            //lets the program know that click has been let go of
            mouseClickedDown = false;

            //adds in the final position of the mouse and parses if shift was pressed
            if (ModifierKeys == Keys.Shift)
                layers[currentLayer].lineDrawings[layers[currentLayer].lineDrawings.Count - 1].SetEnd(new PointF(e.X, e.Y), true, false, true);
            else if (ModifierKeys == Keys.Control)
                layers[currentLayer].lineDrawings[layers[currentLayer].lineDrawings.Count - 1].SetEnd(new PointF(e.X, e.Y), false, true, true);
            else
                layers[currentLayer].lineDrawings[layers[currentLayer].lineDrawings.Count - 1].SetEnd(new PointF(e.X, e.Y), false, false, true);

            //makes the screen redraw
            canvas.Invalidate();
        }
        void LineMouseMove(MouseEventArgs e) {

            //adds in the position of the mouse and parses if shift was pressed
            if (ModifierKeys == Keys.Shift)
                layers[currentLayer].lineDrawings[layers[currentLayer].lineDrawings.Count - 1].SetEnd(new PointF(e.X, e.Y), true, false, false);
            else if (ModifierKeys == Keys.Control)
                layers[currentLayer].lineDrawings[layers[currentLayer].lineDrawings.Count - 1].SetEnd(new PointF(e.X, e.Y), false, true, false);
            else
                layers[currentLayer].lineDrawings[layers[currentLayer].lineDrawings.Count - 1].SetEnd(new PointF(e.X, e.Y), false, false, false);

            //makes the screen redraw
            canvas.Invalidate();
        }

        //lets the user choose where to put an image
        void ImageMouseMoveNoClick(MouseEventArgs e) {

            //lets the program know to draw an image next
            layers[currentLayer].imageDrawings[layers[currentLayer].imageDrawings.Count - 1].SetStartPoint(new PointF(e.X, e.Y));
        }
        void ImageMouseDown(MouseEventArgs e) {

            //lets the program know that mouse is clicked down
            mouseClickedDown = true;

            //adds the starting point
            layers[currentLayer].imageDrawings[layers[currentLayer].imageDrawings.Count - 1].SetStartPoint(new PointF(e.X, e.Y));

        }
        void ImageMouseMove(MouseEventArgs e) {
            layers[currentLayer].imageDrawings[layers[currentLayer].imageDrawings.Count - 1].SetEndPoint(new PointF(e.X, e.Y));
        }
        void ImageMouseUp(MouseEventArgs e) {

            //lets the program know that mouse is no longer clicked down
            mouseClickedDown = false;


            layers[currentLayer].imageDrawings[layers[currentLayer].imageDrawings.Count - 1].SetEndPoint(new PointF(e.X, e.Y));

            //sets the draw mode back to mouse
            drawType = DrawingMode.Mouse;
            InvalidateAll();
        }
        #endregion

        #region Brushes
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
                CreateImageDrawing();
            }

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

            widthDemo_pic.Invalidate();
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
                OpenColorpicker();
            }

            //updates the global pen
            UpdateGlobalPen(penColor, penWidth);
            InvalidateAll();
        }
        #endregion

        #region Invalidates
        //updates the user on what drawing mode they are using
        public void InvalidateAll() {
            canvas.Invalidate();
            colorPallet_pic.Invalidate();
            widthDemo_pic.Invalidate();
            options_pic.Invalidate();

        }

        //draws the screen
        private void canvas_Paint(object sender, PaintEventArgs e) {
            //checks to see if the background should be drawn
            if (!transparentBackground)
                e.Graphics.FillRectangle(Brushes.White, 0, 0, canvas.Width, canvas.Height);

            if (background != null)
                background.Draw(e.Graphics);

            foreach (Layer l in layers)
                l.Draw(e);
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
            e.Graphics.DrawImage(Properties.Resources._BackArrow, 0, 0, 40, 40);
            e.Graphics.DrawImage(Properties.Resources._Delete, 50, 0, 40, 40);
        }
        #endregion

        #region Functions
        //lets the user choose an image to add to the drawing
        void CreateImageDrawing() {
            //makes the user open a project
            OpenFileDialog opener = new OpenFileDialog();
            if (opener.ShowDialog() == DialogResult.OK) {

                //makes sure that the right type of file was entered
                if (opener.FileName.ToLower().Contains(".png") || opener.FileName.ToLower().Contains(".jpg")) {

                    //sets up an image with the chosen path
                    layers[currentLayer].imageDrawings.Add(new ImageDrawing(opener.FileName, this));


                    layers[currentLayer].drawOrder.Add(Layer.DrawingMode.Image);

                    drawType = DrawingMode.Image;
                }
            }
        }

        //finds out what save option the user wants
        private void OpenCompression() {
            CompressionWindow c = new CompressionWindow(this);

            c.Show();
        }

        //finds out what window ratio the user wants
        void OpenRatio() {

            ScreenRatioWindow s = new ScreenRatioWindow(this);

            s.Show();

        }

        /// <summary>
        /// Checks to see if the canvas' size needs to be bound to a certain ratio
        /// </summary>
        public void ResizeHandler() {

            //checks to see if the canvas has to be bound to a ratio
            if (ratioBind) {

                WindowState = FormWindowState.Normal;

                //changes the size of the draw area
                if (ratio >= 1)
                    canvas.Height = (int)(canvas.Width * ratio);
                else
                    canvas.Width = (int)(canvas.Height / ratio);
                if (canvas.Width <= canvas.Height)
                    canvas.Height = (int)(canvas.Width / ratio);
                else
                    canvas.Width = (int)(canvas.Height * ratio);

                //makes the size of the window fit the canvas
                Width = canvas.Width + 80;
                Height = canvas.Height + 130;

            } else
                canvas.Size = new Size(Width - 80, Height - 130);


            //sets the saves the size of the canvas
            canvasSizeX = canvas.Width;
            canvasSizeY = canvas.Height;

            InvalidateAll();
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
                Bitmap toSave = new Bitmap(canvas.Width, canvas.Height);

                //uses a graphics library to draw to the file
                using (Graphics g = Graphics.FromImage(toSave)) {

                    //checks to see if the background should be tranparent
                    if (!transparentBackground)

                        g.FillRectangle(Brushes.White, 0, 0, canvas.Width, canvas.Height);

                    if (background != null)
                        background.Draw(g);

                    //goes through and draws the content from each layer
                    foreach (Layer l in layers)
                        l.Export(g);
                }

                //saves the image
                toSave.Save(saver.FileName);
            }
        }

        //saves the data as a project file
        public void SaveProjectAs() {

            SaveFileDialog saver = new SaveFileDialog();

            //makes it so that the user can only save as png
            saver.Filter = "Paint save file: *" + projectExtension + "|" + projectExtension;

            //makes the user choose a file path to save to
            if (saver.ShowDialog() == DialogResult.OK) {

                //opens up the text file
                StreamWriter sw = new StreamWriter(saver.FileName);

                //saves the path of the file
                sw.WriteLine(path);

                //saves the ratio of the project
                sw.WriteLine(ratioBind);
                sw.WriteLine(ratio);

                //saves the amount of layers in the project
                sw.WriteLine(layers.Count);

                //goes to each layer to save it's contents
                foreach (Layer l in layers)
                    l.Save(sw);

                //closes the file
                sw.Close();

                path = saver.FileName;
            }
        }

        /// <summary>
        /// Allows the user to save the project to the same selected path as before
        /// </summary>
        public void SaveProject() {

            //checks to see if a path had previously been used
            if (path != null) {

                //checks to see if the path still exists
                if (File.Exists(path)) {

                    //opens up the text file from the path
                    StreamWriter sw = new StreamWriter(path);

                    //saves the path of the file
                    sw.WriteLine(path);

                    //saves the ratio of the project
                    sw.WriteLine(ratioBind);
                    sw.WriteLine(ratio);

                    //saves the amount of layers in the project
                    sw.WriteLine(layers.Count);

                    //goes to each layer to save it's contents
                    foreach (Layer l in layers)
                        l.Save(sw);

                    //closes the file
                    sw.Close();
                } else {
                    //lets the user know that the path no longer exists
                    MessageBox.Show("The selected path no longer exists, file will save as instead");

                    //lets the user save as instead
                    SaveProjectAs();
                }
            } else {

                //lets the user know that there was no selected path
                MessageBox.Show("There was no selected path, file will save as instead");

                //lets the user save as instead
                SaveProjectAs();
            }
        }

        /// <summary>
        /// Lets the user choose a file to open
        /// </summary>
        public void ChooseFile() {

            //a file explorer to chose a file from
            OpenFileDialog opener = new OpenFileDialog();

            //checks to see what the user clicked on the file explorer
            if (opener.ShowDialog() == DialogResult.OK)

                //loads up the project that was selected
                LoadProject(opener.FileName);

        }

        //loads up a project
        public void LoadProject(string path) {

            //makes sure that the right type of file was entered
            if (path.Contains(projectExtension)) {

                //clears the drawings ready for the new project
                ClearDrawings();
                layers.Clear();

                //opens the file in the program
                StreamReader sr = new StreamReader(path);

                path = sr.ReadLine();

                //gets the ratio information
                if (sr.ReadLine().ToLower() == "true")
                    ratioBind = true;
                else
                    ratioBind = false;

                //gets the ratio of the project
                ratio = Convert.ToSingle(sr.ReadLine());

                //gets the amount of layers there are in the project
                int noOfLayers = Convert.ToInt32(sr.ReadLine());

                for (int i = 0; i < noOfLayers; i++) {
                    layers.Add(new Layer());
                    layers[i].Load(sr);
                }

                //closes the file
                sr.Close();

                //redraws the picture
                canvas.Invalidate();
            } else {

                //lets the user know that the correct file type was not chosen
                MessageBox.Show("Valid file not chosen. Try to choose a file with a .pain extension");
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
                    background = new ImageDrawing(
                        new PointF(0f, 0f),
                        new PointF(canvas.Width, canvas.Height),
                        path,
                        this);
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
            layers.Clear();
            layers.Add(new Layer());
            currentLayer = 0;

            //makes the screen redraw (now as a blank screen)
            canvas.Invalidate();
        }

        //removes the latest drawing from the project
        void UndoDrawing() {

            //makes sure that the project is not empty
            if (layers[currentLayer].drawOrder.Count != 0) {

                //checks to see what the latest input was before removing it
                switch (layers[currentLayer].drawOrder[layers[currentLayer].drawOrder.Count - 1]) {

                    case Layer.DrawingMode.Pen:
                    layers[currentLayer].penDrawings.RemoveAt(layers[currentLayer].penDrawings.Count - 1);
                    break;

                    case Layer.DrawingMode.Square:
                    layers[currentLayer].squareDrawings.RemoveAt(layers[currentLayer].squareDrawings.Count - 1);
                    break;

                    case Layer.DrawingMode.Circle:
                    layers[currentLayer].circleDrawings.RemoveAt(layers[currentLayer].circleDrawings.Count - 1);
                    break;

                    case Layer.DrawingMode.Line:
                    layers[currentLayer].lineDrawings.RemoveAt(layers[currentLayer].lineDrawings.Count - 1);
                    break;

                    case Layer.DrawingMode.Image:
                    layers[currentLayer].imageDrawings.RemoveAt(layers[currentLayer].imageDrawings.Count - 1);
                    break;

                    default:
                    break;
                }

                layers[currentLayer].drawOrder.RemoveAt(layers[currentLayer].drawOrder.Count - 1);

                canvas.Invalidate();
            }
        }

        void OpenColorpicker() {

            //creates a new color picker window
            ColorPicker cp = new ColorPicker(this);

            //opens the window
            cp.Show();
        }

        //deals with the function buttons
        private void FunctionBtns_pic_MouseClick(object sender, MouseEventArgs e) {
            if (e.X < 40)
                UndoDrawing();
            else if (e.X > 50 && e.X < 90)
                EnsureClearDrawing();
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
                else if (e.KeyCode == Keys.D6)
                    CreateImageDrawing();
                else if (e.KeyCode == Keys.Add)
                    IncreasePenWidth();
                else if (e.KeyCode == Keys.Oemplus)
                    IncreasePenWidth();
                else if (e.KeyCode == Keys.Subtract)
                    DecreasePenWidth();
                else if (e.KeyCode == Keys.OemMinus)
                    DecreasePenWidth();
                else if (e.KeyCode == Keys.Z) {
                    if (ModifierKeys == Keys.Control)
                        UndoDrawing();
                } else if (e.KeyCode == Keys.S) {

                    //checks to see if both control and shift was pressed
                    if (e.Modifiers == (Keys.Control | Keys.Shift))

                        SaveProjectAs();

                    //checks to see if only control was pressed
                    else if (e.Modifiers == Keys.Control)

                        SaveProject();
                }
            }

            options_pic.Invalidate();
            InvalidateAll();
        }
        #endregion

        #region Toolbar Clicks
        private void ExportImageToolStripMenuItem_Click(object sender, EventArgs e) {
            ExportImage();
        }

        private void saveProjectToolStripMenuItem_Click(object sender, EventArgs e) {
            SaveProject();
        }

        private void SaveProjectAsToolStripMenuItem_Click(object sender, EventArgs e) {
            SaveProjectAs();
        }

        private void LoadProjectToolStripMenuItem_Click(object sender, EventArgs e) {
            ChooseFile();
        }

        private void changeBackgroundImageToolStripMenuItem_Click(object sender, EventArgs e) {
            ChangeBackground();
        }

        private void removeBackgroundImageToolStripMenuItem_Click(object sender, EventArgs e) {
            RemoveBackground();
        }

        private void compresssionToolStripMenuItem_Click(object sender, EventArgs e) {
            OpenCompression();
        }

        private void windowRatioToolStripMenuItem_Click(object sender, EventArgs e) {
            OpenRatio();
        }

        private void layersToolStripMenuItem_Click(object sender, EventArgs e) {
            LayerControlWindow l = new LayerControlWindow(this);

            l.Show();
        }

        private void EditBrushSizeToolStripMenuItem_Click(object sender, EventArgs e) {

            //sets up a brush size window
            BrushSize bs = new BrushSize(this);

            //shows the window
            bs.Show();
        }

        private void EditBrushColoursToolStripMenuItem_Click(object sender, EventArgs e) {
            OpenColorpicker();
        }

        private void toggleTransparentBackgroundToolStripMenuItem_Click(object sender, EventArgs e) {
            transparentBackground = !transparentBackground;
        }
        #endregion


    }
}
