using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matrices004 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CMatriz2X2 matriz1 = new CMatriz2X2();
        CMatriz2X2 matriz2 = new CMatriz2X2();

        float[,] m = { { 1, 2 }, { 3, 4 } };
        float[,] m2 = { { 5, 6 }, { 7, 8 } };

        matriz1.ColocaMatriz(m);
        matriz2.ColocaMatriz(m2);

        Debug.Log(matriz1);

        CMatriz2X2 r = CMatriz2X2.Transpuesta(matriz1);

        Debug.Log(r);

        r = matriz1 * 5f;

        Debug.Log(r);

        r = matriz1 * matriz2;

        Debug.Log(r);

        r = CMatriz2X2.Identidad();

        Debug.Log(r);


        float d1 = CMatriz2X2.Detreminante(matriz1);
        float d2 = CMatriz2X2.Detreminante(matriz2);

        Debug.Log(d1);
        Debug.Log(d2);

        r = CMatriz2X2.Menores(matriz2);

        Debug.Log(r);

        r = CMatriz2X2.Adjunta(matriz2);

        Debug.Log("aca 2X2:"+r);

        float[,] m3 = { { 1, 2,1 }, { 3, 4 ,7}, { 5, 6, 11 } };
        float[,] m4 = { { 5, 6 ,11}, { 7, 8,15 },{9,10,19 } };


        CMatriz3X3 matriz3 = new CMatriz3X3(m3);
        CMatriz3X3 matriz4 = new CMatriz3X3(m4);
        CMatriz3X3 r3;
        CMatriz2X2 sub;

        sub = CMatriz3X3.Submatriz(matriz3, 1, 2);
       // Debug.Log(sub);

        r3 = CMatriz3X3.Menores(matriz3);
       // Debug.Log(r3);
        //Debug.Log(matriz3);

        r3 = CMatriz3X3.Cofactores(matriz3);
      //  Debug.Log(r3);

        r3 = CMatriz3X3.Adjunta(matriz3);
        // Debug.Log(r3);
        r3 = CMatriz3X3.Inversa(matriz3);
        Debug.Log(r3);
        Debug.Log(r3 * matriz3);


        float[,] m5 = { { 1, 2, 3,4 }, { 3, 4, 5,6 }, { 5, 6, 7,8 }, { 7, 8, 9, 10 } };
        float[,] m6 = { { 1, 2, 11, 5 }, { 7, 4, 6, 6 }, { 7, 6, 7, 8 }, { 9, 8, 9, 10 } };


        CMatriz4X4 matriz5 = new CMatriz4X4(m5);
        CMatriz4X4 matriz6 = new CMatriz4X4(m6);
        CMatriz4X4 r4;



       // Debug.Log(matriz5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
