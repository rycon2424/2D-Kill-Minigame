using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour {

    public static bool gameStart;
    
	void Start ()
    {
        gameStart = false;
        StartCoroutine(TutorialTime());
	}

    IEnumerator TutorialTime()
    {
        yield return new WaitForSeconds(15f);
        gameStart = true;
        Destroy(this.gameObject);
    }
	
}
