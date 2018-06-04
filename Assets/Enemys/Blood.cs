using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blood : MonoBehaviour {

    
	void Update ()
    {
        if (transform.localScale.x < 0.8f)
        {
            transform.localScale = (transform.localScale * 1.0015f);
        }
	}
}
