using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PikPokTest {
    public partial class PikPokTest : Form {

        private Shape currentShape;
        private ShapeParser parser;

        public PikPokTest() {
            InitializeComponent();

            parser = new ShapeParser();

            this.setFrameRate((int) frameRateControl.Value);

            this.DoubleBuffered = true;
            this.MovementTimer.Enabled = false;
        }

        /**
        * Opens a FileDialog to allow users to load a shape file.
        * The loaded file is parsed depending on what type of shape it is.
        * Sets the currentShape to whatever shape was loaded.
        */
        private void Load_Click(object sender, EventArgs e) {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Load shape file";
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                string fileName = openFileDialog.FileName;
                TextReader reader = File.OpenText(fileName);

                string shapeType = reader.ReadLine();
                switch (shapeType) {
                    case "circle":
                        currentShape = parser.parseCircle(reader);
                        Invalidate();
                        break;
                    default:
                        currentShape = parser.parsePolygon(reader);
                        Invalidate();
                        break;
                }

                if (currentShape != null) {
                    animationComboBox.Text = currentShape.movement.ToString();
                }
            }
        }

        private void PikPokTest_Paint(object sender, PaintEventArgs e) {
            if (this.currentShape != null) {
                this.currentShape.draw(e.Graphics);
            }
        }

        private void MovementTimer_Tick(object sender, EventArgs e) {
            TweenManager.Instance.Tick();

            Invalidate();
        }

        /**
        * Sets the framerate for the MovementTimer
        */
        private void setFrameRate(int framerate) {
            MovementTimer.Interval = 1000 / framerate;
        }

        /**
         * Handle shape animation
         */
        private void Animate_Click(object sender, EventArgs e) {
            if (this.currentShape != null) {
                this.MovementTimer.Enabled = true;
                TweenManager.Instance.StartAnimation(currentShape, currentShape.movement);

            }
        }

        public float getCurrentTime() {
            return ((float)DateTime.Now.Hour + ((float)DateTime.Now.Minute * 0.01f));
        }

        private void PikPokTest_Load(object sender, EventArgs e) {

        }

        private void frameRateControl_ValueChanged(object sender, EventArgs e) {
            this.setFrameRate((int) frameRateControl.Value);
        }

        /**
        * If the current shape is not null (i.e we've loaded one), allow the user
        * to change the animation type at run time, using the drop down menu.
        */
        private void animationComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            if (currentShape != null) {
                if (animationComboBox.Text.Equals("Vertical")) {
                    currentShape.setMovementType(MovementType.Vertical);
                }
                else if (animationComboBox.Text.Equals("Horizontal")) {
                    currentShape.setMovementType(MovementType.Horizontal);

                }
                else if (animationComboBox.Text.Equals("Box")) {
                    currentShape.setMovementType(MovementType.Box);

                }
                else if (animationComboBox.Text.Equals("Circular")) {
                    currentShape.setMovementType(MovementType.Circular);
                }
            }
        }

        /**
        * Opens the color dialog which allows users to change the colour of the shape
        */
        private void colorButton_Click(object sender, EventArgs e) {
            if (colorDialog.ShowDialog() == DialogResult.OK) {
                if (currentShape != null) {
                    currentShape.updateColor(colorDialog.Color.Name);
                    Invalidate();
                }
            }
        }
    }
}
