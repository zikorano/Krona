using System;
using Krona;

class Program
{
    public static void Main()
    {
        var v = Vector2f.UP;
        Console.WriteLine(v);
        Console.WriteLine(v.Rotated(KMath.DegToRad(-90f)));
    }
}