=========================
== Running the Program ==
=========================

launch setup.exe

1. Click load, choose a shape from the ShapeFiles folder
2. Click animate to aniamte


You can adjust framerate of animation, movement/animation type, and color
using the UI elements.


======================
== Design Decisions ==
======================

Form1
______
The form has a shape parser which is used to parse shapes from the files.
All the UI stuff is here (handling button clicks, etc.)


TweenManager
_____________
TweenManager is a singleton since we only want one manager to exist
and it operates on 1 shape at a time. This has its own tick function which is called
from the form's tick function. This class is responsible for handling animation and it
knows when and how to animate.

There are two types of tween here, ones that are linear (arbitrary points) and circular.
The linear tween is used for horizontal, vertical, and box because they are essentially
a list of waypoints that the shape needs to move to (similar to ai moving to waypoints).
Circular is a bit different obviously so that one needed its own function becuase we're
dealing with angles, and so on.


Shape/Polygon/Circle
_______
The shape abstract class provides some common functionality for all shapes
such as colr, positions, update/reset functions etc. but also ensures 
derived classes create their own definitions for functions such as draw.



ShapeParser
________________
The parser uses a shape factory to create the shapes because
it doesn't care about how these shapes are created. It just 
parses the information and hands it all to the factory.

Shape parser could probably be a singleton too because we only
want one instance of it to exist.


============================
== Alternative Approaches ==
============================

I could have also used a strategy for the movement and handed the responsibility for
animating to the shape classes where each shape would have a movement strategy
that would define how the shape would move. However, I chose to use the TweenManager
for the sake of brevity.

I could have created multiple subclasses for square, hexagon, or triangle
but this would convolute the program and is unnecessary because they can all be treated
as a polygon since they behave in the same way.
Circles/Ellipses are the only ones that needed their own class becuase they can't be drawn the same
as polygons.

The predefined points for animation could also be improved. I've basically hardcoded the values
for simplicity but I acknowledge that it's not amazing. I could let the user control how far
each shape moves through the UI or load the values with the text file, etc. 