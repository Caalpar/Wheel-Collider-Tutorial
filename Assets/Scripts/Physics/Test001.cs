using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test001 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CVector2 v1 = new CVector2(2, 5);
        CVector2 v2 = new CVector2(2, 5);
        CVector2 r;

        r = v1 + v2;
        Debug.Log(r);
        r = v1 - v2;
        Debug.Log(r);
        r = v1 * v2;
        Debug.Log(r);
        r = v1 * 3f;
        Debug.Log(r);

        if(v1 == v2)
        {
            Debug.Log("v1 y v2 son iguales");
        }

        if (v1 != v2)
        {
            Debug.Log("v1 y v2 no son iguales");
        }

        CVector3 v3 = new CVector3(4, 3, 1);
        CVector3 v4 = new CVector3(4, -3, 1);
        CVector3 r3;

        r3 = v3 + v4;
        Debug.Log(r3);
        r3 = v3 - v4;
        Debug.Log(r3);
        r3 = v3 * v4;
        Debug.Log(r3);
        r3 = v3 * 5.5f;
        Debug.Log(r3);

        if (v3 == v4)
        {
            Debug.Log("v3 y v4 son iguales");
        }

        if (v3 != v4)
        {
            Debug.Log("v3 y v4 no son iguales");
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
