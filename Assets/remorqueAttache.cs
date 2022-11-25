using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class remorqueAttache : MonoBehaviour
{
    
    public GameObject centerOfMass;
    public Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = centerOfMass.transform.localPosition;
    }

    // Update is called once per frame
    
}
