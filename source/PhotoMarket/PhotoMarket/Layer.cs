using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoMarket.DrawingClasses;
using System.Windows.Forms;


namespace PhotoMarket {
    class Layer {

        public enum DrawingMode { Mouse, Pen, Square, Circle, Line, Image };

        public List<PenDrawing> penDrawings = new List<PenDrawing>();
        public List<SquareDrawing> squareDrawings = new List<SquareDrawing>();
        public List<CircleDrawing> circleDrawings = new List<CircleDrawing>();
        public List<LineDrawing> lineDrawings = new List<LineDrawing>();
        public List<ImageDrawing> imageDrawings = new List<ImageDrawing>();


        //creates a list of drawing modes to be used to order each drawing
        public List<DrawingMode> drawOrder = new List<DrawingMode>();

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
                        penDrawings[penOrder].Export(e.Graphics);
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
                        lineDrawings[lineOrder].Export(e.Graphics);
                        lineOrder++;

                        //draws the next image drawing
                    } else if (drawOrder[i] == DrawingMode.Image) {
                        imageDrawings[imageOrder].Draw(e.Graphics);
                        imageOrder++;
                    }
                }
            }
        }
    }
}
