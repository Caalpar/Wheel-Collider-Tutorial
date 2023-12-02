using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMatriz3X3
{
    public float[,] matriz = new float[3, 3];

    public CMatriz3X3()
    {

        int r = 0;
        int c = 0;

        for (r = 0; r < 3; r++)
        {
            for (c = 0; c < 3; c++)
            {
                matriz[r, c] = 0;
            }
        }
    }

    public CMatriz3X3(float[,] pMatriz)
    {
        matriz = pMatriz;
    }

    public override string ToString()
    {
        int r = 0;
        int c = 0;
        string srt = "";

        for (r = 0; r < 3; r++)
        {
            for (c = 0; c < 3; c++)
            {
                srt += matriz[r, c].ToString() + ",";
            }
            srt += "\r\n";
        }

        return srt;
    }

    public void ColocaMatriz(float[,] pMatriz)
    {
        matriz = pMatriz;
    }

    public static CMatriz3X3 Transpuesta(CMatriz3X3 pMatriz)
    {
        int r = 0;
        int c = 0;
        CMatriz3X3 temp = new CMatriz3X3();
        for (r = 0; r < 3; r++)
        {
            for (c = 0; c < 3; c++)
            {
                temp.matriz[c, r] = pMatriz.matriz[r, c];
            }
        }

        return temp;
    }

    public static CMatriz3X3 operator *(CMatriz3X3 pMatriz, float s)
    {
        int r = 0;
        int c = 0;
        CMatriz3X3 temp = new CMatriz3X3();
        for (r = 0; r < 3; r++)
        {
            for (c = 0; c < 3; c++)
            {
                temp.matriz[r, c] = pMatriz.matriz[r, c] * s;
            }
        }

        return temp;
    }

    public static CMatriz3X3 operator *(float s, CMatriz3X3 pMatriz)
    {
        int r = 0;
        int c = 0;
        CMatriz3X3 temp = new CMatriz3X3();
        for (r = 0; r < 3; r++)
        {
            for (c = 0; c < 3; c++)
            {
                temp.matriz[r, c] = pMatriz.matriz[r, c] * s;
            }
        }

        return temp;
    }

    public static CMatriz3X3 operator *(CMatriz3X3 ma, CMatriz3X3 mb)
    {
        int r = 0;
        int c = 0;
        int t = 0;

        CMatriz3X3 temp = new CMatriz3X3();
        for (r = 0; r < 3; r++)
        {
            for (c = 0; c < 3; c++)
            {
                temp.matriz[r, c] = 0;
                for (t = 0; t < 3; t++)
                {
                    temp.matriz[r, c] += ma.matriz[r, t] * mb.matriz[t, c];
                }

            }
        }

        return temp;
    }

    public static CMatriz3X3 Identidad()
    {
        int r = 0;
        CMatriz3X3 temp = new CMatriz3X3();
        for (r = 0; r < 3; r++)
            temp.matriz[r, r] = 1;

        return temp;

    }

    public static CMatriz3X3 Menores(CMatriz3X3 pMatriz)
    {
        CMatriz3X3 temp = new CMatriz3X3();
        CMatriz2X2 sub;
        float determinante;
        int r = 0;
        int c = 0;
        for (r = 0; r < 3; r++)
        {
            for (c = 0; c < 3; c++)
            {
                sub = CMatriz3X3.Submatriz(pMatriz, r, c);
                determinante = CMatriz2X2.Detreminante(sub);
                temp.matriz[r, c] = determinante;
            }
        }

        return temp;
    }

    public static CMatriz2X2 Submatriz(CMatriz3X3 pMatriz,int renglon,int columa)
    {
        CMatriz2X2 temp = new CMatriz2X2();
        int rt = 0;
        int ct = 0;
        int r = 0;
        int c = 0;

        for (r = 0; r < 3; r++)
        {
            ct = 0;
            if (r == renglon)
                continue;
            for (c = 0; c < 3; c++)
            {
                if (c == columa)
                    continue;

                temp.matriz[rt, ct] = pMatriz.matriz[r, c];
                ct++;
            }
            rt++;
        }

        return temp;
    }

    public static CMatriz3X3 Cofactores(CMatriz3X3 pMatriz)
    {
        CMatriz3X3 temp = new CMatriz3X3();
        int r = 0;
        int c = 0;
        float signo = 1;

        for (r = 0; r < 3; r++)
        {
            for (c = 0; c < 3; c++)
            {
                signo = Mathf.Pow(-1f, (r + 1) + (c + 1));
                temp.matriz[r, c] = signo * pMatriz.matriz[r, c];
            }
        }

        return temp;
    }

    public static CMatriz3X3 Adjunta(CMatriz3X3 pMatriz)
    {
        CMatriz3X3 menores = CMatriz3X3.Menores(pMatriz);
        CMatriz3X3 cofactores = CMatriz3X3.Cofactores(menores);
        CMatriz3X3 adj = CMatriz3X3.Transpuesta(cofactores);
        return adj;
    }

    public static float Determinante(CMatriz3X3 pMatriz)
    {
        float d = 0;
        int c = 0;
        CMatriz3X3 menores = CMatriz3X3.Menores(pMatriz);
        CMatriz3X3 cofactores = CMatriz3X3.Cofactores(menores);
        for (c = 0; c < 3; c++)
            d += pMatriz.matriz[0, c] * cofactores.matriz[c, 0];
        

        return d;
    }

    public static CMatriz3X3 Inversa(CMatriz3X3 pMatriz)
    {
        CMatriz3X3 temp = new CMatriz3X3();
        float det = CMatriz3X3.Determinante(pMatriz);
      //  if (det == 0)
        //    return null;


        CMatriz3X3 adj = CMatriz3X3.Adjunta(pMatriz);
        temp = adj * (1f / det);
        return temp;
    }

    public static CMatriz3X3 RoatacionZ(float pAngulo)
    {
        pAngulo *= Mathf.Deg2Rad;

        CMatriz3X3 rz = CMatriz3X3.Identidad();
        rz.matriz[0, 0] = Mathf.Cos(pAngulo);
        rz.matriz[0, 1] = Mathf.Sin(pAngulo);
        rz.matriz[1, 0] = -Mathf.Sin(pAngulo);
        rz.matriz[1, 1] = Mathf.Cos(pAngulo);

        return rz;
    }


    public static CMatriz3X3 RoatacionX(float pAngulo)
    {
        pAngulo *= Mathf.Deg2Rad;

        CMatriz3X3 rx = CMatriz3X3.Identidad();
        rx.matriz[1, 1] = Mathf.Cos(pAngulo);
        rx.matriz[1, 2] = Mathf.Sin(pAngulo);
        rx.matriz[2, 1] = -Mathf.Sin(pAngulo);
        rx.matriz[2, 2] = Mathf.Cos(pAngulo);

        return rx;
    }


    public static CMatriz3X3 RoatacionY(float pAngulo)
    {
        pAngulo *= Mathf.Deg2Rad;

        CMatriz3X3 ry = CMatriz3X3.Identidad();
        ry.matriz[0, 0] = Mathf.Cos(pAngulo);
        ry.matriz[0, 2] = -Mathf.Sin(pAngulo);
        ry.matriz[2, 0] = Mathf.Sin(pAngulo);
        ry.matriz[2, 2] = Mathf.Cos(pAngulo);

        return ry;
    }

    public static CMatriz3X3 Rotatcion(float x, float y, float z)
    {
        CMatriz3X3 r = RoatacionZ(z) * RoatacionZ(x) * RoatacionZ(y);

        return r;
    }

    public static CVector3 ProductoVec3Mat3X3(CVector3 pVector, CMatriz3X3 pMatriz)
    {
        CVector3 temp = new CVector3();
        CVector3 operando = new CVector3(pMatriz.matriz[0, 0], pMatriz.matriz[1, 0], pMatriz.matriz[2, 0]);

        temp.X = CVector3.Punto(pVector, operando);

        operando = new CVector3(pMatriz.matriz[0, 1], pMatriz.matriz[1, 1], pMatriz.matriz[2, 1]);

        temp.Y = CVector3.Punto(pVector, operando);

        operando = new CVector3(pMatriz.matriz[0, 2], pMatriz.matriz[1, 2], pMatriz.matriz[2, 2]);

        temp.Z = CVector3.Punto(pVector, operando);

        return temp;
    }

}
