using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PhotoMarket {
    public class DeepCopier {
        public Pen tempPen;

        //creates a deep copy of the pen, instead of by reference (lets the change of variable without changing other variables)
        protected void DeepCopy(Pen toClone) {
            tempPen = new Pen(toClone.Color);
            tempPen.Width = 2;

            tempPen.DashPattern = new float[2] { 20, 20 };
        }
    }
}
