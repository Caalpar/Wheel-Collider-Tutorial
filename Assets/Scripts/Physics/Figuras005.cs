using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Figuras005 : MonoBehaviour
{

    CLinea linea1;
    // Start is called before the first frame update
    void Start()
    {
        linea1 = gameObject.AddComponent(typeof(CLinea)) as CLinea;
        linea1.ColocaPuntos(new CVector2(0, 0), new CVector2(3, 5));
        linea1.ColocaColor(0.9f, 0, 1f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
