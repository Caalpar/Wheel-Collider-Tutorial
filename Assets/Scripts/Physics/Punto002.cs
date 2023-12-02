using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punto002 : MonoBehaviour
{
    public float x = 3f;
    public float y = 3f;

    private CVector2 forward = new CVector2(0, 1);
    private CVector2 rigth = new CVector2(1,0);
    private CVector2 objetivo = new CVector2(0,0);
    private CVector2 n = new CVector2(0,0);
    private CVector2 proy = new CVector2(0,0);
    private CVector2 refl = new CVector2(0,0);
    
    // Start is called before the first frame update
    void Start()
    {
        objetivo.X = x;
        objetivo.Y = y;
    }

    // Update is called once per frame
    void Update()
    {
        objetivo.X = x;
        objetivo.Y = y;

        float pp = CVector2.Punto(rigth, objetivo);

        if (pp < 0)
            Debug.Log("A la dercha");
        else if (pp>0)
            Debug.Log("A la izquierda");
        else 
            Debug.Log("En el eje");


        float pp2 = CVector2.Punto(forward, objetivo);

        if (pp < 0)
            Debug.Log("Adelante");
        else if (pp > 0)
            Debug.Log("Atras");
        else
            Debug.Log("Al lado");

        float m = CVector2.Magnitud(objetivo);
        float mc = CVector2.MagnitudC(objetivo);

        n = CVector2.Normalizar(objetivo);

        Debug.Log("m=" + m + ",mc=" + mc);

        float a = CVector2.Angulo(rigth, objetivo);

        Debug.Log("El angulo es:" + Mathf.Rad2Deg * a);

        proy = CVector2.Proyectar(objetivo, rigth);

        refl = CVector2.Refleccion(-1 * objetivo, forward);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(new Vector3(0, 0, 0), new Vector3(forward.X, forward.Y));

        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector3(0, 0, 0), new Vector3(rigth.X, rigth.Y));

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(new Vector3(0, 0, 0), new Vector3(objetivo.X, objetivo.Y));
        Gizmos.DrawSphere(new Vector3(objetivo.X, objetivo.Y,0),0.1f);


        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(new Vector3(0, 0, 0), new Vector3(proy.X, proy.Y));

        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(new Vector3(0, 0, 0), new Vector3(n.X, n.Y));

        Gizmos.color = Color.black;
        Gizmos.DrawLine(new Vector3(0, 0, 0), new Vector3(refl.X, refl.Y));
    }
}
