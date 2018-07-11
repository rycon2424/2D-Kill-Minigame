using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodsPower : MonoBehaviour {

    [Range(1.0f, 15.0f)]
    public float timeScale;
    
	void Start ()
    {
		
	}
	
	void Update ()
    {
        Time.timeScale = timeScale;
	}
}
