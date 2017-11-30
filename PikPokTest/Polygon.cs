using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;

namespace PikPokTest {
    class Polygon : Shape {

        private FVector2[] points;

        public Polygon(FVector2 pos, FVector2[] points, Color color) {
            this.points = points;
            this.color = color;
            this.position = pos;
            this.originalStart = pos; // store the original position
        }
        
        /**
        * Draws the shape on screen.
        * 
        * @param g - the Graphics object used for drawing this polygon
        */
        public override void draw(Graphics g) {
            SolidBrush brush = new SolidBrush(color); // create the brush based on the current color

            Pen pen = new Pen(brush); // create the pen
            pen.Width = 2;

            PointF[] worldPositionPoints = new PointF[points.Length];

            // convert the points from local space to world space
            for (int i = 0; i < points.Count(); i++) {
                worldPositionPoints[i].X = points[i].X + position.X;
                worldPositionPoints[i].Y = points[i].Y + position.Y;
            }

            g.DrawPolygon(pen, worldPositionPoints);
        }

        /**
        * Sets the movement type for this polygon.
        * 
        * @param moveType - the new MovementType
        */
        public override void setMovementType(MovementType moveType) {
            movement = moveType;
        }
    }
}
