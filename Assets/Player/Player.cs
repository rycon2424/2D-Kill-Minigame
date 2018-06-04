using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public float speed;
    public Text timer;
    public Text score;
    public float scoreCount;
    public float timeCount;

    public Transform explosion;
    public Transform blood;

    private bool timerSeconds;

    
	void Start ()
    {
        timerSeconds = true;
        scoreCount = 0;
        timeCount = 120;
	}
	
	void Update ()
    {
        timer.text = timeCount.ToString();
        score.text = scoreCount.ToString();

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector2.up * -speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, 0, 2);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 0, -2);
        }

        if (timerSeconds == true)
        {
            timerSeconds = false;
            StartCoroutine(Second());
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
        if (col.gameObject.tag == "Car")
        {
            Instantiate(explosion, new Vector3(transform.position.x, transform.position.y, transform.position.z - 1), transform.rotation);
            scoreCount = scoreCount + 10;
            Destroy(col.gameObject);
        }

        if (col.gameObject.tag == "Enemy")
        {
            Instantiate(blood, col.transform.position, col.transform.rotation);
            scoreCount = scoreCount + 20;
        }
    }

}
