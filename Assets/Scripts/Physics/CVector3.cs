using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CVector3
{
    private float x;
    private float y;
    private float z;
    const float epsilon = 0.001f;

    public float X { set { x = value; } get { return x; } }
    public float Y { set { y = value; } get { return y; } }
    public float Z { set { y = value; } get { return z; } }

    public CVector3()
    {
        x = 0;
        y = 0;
        z = 0;
    }

    public CVector3(float pX, float pY, float pZ)
    {
        x = pX;
        y = pY;
        z = pZ;
    }

    public override string ToString()
    {
        return string.Format("({0},{1},{2})", x, y,z);
    }

    public static CVector3 operator +(CVector3 v1, CVector3 v2)
    {
        return new CVector3(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
    }

    public static CVector3 operator -(CVector3 v1, CVector3 v2)
    {
        return new CVector3(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);
    }

    public static CVector3 operator *(CVector3 v1, CVector3 v2)
    {
        return new CVector3(v1.X * v2.X, v1.Y * v2.Y, v1.Z * v2.Z);
    }

    public static CVector3 operator *(CVector3 v1, float s)
    {
        return new CVector3(v1.X * s, v1.Y * s, v1.Z * s);
    }

    public static CVector3 operator *(float s, CVector3 v1)
    {
        return new CVector3(v1.X * s, v1.Y * s, v1.Z * s);
    }

    public static bool operator ==(CVector3 v1, CVector3 v2)
    {
        if (Mathf.Abs(v1.X - v2.X) <= epsilon && Mathf.Abs(v1.Y - v2.Y) <= epsilon && Mathf.Abs(v1.Z - v2.Z) <= epsilon)
            return true;
        return false;
    }

    public static bool operator !=(CVector3 v1, CVector3 v2)
    {
        return !(v1 == v2);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override bool Equals(object obj)
    {
        return base.Equals(obj);
    }

    public static float Punto(CVector3 v1, CVector3 v2)
    {
        return v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z;
    }

    public static float Magnitud(CVector3 v1)
    {
        return Mathf.Sqrt(MagnitudC(v1));
    }

    public static float MagnitudC(CVector3 v1)
    {
        return v1.X * v1.X + v1.Y * v1.Y + v1.Z * v1.Z;
    }
    public void Normalizar()
    {
        float m = Mathf.Sqrt(x * x + y * y + z * z);
        x /= m;
        y /= m;
        z /= m;
    }
    public static CVector3 Normalizar(CVector3 v1)
    {
        float m = CVector3.Magnitud(v1);
        return new CVector3(v1.X / m, v1.Y / m, v1.Z /m);
    }

    public static float Angulo(CVector3 v1, CVector3 v2)
    {
        float m1 = CVector3.Magnitud(v1);
        float m2 = CVector3.Magnitud(v2);

        return Mathf.Acos(CVector3.Punto(v1, v2) / (m1 * m2));
    }

    public static CVector3 Proyectar(CVector3 v1, CVector3 v2)
    {
        float punto = CVector3.Punto(v1, v2);
        float mc = CVector3.MagnitudC(v2);

        return v2 * (punto / mc);
    }

    public static CVector3 Perpendicular(CVector3 v1, CVector3 v2)
    {
        return v1 - CVector3.Proyectar(v1, v2);
    }

    public static CVector3 Refleccion(CVector3 v1, CVector3 normal)
    {
        float d = CVector3.Punto(v1, normal);
        return v1 - normal * (d * 2f);
    }

    public static CVector3 Cruz(CVector3 v1, CVector3 v2)
    {
        CVector3 vr = new CVector3();

        vr.X = v1.Y * v2.Z - v1.Z * v2.Y;
        vr.Y = v1.Z * v2.X - v1.X * v2.Z;
        vr.Z = v1.X * v2.Y - v1.Y * v2.X;

        return vr;
    }
}


