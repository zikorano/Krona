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
			KMath.Clamp(x, min.x, max.x),
            KMath.Clamp(y, min.y, max.y));
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
	    return KMath.IsEqualApprox(LengthSquared, 1);
    }

    public Vector2f LimitLength(float length=1.0f)
    {
        var l = Length;
        Vector2f v = this;
        if (l > 0 && length < l) {
            v /= l;
            v *= length;
        }
        return v;
    }

    public Vector2f Lerp(Vector2f to, float weight)
    {
        Vector2f res = this;
        res.x += (weight * (to.x - x));
        res.y += (weight * (to.y - y));
        return res;
    }

    public Vector2f Normalized()
    {
        return new (x / Length, y / Length);
    }

    public Vector2f Project(Vector2f b)
    {
        return b * (Dot(b) / b.LengthSquared);
    }

    public Vector2f Reflect(Vector2f n)
    {
        return 2.0f * n * Dot(n) - this;
    }

    public Vector2f Rotated(float angle)
    {
        float sina = MathF.Sin(angle);
        float cosa = MathF.Cos(angle);
        return new Vector2f(
                x * cosa - y * sina,
                x * sina + y * cosa);
    }

    public Vector2f Round()
    {
        return new Vector2f (
            MathF.Round(x),
            MathF.Round(y));
    }

    public Vector2f Sign()
    {
        return new Vector2f (
            MathF.Sign(x),
            MathF.Sign(y));
    }

    public Vector2f Slerp(Vector2f to, float weight)
    {
        float startLengthSq = LengthSquared;
        float endLengthSq = to.LengthSquared;
        /*
        TODO: Replicate "unlikely" function from Godot source
        if (unlikely(startLengthSq == 0.0f || endLengthSq == 0.0f)) {
            ...
        */
        if (startLengthSq == 0.0f || endLengthSq == 0.0f) {
            // Zero length vectors have no angle, so the best we can do is either lerp or throw an error.
            return Lerp(to, weight);
        }
        float startLength  = MathF.Sqrt(startLengthSq);
        float resultLength = KMath.Lerp(startLength, MathF.Sqrt(endLengthSq), weight);

        float angle = AngleTo(to);
        return Rotated(angle * weight) * (resultLength / startLength);
    }

    public Vector2f Tangent()
    {
        return this.Rotated(KMath.DegToRad(-90f));
    }

    public static Vector2f operator + (Vector2f lhs, Vector2f rhs) => new (lhs.x + rhs.x, lhs.y + rhs.y);
    public static Vector2f operator - (Vector2f lhs, Vector2f rhs) => new (lhs.x - rhs.x, lhs.y - rhs.y);

    public static Vector2f operator * (Vector2f lhs, Vector2f rhs) => new (lhs.x * rhs.x, lhs.y * rhs.y);
    public static Vector2f operator * (float lhs, Vector2f rhs) => new (rhs.x * lhs, rhs.y * lhs);
    public static Vector2f operator * (Vector2f lhs, float rhs) => new (lhs.x * rhs, lhs.y * rhs);

    public static Vector2f operator / (Vector2f lhs, Vector2f rhs) => new (lhs.x / rhs.x, lhs.y / rhs.y);
    public static Vector2f operator / (Vector2f lhs, float rhs) => new (lhs.x / rhs, lhs.y / rhs);
    public static bool operator == (Vector2f lhs, Vector2f rhs) => lhs.x == rhs.x && lhs.y == rhs.y;
    public static bool operator != (Vector2f lhs, Vector2f rhs) => !(lhs.x == rhs.x && lhs.y == rhs.y);

    public static bool operator <  (Vector2f lhs, Vector2f rhs) => lhs.x == rhs.x ? (lhs.y <  rhs.y) : (lhs.x < rhs.x);
    public static bool operator >  (Vector2f lhs, Vector2f rhs) => lhs.x == rhs.x ? (lhs.y >  rhs.y) : (lhs.x > rhs.x);
    public static bool operator <= (Vector2f lhs, Vector2f rhs) => lhs.x == rhs.x ? (lhs.y <= rhs.y) : (lhs.x < rhs.x);
    public static bool operator >= (Vector2f lhs, Vector2f rhs) => lhs.x == rhs.x ? (lhs.y >= rhs.y) : (lhs.x > rhs.x);

    public override bool Equals(object obj) => base.Equals(obj);

    public override int GetHashCode() => base.GetHashCode();

    public int CompareTo(Vector2f v)
    {
        return v > this ? 1 : (v < this ? -1 : 0);
    }

    public override string ToString() => $"Vector2f({this.x}, {this.y})";
}
