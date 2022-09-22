using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoueController : MonoBehaviour
{
    [SerializeField] WheelCollider AvantD, AvantG, MilieuD, MilieuG, ArriereD, ArriereG;

    public float acceleration = 500f;
    public float breakingforce = 350f;

    public float currentAcceleration = 0f;
    public float currentBreakForce = 0f;

    private void FixedUpdate()
    {
        currentAcceleration = acceleration * Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.Space))
            currentBreakForce = breakingforce;
        else
            currentBreakForce = 0f;

        AvantD.motorTorque = acceleration;
        AvantG.motorTorque = acceleration;

        AvantD.brakeTorque = breakingforce;
        AvantG.brakeTorque = breakingforce;
        MilieuD.brakeTorque = breakingforce;
        MilieuG.brakeTorque = breakingforce;
        ArriereD.brakeTorque = breakingforce;
        ArriereG.brakeTorque = breakingforce;


    }
}
