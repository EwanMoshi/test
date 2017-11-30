using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PikPokTest {

    /* The data type used for 2d points on the screen */
    public struct FVector2 {
        public float X;
        public float Y;

        public FVector2(float x, float y) {
            this.X = x;
            this.Y = y;
        }

        /**
        * Adds another FVector2 to this.
        */
        public void Add(FVector2 other) {
            X += other.X;
            Y += other.Y;
        }

        /**
        * Linear interpolation for 2 FVectors.
        * 
        * @param origin - start point
        * @param target - end point
        * @param amount - weight/interpolation amount
        */
        public static FVector2 Lerp(FVector2 origin, FVector2 target, float amount) {
            FVector2 lerpedV2 = new FVector2();
            lerpedV2.X = target.X * amount + origin.X * (1 - amount);
            lerpedV2.Y = target.Y * amount + origin.Y * (1 - amount);

            return lerpedV2;
        }
    }

    class MathHelper { }
}
