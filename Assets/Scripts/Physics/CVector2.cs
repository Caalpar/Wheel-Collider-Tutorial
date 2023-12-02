using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CVector2 
{
    private float x;
    private float y;
    const float epsilon = 0.001f;

    public float X { set { x = value; } get { return x; } }
    public float Y { set { y = value; } get { return y ; } }

    public CVector2()
    {
        x = 0;
        y = 0;
    }

    public CVector2(float pX,float pY)
    {
        x = pX;
        y = pY;
    }

    public override string ToString()
    {
        return string.Format("({0},{1})", x, y);
    }

    public static CVector2 operator+(CVector2 v1,CVector2 v2)
    {
        return new CVector2(v1.X + v2.X, v1.Y + v2.Y);
    }

    public static CVector2 operator -(CVector2 v1, CVector2 v2)
    {
        return new CVector2(v1.X - v2.X, v1.Y - v2.Y);
    }

    public static CVector2 operator *(CVector2 v1, CVector2 v2)
    {
        return new CVector2(v1.X * v2.X, v1.Y * v2.Y);
    }

    public static CVector2 operator *(CVector2 v1, float s)
    {
        return new CVector2(v1.X * s, v1.Y * s);
    }

    public static CVector2 operator *( float s, CVector2 v1)
    {
        return new CVector2(v1.X * s, v1.Y * s);
    }

    public static bool operator ==(CVector2 v1, CVector2 v2)
    {
        if (Mathf.Abs(v1.X - v2.X) <= epsilon && Mathf.Abs(v1.Y - v2.Y) <= epsilon)
            return true;
        return false;
    }

    public static bool operator !=(CVector2 v1, CVector2 v2)
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

    public static float  Punto(CVector2 v1, CVector2 v2)
    {
        return v1.X * v2.X + v1.Y * v2.Y;
    }

    public static float Magnitud(CVector2 v1)
    {
        return Mathf.Sqrt(MagnitudC(v1));
    }

    public static float MagnitudC(CVector2 v1)
    {
        return v1.X * v1.X + v1.Y * v1.Y;
    }

    public void Normalizar()
    {
        float m = Mathf.Sqrt(x * x + y * y);
        x /= m;
        y /= m;
    }
    public static CVector2 Normalizar(CVector2 v1)
    {
        float m = CVector2.Magnitud(v1);
        return new CVector2(v1.X / m, v1.Y / m);
    }


    public static float Angulo(CVector2 v1, CVector2 v2)
    {
        float m1 = CVector2.Magnitud(v1);
        float m2 = CVector2.Magnitud(v2);

        return Mathf.Acos(CVector2.Punto(v1, v2) / (m1 * m2));
    }


    public static CVector2 Proyectar(CVector2 v1, CVector2 v2)
    {
        float punto = CVector2.Punto(v1, v2);
        float mc = CVector2.MagnitudC(v2);

        return v2 * (punto / mc); 
    }

    public static CVector2 Perpendicular(CVector2 v1, CVector2 v2)
    {
        return v1 - CVector2.Proyectar(v1, v2);
    }

    public static CVector2 Refleccion(CVector2 v1, CVector2 normal)
    {
        float d = CVector2.Punto(v1, normal);
        return v1 - normal * (d * 2f);
    }
}
