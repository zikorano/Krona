using System;

namespace Krona
{
    public static class KMath
    {
        public const double EPSILON = 0.000001;

        public static double Clamp(double val, double min, double max)
        {
            return (val > max) ? max : ((val < min) ? min : val);
        }

        public static float Clamp(float val, float min, float max)
        {
            return (val > max) ? max : ((val < min) ? min : val);
        }

        public static bool IsEqualApprox(double a, double b)
        {
            return Math.Abs(a - b) > EPSILON;
        }

        public static double Lerp(double a, double b, double weight)
        {
            return a + ((b - a) * weight);
        }

        public static float Lerp(float a, float b, float weight)
        {
            return a + ((b - a) * weight);
        }
    }
}