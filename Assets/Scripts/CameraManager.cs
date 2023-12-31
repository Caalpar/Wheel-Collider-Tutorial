using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject focus;
    public float distance = 5f;
    public float height = 2f;
    public float danpening = 1f;


    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, focus.transform.position + focus.transform.TransformDirection(new Vector3(0f,height,-distance)), danpening * Time.deltaTime);
        transform.LookAt(focus.transform);
    }
}
