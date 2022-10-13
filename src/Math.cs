namespace Krona;

public static class KMath
{
    public static double Clamp(double val, double min, double max)
    {
        if (val > max) return max; else return val < min ? min : val;
    }
}
