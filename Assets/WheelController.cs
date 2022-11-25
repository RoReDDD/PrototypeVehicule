using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WheelController : MonoBehaviour
{
    public enum Axel
    {
        Front,
        Rear
    }

    [Serializable]
    public struct Wheel
    {
        public GameObject wheelModel;
        public WheelCollider wheelCollider;
        public Axel axel;
    }
    public List<Wheel> wheels;

    public float maxAcceleration = 30;
    public float brakeAcceleration = 50;

    public float turnSensitivity = 1;
    public float maxSteerAngle = 30;

    public Vector3 _centerOfMass;

    

    float moveInput;
    float steerInput;

    [SerializeField] private Camera camFront, camBack;   
     public Rigidbody rb;

    [SerializeField] private bool AncrageReady;
    [SerializeField] private bool Ancrage;

    [SerializeField] private HingeParameter AttacheRemorque;

    

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = _centerOfMass;
        
        //camBack.enabled = false;
        AncrageReady = false;
        Ancrage = false;

        
    }

    void LateUpdate()
    {
        Move();
        Steer();
    }

    void GetInput()
    {
        moveInput = Input.GetAxis("Vertical");
        steerInput = Input.GetAxis("Horizontal");
    }

    void Move()
    {
        foreach(var wheel in wheels)
        {
            wheel.wheelCollider.motorTorque = moveInput * 600 * maxAcceleration * Time.deltaTime;
        }
    }

    void Steer()
    {
        foreach(var wheel in wheels)
        {
            if(wheel.axel == Axel.Front)
            {
                var _steerAngle = steerInput * turnSensitivity * maxSteerAngle;
                wheel.wheelCollider.steerAngle = Mathf.Lerp(wheel.wheelCollider.steerAngle, _steerAngle, 0.06f);
            }
        }
    }


    private void Update()
    {

        GetInput();
        if (Input.GetKeyDown(KeyCode.Y))
        {
            camFront.enabled = false;
            camBack.enabled = true;
        }
        if (Input.GetKeyUp(KeyCode.Y))
        {
            camFront.enabled = true;
            camBack.enabled = false;
        }
        if (Input.GetButtonDown("Fire1") && Ancrage)
        {
            
            AttacheRemorque.DeAttached();
            Ancrage = false;
            /*foreach (Wheel wheelToAdd in AttacheRemorque.wheels)
                wheels.Remove(wheelToAdd);*/
            print("bonjour");
        }
        else if (Input.GetButtonDown("Fire1") && AncrageReady && !Ancrage)
        {
            
            AttacheRemorque.Attached();
            Ancrage = true;
            /* (Wheel wheelToAdd in AttacheRemorque.wheels)
                wheels.Add(wheelToAdd);*/
            print("attacher");
        }

    }

    public void OnTriggerStay(Collider col)
    {
        if (col.CompareTag("Remorque"))
        {
            AncrageReady = true;
            
            HingeParameter remorque = col.GetComponent<HingeParameter>();
            AttacheRemorque = remorque;
            print("Pret a l'ancrage");
        }
    }
}
