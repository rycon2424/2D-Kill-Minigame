using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnMouseHover : MonoBehaviour {

    public GameObject[] speed = new GameObject[5];
    public GameObject[] drift = new GameObject[5];
    public GameObject[] reverseSpeed = new GameObject[5];
    public static int whatCar;
    public int carNumber;
    public float requiredUnlock;
    public GameObject price;

    [Header("Stats")]
    public int speedInt;
    public int DriftInt;
    public int ReverseInt;

    public GameObject fire;

    private void Start()
    {
        if (Player.prevHighscore > requiredUnlock || Player.prevHighscore == requiredUnlock)
        {
            price.SetActive(false);
        }
    }

    void OnMouseOver()
     {
        fire.SetActive(true);
        for (int i = 0; i < speedInt; i++)
        {
            speed[i].SetActive(true);
        }
        for (int i = 0; i < DriftInt; i++)
        {
            drift[i].SetActive(true);
        }
        for (int i = 0; i < ReverseInt; i++)
        {
            reverseSpeed[i].SetActive(true);
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (Player.prevHighscore > requiredUnlock || Player.prevHighscore == requiredUnlock)
            {
                whatCar = carNumber - 1;
                SceneManager.LoadScene("MainMap");
            }
        }
     }

     void OnMouseExit()
     {
        fire.SetActive(false);
        for (int i = 0; i < speedInt; i++)
        {
            speed[i].SetActive(false);
        }
        for (int i = 0; i < DriftInt; i++)
        {
            drift[i].SetActive(false);
        }
        for (int i = 0; i < ReverseInt; i++)
        {
            reverseSpeed[i].SetActive(false);
        }
    }

}
