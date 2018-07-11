using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {


    [Header("CarOptions")]
    public float speed;
    public float rotateSpeed;
    public float reverseSpeed;
    public SpriteRenderer currentSkin;
    public Sprite[] skins = new Sprite[7];

    [Header("Canvas/Score")]
    public Transform UI;
    public Text timer;
    public Text score;
    public float scoreCount;
    public float timeCount;
    public GameObject gameOver;
    private bool doOnce = true;

    [Header("Particles")]
    public Transform explosion;
    public Transform blood;

    public static float Highscore;
    public static float prevHighscore;
    private bool timerSeconds;

    
	void Start ()
    {
        gameOver.SetActive(false);
        currentSkin = this.gameObject.GetComponent<SpriteRenderer>();
        timerSeconds = true;
        scoreCount = 0;
        timeCount = 135;
        currentSkin.sprite = skins[OnMouseHover.whatCar];
        CarStats();
	}
	
	void Update ()
    {
        timer.text = timeCount.ToString();
        score.text = scoreCount.ToString();

        End();

        if (Tutorial.gameStart)
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector2.up * speed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector2.up * reverseSpeed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(0, 0, rotateSpeed);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(0, 0, -rotateSpeed);
            }
        }

        if (timerSeconds == true)
        {
            timerSeconds = false;
            StartCoroutine(Second());
        }

    }

    void End()
    {
        if (timeCount < 1)
        {
            timeCount = 0;
            if (doOnce)
            {
                Tutorial.gameStart = false;
                Highscore = scoreCount;
                Debug.Log(Highscore);
                Debug.Log(prevHighscore);
                if (Highscore > prevHighscore)
                {
                    Debug.Log("newhighscore");
                    prevHighscore = Highscore;
                }
                Destroy(UI);
                gameOver.SetActive(true);
                doOnce = false;
            }
        }
    }

    void CarStats()
    {
        if (OnMouseHover.whatCar == 0)
        {
            speed = 5.5f;
            rotateSpeed = 2f;
            reverseSpeed = -2.5f;
        }
        if (OnMouseHover.whatCar == 1)
        {
            speed = 4f;
            rotateSpeed = 6;
            reverseSpeed = -1.25f;
        }
        if (OnMouseHover.whatCar == 2)
        {
            speed = 8;
            rotateSpeed = 1.5f;
            reverseSpeed = -2.5f;
        }
        if (OnMouseHover.whatCar == 3)
        {
            speed = 4f;
            rotateSpeed = 2f;
            reverseSpeed = -4;
        }
        if (OnMouseHover.whatCar == 4)
        {
            speed = 4f;
            rotateSpeed = 4.5f;
            reverseSpeed = -4f;
        }
        if (OnMouseHover.whatCar == 5)
        {
            speed = 6.25f;
            rotateSpeed = 2f;
            reverseSpeed = -1.25f;
        }
        if (OnMouseHover.whatCar == 6)
        {
            speed = 6.75f;
            rotateSpeed = 5;
            reverseSpeed = -5;
        }
    }

    IEnumerator Second()
    {
        yield return new WaitForSeconds(1);
        timeCount = timeCount - 1;
        timerSeconds = true;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            Instantiate(blood, col.transform.position, col.transform.rotation);
            scoreCount = scoreCount + 20;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Car")
        {
            Instantiate(explosion, new Vector3(transform.position.x, transform.position.y, transform.position.z - 1), transform.rotation);
            scoreCount = scoreCount + 10;
            Destroy(col.gameObject);
        }
    }

}
