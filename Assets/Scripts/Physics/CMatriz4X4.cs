using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMatriz4X4 
{
    public float[,] matriz = new float[4, 4];

    public CMatriz4X4()
    {

        int r = 0;
        int c = 0;

        for (r = 0; r < 4; r++)
        {
            for (c = 0; c < 4; c++)
            {
                matriz[r, c] = 0;
            }
        }
    }

    public CMatriz4X4(float[,] pMatriz)
    {
        matriz = pMatriz;
    }

    public override string ToString()
    {
        int r = 0;
        int c = 0;
        string srt = "";

        for (r = 0; r < 4; r++)
        {
            for (c = 0; c < 4; c++)
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

    public static CMatriz4X4 Transpuesta(CMatriz4X4 pMatriz)
    {
        int r = 0;
        int c = 0;
        CMatriz4X4 temp = new CMatriz4X4();
        for (r = 0; r < 4; r++)
        {
            for (c = 0; c < 4; c++)
            {
                temp.matriz[c, r] = pMatriz.matriz[r, c];
            }
        }

        return temp;
    }

    public static CMatriz4X4 operator *(CMatriz4X4 pMatriz, float s)
    {
        int r = 0;
        int c = 0;
        CMatriz4X4 temp = new CMatriz4X4();
        for (r = 0; r < 4; r++)
        {
            for (c = 0; c < 4; c++)
            {
                temp.matriz[r, c] = pMatriz.matriz[r, c] * s;
            }
        }

        return temp;
    }

    public static CMatriz4X4 operator *(float s, CMatriz4X4 pMatriz)
    {
        int r = 0;
        int c = 0;
        CMatriz4X4 temp = new CMatriz4X4();
        for (r = 0; r < 4; r++)
        {
            for (c = 0; c < 4; c++)
            {
                temp.matriz[r, c] = pMatriz.matriz[r, c] * s;
            }
        }

        return temp;
    }


    public static CMatriz4X4 operator *(CMatriz4X4 ma, CMatriz4X4 mb)
    {
        int r = 0;
        int c = 0;
        int t = 0;

        CMatriz4X4 temp = new CMatriz4X4();
        for (r = 0; r < 4; r++)
        {
            for (c = 0; c < 4; c++)
            {
                temp.matriz[r, c] = 0;
                for (t = 0; t < 4; t++)
                {
                    temp.matriz[r, c] += ma.matriz[r, t] * mb.matriz[t, c];
                }

            }
        }

        return temp;
    }

    public static CMatriz4X4 Identidad()
    {
        int r = 0;
        CMatriz4X4 temp = new CMatriz4X4();
        for (r = 0; r < 4; r++)
            temp.matriz[r, r] = 1;

        return temp;

    }

    public static CMatriz4X4 Menores(CMatriz4X4 pMatriz)
    {
        CMatriz4X4 temp = new CMatriz4X4();
        CMatriz3X3 sub;
        float determinante;
        int r = 0;
        int c = 0;
        for (r = 0; r < 4; r++)
        {
            for (c = 0; c < 4; c++)
            {
                sub = CMatriz4X4.Submatriz(pMatriz, r, c);
                determinante = CMatriz3X3.Determinante(sub);
                temp.matriz[r, c] = determinante;
            }
        }

        return temp;
    }

    public static CMatriz3X3 Submatriz(CMatriz4X4 pMatriz, int renglon, int columa)
    {
        CMatriz3X3 temp = new CMatriz3X3();
        int rt = 0;
        int ct = 0;
        int r = 0;
        int c = 0;

        for (r = 0; r < 4; r++)
        {
            ct = 0;
            if (r == renglon)
                continue;
            for (c = 0; c < 4; c++)
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

    public static CMatriz4X4 Cofactores(CMatriz4X4 pMatriz)
    {
        CMatriz4X4 temp = new CMatriz4X4();
        int r = 0;
        int c = 0;
        float signo = 1;

        for (r = 0; r < 4; r++)
        {
            for (c = 0; c < 4; c++)
            {
                signo = Mathf.Pow(-1f, (r + 1) + (c + 1));
                temp.matriz[r, c] = signo * pMatriz.matriz[r, c];
            }
        }

        return temp;
    }

    public static CMatriz4X4 Adjunta(CMatriz4X4 pMatriz)
    {
        CMatriz4X4 menores = CMatriz4X4.Menores(pMatriz);
        CMatriz4X4 cofactores = CMatriz4X4.Cofactores(menores);
        CMatriz4X4 adj = CMatriz4X4.Transpuesta(cofactores);
        return adj;
    }

    public static float Determinante(CMatriz4X4 pMatriz)
    {
        float d = 0;
        int c = 0;
        CMatriz4X4 menores = CMatriz4X4.Menores(pMatriz);
        CMatriz4X4 cofactores = CMatriz4X4.Cofactores(menores);
        for (c = 0; c < 4; c++)
            d += pMatriz.matriz[0, c] * cofactores.matriz[c, 0];


        return d;
    }

    public static CMatriz4X4 Inversa(CMatriz4X4 pMatriz)
    {
        CMatriz4X4 temp = new CMatriz4X4();
        float det = CMatriz4X4.Determinante(pMatriz);
        if (det == 0)
            return null;

        CMatriz4X4 adj = CMatriz4X4.Adjunta(pMatriz);
        temp = adj * (1f / det);
        return temp;
    }

    public static CMatriz4X4 Traslacion(CVector3 pPosicion)
    {
        CMatriz4X4 temp = CMatriz4X4.Identidad();

        temp.matriz[3, 0] = pPosicion.X;
        temp.matriz[3, 1] = pPosicion.Y;
        temp.matriz[3, 2] = pPosicion.Z;

        return temp;
    }

    public static CMatriz4X4 Traslacion(float dx, float dy, float dz)
    {
        CMatriz4X4 temp = CMatriz4X4.Identidad();

        temp.matriz[3, 0] = dx;
        temp.matriz[3, 1] = dy;
        temp.matriz[3, 2] = dz;

        return temp;
    }
    public static CVector3 OtenerTraslacion(CMatriz4X4 pMatriz)
    {
        return new CVector3(pMatriz.matriz[3, 0], pMatriz.matriz[3, 1], pMatriz.matriz[3, 2]);
    }


    public static CMatriz4X4 Escala(CVector3 pEscala)
    {
        CMatriz4X4 temp = CMatriz4X4.Identidad();

        temp.matriz[0, 0] = pEscala.X;
        temp.matriz[1, 1] = pEscala.Y;
        temp.matriz[2, 2] = pEscala.Z;

        return temp;
    }

    public static CMatriz4X4 Escala(float px, float py, float pz)
    {
        CMatriz4X4 temp = CMatriz4X4.Identidad();

        temp.matriz[0, 0] = px;
        temp.matriz[1, 1] = py;
        temp.matriz[2, 2] = pz;

        return temp;
    }

    public static CVector3 OtenerEscala(CMatriz4X4 pMatriz)
    {
        return new CVector3(pMatriz.matriz[0, 0], pMatriz.matriz[1, 1], pMatriz.matriz[2, 2]);
    }

    public static CMatriz4X4 RoatacionZ(float pAngulo)
    {
        pAngulo *= Mathf.Deg2Rad;

        CMatriz4X4 rz = CMatriz4X4.Identidad();
        rz.matriz[0, 0] = Mathf.Cos(pAngulo);
        rz.matriz[0, 1] = Mathf.Sin(pAngulo);
        rz.matriz[1, 0] = - Mathf.Sin(pAngulo);
        rz.matriz[1, 1] = Mathf.Cos(pAngulo);

        return rz;
    }


    public static CMatriz4X4 RoatacionX(float pAngulo)
    {
        pAngulo *= Mathf.Deg2Rad;

        CMatriz4X4 rx = CMatriz4X4.Identidad();
        rx.matriz[1, 1] = Mathf.Cos(pAngulo);
        rx.matriz[1, 2] = Mathf.Sin(pAngulo);
        rx.matriz[2, 1] = - Mathf.Sin(pAngulo);
        rx.matriz[2, 2] = Mathf.Cos(pAngulo);

        return rx;
    }


    public static CMatriz4X4 RoatacionY(float pAngulo)
    {
        pAngulo *= Mathf.Deg2Rad;

        CMatriz4X4 ry = CMatriz4X4.Identidad();
        ry.matriz[0, 0] = Mathf.Cos(pAngulo);
        ry.matriz[0, 2] = -Mathf.Sin(pAngulo);
        ry.matriz[2, 0] = Mathf.Sin(pAngulo);
        ry.matriz[2, 2] = Mathf.Cos(pAngulo);

        return ry;
    }

    public static CMatriz4X4 Rotatcion(float x, float y, float z)
    {
        CMatriz4X4 r = RoatacionZ(z) * RoatacionZ(x) * RoatacionZ(y);

        return r;
    }

    public static CVector3 PuntoProductoMat4x4(CVector3 pVector, CMatriz4X4 pMatriz)
    {
        CVector3 temp = new CVector3();

        temp.X = pVector.X * pMatriz.matriz[0, 0] + pVector.Y * pMatriz.matriz[1, 0] + pVector.Z * pMatriz.matriz[2, 0] + 1f * pMatriz.matriz[3,0];
        temp.Y = pVector.X * pMatriz.matriz[0, 1] + pVector.Y * pMatriz.matriz[1, 1] + pVector.Z * pMatriz.matriz[2, 1] + 1f * pMatriz.matriz[3, 1];
        temp.Z = pVector.X * pMatriz.matriz[0, 2] + pVector.Y * pMatriz.matriz[1, 2] + pVector.Z * pMatriz.matriz[2, 2] + 1f * pMatriz.matriz[3, 2];

        return temp;

    }

    public static CVector3 VectorProductoMat4X4(CVector3 pVector, CMatriz4X4 pMatriz)
    {
        CVector3 temp = new CVector3();

        temp.X = pVector.X * pMatriz.matriz[0, 0] + pVector.Y * pMatriz.matriz[1, 0] + pVector.Z * pMatriz.matriz[2, 0] + 0 * pMatriz.matriz[3, 0];
        temp.Y = pVector.X * pMatriz.matriz[0, 1] + pVector.Y * pMatriz.matriz[1, 1] + pVector.Z * pMatriz.matriz[2, 1] + 0 * pMatriz.matriz[3, 1];
        temp.Z = pVector.X * pMatriz.matriz[0, 2] + pVector.Y * pMatriz.matriz[1, 2] + pVector.Z * pMatriz.matriz[2, 2] + 0 * pMatriz.matriz[3, 2];

        return temp;

    }

    public static CMatriz4X4 Trasformada(CVector3 pEscala, CVector3 pRotacion, CVector3 traslacion)
    {
        CMatriz4X4 temp = CMatriz4X4.Escala(pEscala) * CMatriz4X4.Rotatcion(pRotacion.X, pRotacion.Y, pRotacion.Z) * CMatriz4X4.Traslacion(traslacion);
        return temp;
    }


}
