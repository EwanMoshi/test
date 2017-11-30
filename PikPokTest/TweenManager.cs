using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PikPokTest {
    public sealed class TweenManager {

        private static TweenManager instance = null;

        /* Tween Timers */
        public Boolean tweening { get; set; }
        private Stopwatch lerpTimer;
        private float lastTimeChecked;
        private float lerpI;
        private float deltaTime;

        /* Circular tweens */
        private float angle;
        private float speed;
        private float radius = 30.0f; // radius of the circle (used for circular tweens)

        /* Current shape */
        private Shape shape;
        private MovementType movement;

        /* The points used for our tweens */
        public FVector2 origin { get; set; }
        public List<FVector2> targetPoints { get; set; }
        private int currentTargetPoint;

        private TweenManager() {
            this.tweening = false;
            this.lerpTimer = new Stopwatch();
            this.lerpI = 0.0f;
            this.targetPoints = new List<FVector2>();
            this.currentTargetPoint = 0;
        }

        /**
        * A public function used for retrieving an instance of TweenManager.
        * If the Instance hasn't been created, create one and return it.
        */  
        public static TweenManager Instance {
            get {
                if (instance == null) {
                    instance = new TweenManager();
                }
                return instance;

            }
        }
        
        /**
         * Called every frame
         */
        public void Tick() {
            if (!tweening) return;

            deltaTime = lerpTimer.ElapsedMilliseconds - lastTimeChecked;
            lastTimeChecked = lerpTimer.ElapsedMilliseconds;

            if (movement == MovementType.Circular) {
                CircularTween();
            }
            else {
                LinearTween();
            }
        }

        /**
        * Linear tweens make up all kinds of tweens that are not circular.
        * The function will go through a list of targetpoints (waypoints)
        * using this.currentTargetPoint to keep track of the current waypoint.
        * Once all targets/waypoints have been reached, the animation is complete.
        */
        public void LinearTween() {
            // if we've reached all our targets, stop the animation
            if (currentTargetPoint == targetPoints.Count()) {
                reset();
                return;
            }

            float rate = 1.0f / 1000.0f;
           
            lerpI += deltaTime * rate;

            // if we haven't reached the end, keep lerping
            if (lerpI < 1.0f) {
                shape.position = FVector2.Lerp(origin, targetPoints.ElementAt(currentTargetPoint), lerpI);
            }
            else {
                origin = targetPoints.ElementAt(currentTargetPoint); // set the origin to the current location
                currentTargetPoint++; // move to the next point
                lerpI = 0.0f;
            }
        }

        /**
        * Moves the current shape in a circular motion
        */
        public void CircularTween() {


            angle += speed * deltaTime;
            Console.WriteLine(angle);
            shape.position.X = (float) Math.Cos(angle) * radius + shape.originalStart.X;
            shape.position.Y = (float) Math.Sin(angle) * radius + shape.originalStart.Y;

        }

        /**
        * Initializes the shape and movement. If the movement type is
        * linear, it sets up  the way points for that "animation". If circular,
        * the speed and angle for the movement are initialized.
        * 
        * Call this function when you want to start the animation on an object.
        */
        public void StartAnimation(Shape shape, MovementType movement) {
            this.shape = shape;
            this.movement = movement;
            shape.resetPosition();

            if (movement == MovementType.Circular) {
                angle = 0.0f;
                speed = (float) (2.0f * Math.PI) / 1000.0f;
            }
            else {
                setupPoints();
            }

            origin = shape.originalStart;
            tweening = true;
            lerpTimer.Start();
            lastTimeChecked = lerpTimer.ElapsedMilliseconds;
        }

        /**
        * Sets up waypoints for the linear animation types. Each linear animation
        * type has a predefined set of points.
        */
        private void setupPoints() {
            targetPoints.Clear();

            if (movement == MovementType.Horizontal) {
                targetPoints.Add(new FVector2(shape.position.X + 300, shape.position.Y));
                targetPoints.Add(new FVector2(shape.position.X, shape.position.Y));
            }
            else if (movement == MovementType.Vertical) {
                targetPoints.Add(new FVector2(shape.position.X, shape.position.Y + 300));
                targetPoints.Add(new FVector2(shape.position.X, shape.position.Y));
            }
            else if (movement == MovementType.Box) {
                targetPoints.Add(new FVector2(shape.position.X + 300, shape.position.Y));
                targetPoints.Add(new FVector2(shape.position.X + 300, shape.position.Y + 300));
                targetPoints.Add(new FVector2(shape.position.X, shape.position.Y + 300));
                targetPoints.Add(new FVector2(shape.position.X, shape.position.Y));
            }
        }

        /**
        * Reset the values so we can begin animating again
        */
        private void reset() {
            tweening = false;
            lerpTimer.Stop();
            lerpTimer.Reset();
            lerpI = 0.0f;
            currentTargetPoint = 0;
            angle = 0.0f;
            targetPoints.Clear();
        }
    }
}
