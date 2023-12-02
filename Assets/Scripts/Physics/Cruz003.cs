using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cruz003 : MonoBehaviour
{
    public float x1 = 3f;
    public float y1 = 2f;
    public float z1 = 1f;

    public float x2 = -2f;
    public float y2 = 3.5f;
    public float z2 = -2.5f;

    public CVector3 v1;
    public CVector3 v2;
    public CVector3 r;


    private void Awake()
    {
            v1 = new CVector3(0, 0, 0);
            v2 = new CVector3(0, 0, 0);
            r = new CVector3(0, 0, 0);
    }
    // Start is called before the first frame update
    void Start()
    {
        v1.X = x1;
        v1.Y = y1;
        v1.Z = z1;

        v2.X = x2;
        v2.Y = y2;
        v2.Z = z2;
    }

    // Update is called once per frame
    void Update()
    {
        v1.X = x1;
        v1.Y = y1;
        v1.Z = z1;

        v2.X = x2;
        v2.Y = y2;
        v2.Z = z2;

        r = CVector3.Cruz(v1, v2);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(new Vector3(0, 0, 0), new Vector3(v1.X, v1.Y,v1.Z));

        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector3(0, 0, 0), new Vector3(v2.X, v2.Y, v2.Z));

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(new Vector3(0, 0, 0), new Vector3(r.X, r.Y, r.Z));

    }
}
