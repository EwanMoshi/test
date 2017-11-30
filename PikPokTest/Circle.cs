using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PikPokTest {
    class Circle : Shape {

        private int width;
        private int height;

        public Circle(int width, int height, FVector2 pos, Color color) {
            this.width = width;
            this.height = height;
            this.color = color;
            this.position = pos;
            this.originalStart = pos; // store the original position
        }

        /**
        * Draws the shape on screen.
        * 
        * @param g - The Graphics object used to draw
        */
        public override void draw(Graphics g) {
            SolidBrush brush = new SolidBrush(color); // create the brush based on the current color

            Pen pen = new Pen(brush); // create the pen
            pen.Width = 2;

            g.DrawEllipse(pen, new Rectangle(new Point((int)position.X, (int)position.Y), new Size(width, height)));
        }

        /**
        * Sets the movement type for this circle.
        * 
        * @param - moveType - the new MovementType
        */
        public override void setMovementType(MovementType moveType) {
            this.movement = moveType;
        }
    }
}
