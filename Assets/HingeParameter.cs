using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HingeParameter : MonoBehaviour
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
    public GameObject camion;
    private Rigidbody RgCamion;
    public HingeJoint pivot;
    public List<Wheel> wheels;
    void Start()
    {
        pivot = GetComponent<HingeJoint>();
        
    }

    // Update is called once per frame
    void Update()
    {
        JointLimits limits = pivot.limits;
        limits.min = -115;
        limits.bounciness = 0;
        limits.bounceMinVelocity = 0;
        limits.max = 115;
        pivot.limits = limits;
        pivot.useLimits = true;
    }
    public void Attached()
    {
        RgCamion = camion.GetComponent<Rigidbody>();
        pivot.connectedBody = RgCamion;



    }
    public void DeAttached()
    {
        
        pivot.connectedBody = null;
        print("bonjour22");


    }
}
