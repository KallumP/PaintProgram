using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoMarket.DrawingClasses;
using System.Windows.Forms;
using System.Drawing;


namespace PhotoMarket {
    public class Layer {

        static public int noOfLayers = 0;
        public string name;

        public enum DrawingMode { Mouse, Pen, Square, Circle, Line, Image };

        //creates a list of drawing modes to be used to order each drawing
        public List<DrawingMode> drawOrder = new List<DrawingMode>();

        public List<PenDrawing> penDrawings = new List<PenDrawing>();
        public List<SquareDrawing> squareDrawings = new List<SquareDrawing>();
        public List<CircleDrawing> circleDrawings = new List<CircleDrawing>();
        public List<LineDrawing> lineDrawings = new List<LineDrawing>();
        public List<ImageDrawing> imageDrawings = new List<ImageDrawing>();

        //Constructor
        public Layer() {
            name = "Layer " + noOfLayers++;
        }


        public void Clear() {

            //removes all elements from the list
            penDrawings.Clear();
            squareDrawings.Clear();
            circleDrawings.Clear();
            lineDrawings.Clear();
            imageDrawings.Clear();
            drawOrder.Clear();

        }

        //draws out the layer
        public void Draw(PaintEventArgs e) {

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
                        penDrawings[penOrder].Draw(e.Graphics);
                        penOrder++;

                        //draws the next square drawing
                    } else if (drawOrder[i] == DrawingMode.Square) {
                        squareDrawings[squareOrder].Draw(e.Graphics);
                        squareOrder++;

                        //draws the next circle drawing
                    } else if (drawOrder[i] == DrawingMode.Circle) {
                        circleDrawings[circleOrder].Draw(e.Graphics);
                        circleOrder++;

                        //draws the next line drawing
                    } else if (drawOrder[i] == DrawingMode.Line) {
                        lineDrawings[lineOrder].Draw(e.Graphics);
                        lineOrder++;

                        //draws the next image drawing
                    } else if (drawOrder[i] == DrawingMode.Image) {
                        imageDrawings[imageOrder].Draw(e.Graphics);
                        imageOrder++;
                    }
                }
            }
        }

        //exports the layer to the image
        public void Export(Graphics g) {

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
                        penDrawings[penOrder].Draw(g);
                        penOrder++;

                        //draws the next square drawing                           
                    } else if (drawOrder[i] == DrawingMode.Square) {
                        squareDrawings[squareOrder].Draw(g);
                        squareOrder++;

                        //draws the next circle drawing
                    } else if (drawOrder[i] == DrawingMode.Circle) {
                        circleDrawings[circleOrder].Draw(g);
                        circleOrder++;

                        //draws the next line drawing
                    } else if (drawOrder[i] == DrawingMode.Line) {
                        lineDrawings[lineOrder].Draw(g);
                        lineOrder++;

                        //draws the next image
                    } else if (drawOrder[i] == DrawingMode.Image) {
                        imageDrawings[imageOrder].Draw(g);
                        imageOrder++;
                    }
                }
            }
        }
    }
}
