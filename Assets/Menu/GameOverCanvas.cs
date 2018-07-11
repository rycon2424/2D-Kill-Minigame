using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverCanvas : MonoBehaviour {

    public Text currentScore;

    void Start()
    {
        currentScore.text = Player.Highscore.ToString();
    }

    void Update()
    {

    }

    public void BackToMain()
    {
        SceneManager.LoadScene("Menu_And_Select");
    }

}
