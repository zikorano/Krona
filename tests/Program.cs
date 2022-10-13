using System;
using Krona;

class Program
{
    public static void Main()
    {
        var val = new Vector2f(5, 6).Normalized();
        Console.WriteLine(val);
        Console.WriteLine(val.Length);
    }
}