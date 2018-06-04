using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Civilians : MonoBehaviour {
    
    public Vector3 thePlayerV3;
    public GameObject player;
    public float speed;
    public BoxCollider2D selfBox;

    private bool alive;

    private void Start()
    {
        alive = true;
        selfBox = gameObject.GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        thePlayerV3 = player.transform.position;

        if (Vector3.Distance(thePlayerV3, transform.position) < 5.5f && alive)
        {
            transform.LookAt(player.transform.position);
            transform.Rotate(new Vector3(0, -90, 180), Space.Self);
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            alive = false;
            selfBox.enabled = false;
            speed = 0;
        }
    }
}
