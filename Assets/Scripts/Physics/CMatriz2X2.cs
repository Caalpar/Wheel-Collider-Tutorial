using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMatriz2X2 
{
    public float[,] matriz = new float[2, 2];

    public CMatriz2X2()
    {

        int r = 0;
        int c = 0;

        for (r = 0; r < 2; r++)
        {
            for (c = 0; c < 2; c++)
            {
                matriz[r, c] = 0;
            }
        }
    }

    public CMatriz2X2(float [,] pMatriz)
    {
        matriz = pMatriz;
    }

    public override string ToString()
    {
        int r = 0;
        int c = 0;
        string srt = "";

        for (r = 0; r < 2; r++)
        {
            for (c = 0; c < 2; c++)
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

    public static CMatriz2X2 Transpuesta(CMatriz2X2 pMatriz)
    {
        int r = 0;
        int c = 0;
        CMatriz2X2 temp = new CMatriz2X2();
        for (r = 0; r < 2; r++)
        {
            for (c = 0; c < 2; c++)
            {
                temp.matriz[c, r] = pMatriz.matriz[r, c];
            }
        }

        return temp;
    }

    public static CMatriz2X2 operator*(CMatriz2X2 pMatriz, float s)
    {
        int r = 0;
        int c = 0;
        CMatriz2X2 temp = new CMatriz2X2();
        for (r = 0; r < 2; r++)
        {
            for (c = 0; c < 2; c++)
            {
                temp.matriz[r, c] = pMatriz.matriz[r, c] * s;
            }
        }

        return temp;
    }

    public static CMatriz2X2 operator *(float s, CMatriz2X2 pMatriz)
    {
        int r = 0;
        int c = 0;
        CMatriz2X2 temp = new CMatriz2X2();
        for (r = 0; r < 2; r++)
        {
            for (c = 0; c < 2; c++)
            {
                temp.matriz[r, c] = pMatriz.matriz[r, c] * s;
            }
        }

        return temp;
    }

    public static CMatriz2X2 operator *(CMatriz2X2 ma, CMatriz2X2 mb)
    {
        int r = 0;
        int c = 0;
        int t = 0;

        CMatriz2X2 temp = new CMatriz2X2();
        for (r = 0; r < 2; r++)
        {
            for (c = 0; c < 2; c++)
            {
                temp.matriz[r, c] = 0;
                for (t = 0; t < 2; t++)
                {
                    temp.matriz[r, c] += ma.matriz[r,t] * mb.matriz[t,c];
                }

            }
        }

        return temp;
    }

    public static CMatriz2X2 Identidad()
    {
        int r = 0;
        CMatriz2X2 temp = new CMatriz2X2();
        for (r = 0; r < 2; r++)
            temp.matriz[r, r] = 1;

        return temp;
        
    }

    public static float Detreminante(CMatriz2X2 pMatriz)
    {
        float d = pMatriz.matriz[0, 0] * pMatriz.matriz[1, 1] - pMatriz.matriz[0, 1] * pMatriz.matriz[1, 0];
        return d;
    }

    public static CMatriz2X2 Menores(CMatriz2X2 pMatriz)
    {
        float[,] m = { { pMatriz.matriz[1, 1], pMatriz.matriz[1, 0] }, { pMatriz.matriz[0, 1], pMatriz.matriz[0, 0] } };
        return new CMatriz2X2(m);
    }


    public static CMatriz2X2 Cofactores(CMatriz2X2 pMatriz)
    {
        CMatriz2X2 temp = new CMatriz2X2();
        int r = 0;
        int c = 0;
        float signo = 1;

        for (r = 0; r < 2; r++)
        {
            for (c = 0; c < 2; c++)
            {
                signo = Mathf.Pow(-1f, (r + 1) + (c + 1));
                temp.matriz[r, c] = signo * pMatriz.matriz[r, c];
            }
        }

        return temp;
    }


    public static CMatriz2X2 Adjunta(CMatriz2X2 pMatriz)
    {
        CMatriz2X2 menores = CMatriz2X2.Menores(pMatriz);
        CMatriz2X2 cofactores = CMatriz2X2.Cofactores(menores);
        CMatriz2X2 adj = CMatriz2X2.Transpuesta(cofactores);
        return adj;
    }

    public static CMatriz2X2 Inversa(CMatriz2X2 pMatriz)
    {
        CMatriz2X2 temp = new CMatriz2X2();
        float det = CMatriz2X2.Detreminante(pMatriz);
        if (det == 0)
            return null;

        CMatriz2X2 adj = CMatriz2X2.Adjunta(pMatriz);
        temp = adj * (1f / det);
        return temp;
    }

}
