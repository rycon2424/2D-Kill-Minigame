using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : MonoBehaviour {

    public GameObject[] radios = new GameObject[5];
    public int channel;
    
	void Start ()
    {
        radios[0].SetActive(true);
        channel = 0;
	}
	
	void Update ()
    {
        if (channel == radios.Length - 1)
        {
            channel = 0;
        }
        if (channel == 0)
        {
            radios[radios.Length - 2].SetActive(false);
            radios[channel].SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            channel = channel + 1;
            ChangeChannel();
        }
    }

    void ChangeChannel()
    {
        radios[channel - 1].SetActive(false);
        radios[channel].SetActive(true);
    }
}
