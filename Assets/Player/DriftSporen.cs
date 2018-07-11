using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriftSporen : MonoBehaviour
{

    float downTime, upTime, pressTime = 0;
    public float countDown;
    public bool ready = false;

    public Transform wheel1;
    public Transform wheel2;

    public Transform drift;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) && ready == false)
        {
            downTime = Time.time;
            pressTime = downTime + countDown;
            ready = true;
        }
        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            ready = false;
        }
        if (Time.time >= pressTime && ready == true)
        {
            Instantiate(drift, wheel1.transform.position, wheel1.transform.rotation);
            Instantiate(drift, wheel2.transform.position, wheel2.transform.rotation);
        }
    }
}

