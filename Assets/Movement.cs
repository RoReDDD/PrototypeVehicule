using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] private float speed = 5f;
    public bool CanMove;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        CanMove = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            CanMove = true;
        }

        if (CanMove)
        {
            float X = Input.GetAxis("Horizontal");
            float Z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * X + transform.forward * Z;

            transform.position += move * speed * Time.deltaTime;
        }
        
    }
}
