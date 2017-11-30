using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PikPokTest {
    class ShapeFactory {

        public Polygon createPolygon(FVector2 position, FVector2[] points, Color color, string movement) {
            Polygon polygon = new Polygon(position, points, color);

            // set up the movement type
            if (movement == "horizontal") {
                polygon.setMovementType(MovementType.Horizontal);
            }
            else if (movement == "vertical") {
                polygon.setMovementType(MovementType.Vertical);
            }
            else if (movement == "box") {
                polygon.setMovementType(MovementType.Box);
            }
            else if (movement == "circular") {
                polygon.setMovementType(MovementType.Circular);
            }

            return polygon;
        }

        public Circle createCircle(int width, int height, FVector2 position, Color color, string movement) {
            Circle circle= new Circle(width, height, position, color);

            // set up the movement type
            if (movement == "horizontal") {
                circle.setMovementType(MovementType.Horizontal);
            }
            else if (movement == "vertical") {
                circle.setMovementType(MovementType.Vertical);
            }
            else if (movement == "box") {
                circle.setMovementType(MovementType.Box);
            }
            else if (movement == "circular") {
                circle.setMovementType(MovementType.Circular);
            }

            return circle;
        }
    }
}
