using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotoMarket {
    class PenDrawing {
        List<PenCoords> coordsList = new List<PenCoords>();
        Pen pen;

        //constructor
        public PenDrawing(Pen color) {
            pen = color;
        }

        //shows the drawing
        public void showDrawings(PaintEventArgs g) {

            //loops through all of the points
            for (int i = 0; i < coordsList.Count() - 1; i++) {

                //draws out a line between each of the coordinates in the list
                g.Graphics.DrawLine(
                    pen,
                    coordsList[i].coords.X,
                    coordsList[i].coords.Y,
                    coordsList[i + 1].coords.X,
                    coordsList[i + 1].coords.Y);
            }
        }
        
        //draws out the drawing to the bitmap
        public void exportDrawings(Graphics g) {

            //loops through all of the points
            for (int i = 0; i < coordsList.Count() - 1; i++) {

                //draws out a line between each of the coordinates in the list
                g.DrawLine(
                    pen,
                    coordsList[i].coords.X,
                    coordsList[i].coords.Y,
                    coordsList[i + 1].coords.X,
                    coordsList[i + 1].coords.Y);
            }
        }

        //adds a new item to the list of coordinates
        public void addNewCoordinate(Point newCoords) {
            coordsList.Add(new PenCoords(newCoords));
        }
       
    }

    class PenCoords {
        public Point coords;

        //takes and stores coordinates
        public PenCoords(Point _coords) {
            coords = _coords;
        }
    }
}
