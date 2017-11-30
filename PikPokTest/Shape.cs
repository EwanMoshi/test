using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PikPokTest {

    /* The animation type */
    public enum MovementType {
        Vertical,
        Horizontal,
        Box,
        Circular
    }

    public abstract class Shape {

        /* Shape properties*/
        protected Color color;
        public MovementType movement;
        public FVector2 position;
        public FVector2 originalStart;

        /**
        * Draws the shape on screen. Invalidate() should be called after
        * drawing, to update.
        */
        public abstract void draw(Graphics g);

        /**
        * Sets the movement type for this shape.
        */
        public abstract void setMovementType(MovementType moveType);

        /**
        * Resets the position of the shape to its starting position.
        */
        public void resetPosition() {
            position.X = originalStart.X;
            position.Y = originalStart.Y;
        }

        /**
        * Updates the color for the shape. Invalidate() should be called after
        * this function, to update.
        */
        public void updateColor(string color) {
            this.color = Color.FromName(color);
        }
    }
}
