using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PikPokTest {
    class ShapeParser {
        private ShapeFactory factory;

        public ShapeParser() {
            this.factory = new ShapeFactory();
        }

        public Polygon parsePolygon(TextReader reader) {
            // read the position of the shape
            string posLine = reader.ReadLine();
            string[] individualPosition = posLine.Split(' ');

            // convert the position line into 2 points and create a FVector2 from them
            float posX = float.Parse(individualPosition[0]);
            float posY = float.Parse(individualPosition[1]);
            FVector2 position = new FVector2(posX, posY);

            // read the points of the polygon
            string points = reader.ReadLine();
            string[] individualPoints = points.Split(' ');

            List<FVector2> tempList = new List<FVector2>();

            // iterate over the individual points and add them to the tempPoints list
            for (int i = 0; i < individualPoints.Length - 1; i += 2) {

                float pointX = float.Parse(individualPoints[i]);
                float pointY = float.Parse(individualPoints[i + 1]);

                FVector2 p = new FVector2(pointX, pointY);
                tempList.Add(p);
            }

            FVector2[] tempPoints = new FVector2[tempList.Count];

            // iterate over templist and add to the tempPoints array
            for (int i = 0; i < tempList.Count(); i++) {
                tempPoints[i] = tempList.ElementAt(i);
            }

            // read the color and movement type of the polygon
            Color color = Color.FromName(reader.ReadLine());
            string movementType = reader.ReadLine();

            // create a polygon
            return factory.createPolygon(position, tempPoints, color, movementType);
        }

        /**
        * Parse a circle
        */
        public Circle parseCircle(TextReader reader) {
            // read the position of the shape
            string posLine = reader.ReadLine();
            string[] individualPosition = posLine.Split(' ');

            // convert the line into 2 points and create a FVector2 from them
            float posX = float.Parse(individualPosition[0]);
            float posY = float.Parse(individualPosition[1]);
            FVector2 position = new FVector2(posX, posY);

            // read the dimensions line
            string dimensions = reader.ReadLine();
            string[] individualDimensions = posLine.Split(' ');

            // extract the width and height form the dimensions line
            int width = int.Parse(individualPosition[0]);
            int height = int.Parse(individualPosition[1]);

            // read the color and movement type of the circle
            Color color = Color.FromName(reader.ReadLine());
            string movementType = reader.ReadLine();

            // create circle
            return factory.createCircle(width, height, position, color, movementType);
        }
    }
}
