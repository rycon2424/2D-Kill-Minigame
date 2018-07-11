using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour {

    [Header("FirstMenu")]
    public bool firstMenu = true;
    bool anyKeySpam = true;
    public GameObject pressAnykey;
    public GameObject firstMenuLayout;

    [Header("SecondMenu")]
    public GameObject secondMenuLayout;
    public Text currentScore;

    void Start ()
    {
        firstMenuLayout.SetActive(true);
        secondMenuLayout.SetActive(false);
        currentScore.text = Player.prevHighscore.ToString();
    }
	
	void Update ()
    {
         FirstMenuHandler();
    }

    void FirstMenuHandler()
    {
        if (firstMenu == true && anyKeySpam == true)
        {
            StartCoroutine(KeyPress());
        }

        if (firstMenu == true && Input.anyKey)
        {
            firstMenu = false;
        }

        if (firstMenu == false)
        {
            firstMenuLayout.SetActive(false);
            secondMenuLayout.SetActive(true);
        }
    }

    IEnumerator KeyPress()
    {
        yield return new WaitForSeconds(0.5f);
        anyKeySpam = false;
        pressAnykey.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        pressAnykey.SetActive(true);
        anyKeySpam = true;
    }
}
