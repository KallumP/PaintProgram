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
    public partial class LayerControlWindow : Form {

        MainWindow parent;

        int selected = -1;

        public LayerControlWindow(MainWindow _parent) {
            InitializeComponent();
            parent = _parent;
            UpdateListBox();
        }

        /// <summary>
        /// Moves the selected layer up in the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void layerUp_btn_Click(object sender, EventArgs e) {

            //a temporary layer used when swapping two layers
            Layer temp;

            //makes sure that a layer was selected
            if (selected != -1) {

                //makes sure that the chosen layer isnt the first layer in the list
                if (selected > 0) {

                    //swaps the chosen layer with the one on top
                    temp = parent.layers[selected - 1];
                    parent.layers[selected - 1] = parent.layers[selected];
                    parent.layers[selected] = temp;

                    //updates the selected variable to match the reordered list
                    selected--;

                    UpdateListBox();
                    parent.InvalidateAll();
                }
            }
        }

        /// <summary>
        /// Moves the selected layer down in the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void layerDown_btn_Click(object sender, EventArgs e) {

            //a temporary layer used when swapping two layers
            Layer temp;

            //makes sure that a layer was selected
            if (selected != -1) {

                //make sure that the chosen layer isnt the last layer in the list
                if (selected < parent.layers.Count - 1) {

                    //swaps the chosen layer with the one below
                    temp = parent.layers[selected + 1];
                    parent.layers[selected + 1] = parent.layers[selected];
                    parent.layers[selected] = temp;

                    //updates the selected variable to match the reordered list
                    selected++;

                    UpdateListBox();
                    parent.InvalidateAll();
                }
            }
        }

        /// <summary>
        /// Adds a new layer 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newLayer_btn_Click(object sender, EventArgs e) {
            parent.layers.Add(new Layer());
            UpdateListBox();
        }

        /// <summary>
        /// Updates the list box to show the layers within the program
        /// </summary>
        public void UpdateListBox() {

            //removes all previous layers from the list box
            layersList.Items.Clear();

            //adds each layer into the list box
            foreach (Layer l in parent.layers)
                layersList.Items.Add(l.name);

            //highlights the last selected layers
            layersList.SelectedIndex = selected;

            //lets the user know what layer is being drawn to 
            currentlyDrawingTo_lbl.Text = "Drawing To: \n" + parent.layers[parent.currentLayer].name;

        }

        //opens up a window to rename the layer
        private void renameLayer_btn_Click(object sender, EventArgs e) {

            //checks to see if a layer was clicked on first before trying to rename it
            if (selected != -1) {
                LayerRename l = new LayerRename(parent, this, selected);
                l.Show();
            } else
                MessageBox.Show("Please select a layer to rename first");


        }

        //selects the layer to be drawn to
        private void selectLayer_Click(object sender, EventArgs e) {

            //checks to see if a layer was clicked on before trying to select it
            if (layersList.SelectedIndex != -1) {
                parent.currentLayer = layersList.SelectedIndex;
                Close();
            } else
                MessageBox.Show("Please click on a layer to select first");


        }

        //deletes the selected layer
        private void deleteLayer_btn_Click(object sender, EventArgs e) {

            //makes sure that a layer was selected
            if (selected != -1) {

                //makes sure that the final layer isnt being removed
                if (parent.layers.Count > 1) {

                    //removes the selected layer
                    parent.layers.RemoveAt(selected);

                    //deselects after deleting something
                    selected = -1;

                    UpdateListBox();

                } else
                    MessageBox.Show("You can't remove the final layer (or you won't have anything to draw on)");

            } else
                MessageBox.Show("Please click on a layer to select first");
        }

        //keeps track of what layer was clicked on
        private void layersList_SelectedIndexChanged(object sender, EventArgs e) {
            selected = layersList.SelectedIndex;
        }
    }

    /*
     * make the layers list backwards, and then fix the move up and down to match what happens on screen
     * comment about how the layers work on screen vs in code
     * 
     * 
     * saving and loading
     * 
     * do project extention work
     * 
     * make clear drawings reset everything in the mainwindow including things like ratio bind
     */
}
