using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(InputManager))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(LightingManager))]
public class CarController : MonoBehaviour
{
    public InputManager inputManager;
    public LightingManager lightingManager;
    public List<WheelCollider> throttleWheeels;
    public List<GameObject> steeringWheeels;
    public List<GameObject> meshes;
    public float strengthCoefficient = 10000f;
    public float maxTurn = 20f;
    public float brakeStrength;
    public Transform CM;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        inputManager = GetComponent<InputManager>();
        rb = GetComponent<Rigidbody>();

        if (CM)
        {
            rb.centerOfMass = CM.position;
        }
    }


    public void Update()
    {
        if (inputManager.l)
        {
          lightingManager.ToggleHeadLights();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        foreach (WheelCollider wheel in throttleWheeels)
        {
           

            if (inputManager.brake)
            {
                wheel.motorTorque = 0;
                wheel.brakeTorque = brakeStrength * Time.deltaTime;
            }
            else
            {
                wheel.motorTorque = strengthCoefficient * Time.deltaTime * inputManager.throttle;
                wheel.brakeTorque = 0;
            }
        }

        foreach (GameObject wheel in steeringWheeels)
        {
            wheel.GetComponent<WheelCollider>().steerAngle = maxTurn * inputManager.steer;
            wheel.transform.localEulerAngles = new Vector3(0,inputManager.steer * maxTurn, 0);
        }

        foreach (GameObject mesh in meshes)
        {
            mesh.transform.Rotate(rb.velocity.magnitude * (transform.InverseTransformDirection(rb.velocity).z >= 0 ? 1 : -1) / (2 * Mathf.PI * throttleWheeels[0].radius),0f,0f);
        }
    }
}
