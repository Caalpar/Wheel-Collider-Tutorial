using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CLinea : MonoBehaviour
{
    private CVector2 inicio = new CVector2();
    private CVector2 fin = new CVector2();

    private Color color = new Color(0,0,0);

    public CVector2 Inicio { get { return inicio; } set { inicio = value; }  }
    public CVector2 Fin { get { return fin; } set { fin = value; }  }


    public void ColocaPuntos(CVector2 pInicio, CVector2 pFin)
    {
        inicio = pInicio;
        fin = pFin;
    }

    public void ColocaColor(float pR, float pG, float pB)
    {
        color.r = pR;
        color.g = pG;
        color.b = pB;
    }
    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}

    private void OnDrawGizmos()
    {
        Gizmos.color = color;
        Gizmos.DrawLine(new Vector3(inicio.X, inicio.Y, 0), new Vector3(fin.X, fin.Y, 0));
    }

    public static float Longitud(CLinea pLinea)
    {
        return CVector2.Magnitud(pLinea.fin - pLinea.inicio);
    }

    public static float LongitudC(CLinea pLinea)
    {
        return CVector2.MagnitudC(pLinea.fin - pLinea.inicio);
    }
}
