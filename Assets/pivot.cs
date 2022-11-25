using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pivot : MonoBehaviour
{
    public GameObject anchor;
    float currentTime = 0f;
    float startingTime = 10f;
    float interpolation = 0f;
    bool TimerStart;
    void FixedUpdate()
    {
        if (TimerStart)
        {
            currentTime += Time.fixedDeltaTime;
        }
        int layerMask = 1 << 8;

        
        layerMask = ~layerMask;

        RaycastHit hit;
        
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("Did Hit");
            TimerStart = false;
            currentTime = 0f;

        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            Debug.Log("Did not Hit");
            TimerStart = true;
            if(currentTime < startingTime)
            {
                interpolation = currentTime / startingTime;
                this.gameObject.transform.rotation = Quaternion.Euler(0, Mathf.LerpAngle(this.gameObject.transform.rotation.eulerAngles.y, anchor.transform.rotation.eulerAngles.y, interpolation), 0);

            }
        }
    }
}
