using System;

namespace Krona;

public struct Vector2f : IComparable<Vector2f>
{
    public float x, y;

    /* -----------------> Constants <----------------- */
    public static readonly Vector2f ZERO  = new (0,   0);
    public static readonly Vector2f LEFT  = new (-1,  0);
    public static readonly Vector2f RIGHT = new (1,   0);
    public static readonly Vector2f UP    = new (0,   1);
    public static readonly Vector2f DOWN  = new (0,  -1);
    
    public float Length => MathF.Sqrt (x * x + y * y);

    public float LengthSquared => x * x + y * y;
    
    public Vector2f() { x = 0f; y = 0f; }

    public Vector2f(float x) { this.x = x; this.y = x; }

    public Vector2f(float x, float y) { this.x = x; this.y = y; }

    public Vector2f Abs()
    {
        return new(Math.Abs(x), Math.Abs(y));
    }

    public float Angle() => MathF.Atan2(x, y);

    public float AngleTo(Vector2f to)
    {
        return MathF.Atan2(Cross(to), Dot(to));
    }

    public float AngleToPoint(Vector2f to)
    {
        return MathF.Acos (this.Dot (to));
    }

    public float Aspect()
    {
        return x / y;
    }

    public Vector2f Bounce(Vector2f n)
    {
        return -1f * Reflect(n);
    }

    public Vector2f Ceil()
    {
        return new(MathF.Ceiling(x), MathF.Ceiling(y));
    }

    public Vector2f Clamp(Vector2f min, Vector2f max)
    {
        return new (
			(float) UMath.Clamp(x, min.x, max.x),
            (float) UMath.Clamp(y, min.y, max.y));
    }

    public float Cross(Vector2f with)
    {
        return x * with.y - y * with.x;
    }

    public Vector2f DirectionTo(Vector2f b)
    {
        return new Vector2f(b.x - x, b.y - y).Normalized();
    }

    public float DistanceSquaredTo(Vector2f to)
    {
        return (x - to.x) * (x - to.x) + (y - to.y) * (y - to.y);
    }

    public float DistanceTo(Vector2f to)
    {
        return MathF.Sqrt ((x - to.x) * (x - to.x) + (y - to.y) * (y - to.y));
    }

    public float Dot(Vector2f with)
    {
        return x * with.x + y * with.y;
    }

    public Vector2f Floor()
    {
        return new Vector2f(MathF.Floor(x), MathF.Floor(y));
    }

    public bool IsNormalized()
    {
        return false;
        // use length_squared() instead of length() to avoid sqrt(), makes it more stringent.
	    // return MathF.IsEqualApprox(length_squared(), 1, (real_t)MathF.);
    }

    public Vector2f LimitLength( float length=1.0f)
    {
        return Vector2f.ZERO;
    }

    public Vector2f Lerp(Vector2f to, float weight)
    {
        return Vector2f.ZERO;
    }

    public Vector2f Normalized()
    {
        return new (x / Length, y / Length);
    }

    public Vector2f Project(Vector2f b)
    {
        return Vector2f.ZERO;
    }

    public Vector2f Reflect(Vector2f n)
    {
        return 2.0f * n * Dot(n) - this;
    }

    public Vector2f Rotated( float angle)
    {
        return Vector2f.ZERO;
    }

    public Vector2f Round()
    {
        return Vector2f.ZERO;
    }

    public Vector2f Sign()
    {
        return Vector2f.ZERO;
    }

    public Vector2f Slerp(Vector2f to, float weight)
    {
        return Vector2f.ZERO;
    }

    public Vector2f Tangent()
    {
        return Vector2f.ZERO;
    }

    public static Vector2f operator + (Vector2f lhs, Vector2f rhs) 
        => new Vector2f(lhs.x + rhs.x, lhs.y + rhs.y);

    public static Vector2f operator - (Vector2f lhs, Vector2f rhs)
        => new Vector2f(lhs.x - rhs.x, lhs.y - rhs.y);

    public static Vector2f operator * (Vector2f lhs, Vector2f rhs)
        => new Vector2f(lhs.x * rhs.x, lhs.y * rhs.y);

    public static Vector2f operator * (float lhs, Vector2f rhs)
        => new Vector2f(rhs.x * lhs, rhs.y * lhs);

    public static Vector2f operator * (Vector2f lhs, float rhs)
        => new Vector2f(lhs.x * rhs, lhs.y * rhs);

    public static Vector2f operator / (Vector2f lhs, Vector2f rhs)
        => new Vector2f(lhs.x / rhs.x, lhs.y / rhs.y);

    public static Vector2f operator / (Vector2f lhs, float rhs)
        => new Vector2f(lhs.x / rhs, lhs.y / rhs);

    public static bool operator == (Vector2f lhs, Vector2f rhs)
        => lhs.x == rhs.x && lhs.y == rhs.y;

    public static bool operator != (Vector2f lhs, Vector2f rhs)
        => !(lhs.x == rhs.x && lhs.y == rhs.y);

    public static bool operator <  (Vector2f lhs, Vector2f rhs) => lhs.x == rhs.x ? (lhs.y <  rhs.y) : (lhs.x < rhs.x);
    public static bool operator >  (Vector2f lhs, Vector2f rhs) => lhs.x == rhs.x ? (lhs.y >  rhs.y) : (lhs.x > rhs.x);
    public static bool operator <= (Vector2f lhs, Vector2f rhs) => lhs.x == rhs.x ? (lhs.y <= rhs.y) : (lhs.x < rhs.x);
    public static bool operator >= (Vector2f lhs, Vector2f rhs) => lhs.x == rhs.x ? (lhs.y >= rhs.y) : (lhs.x > rhs.x);

    public override bool Equals(object obj) => base.Equals(obj);

    public override int GetHashCode() => base.GetHashCode();

    public int CompareTo(Vector2f v)
    {
        if (v > this) return 1; else return v < this ? -1 : 0;
    }

    public override string ToString() => $"Vector2f({this.x}, {this.y})";
}
