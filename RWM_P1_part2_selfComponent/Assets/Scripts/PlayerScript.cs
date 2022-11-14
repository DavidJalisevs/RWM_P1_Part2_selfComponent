using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private GameObject Player;
    public Rigidbody2D rb;

    private bool isJumping = false;
    public int lives = 3;
   



    // Start is called before the first frame update
    void Start()
    {
        Player = this.gameObject;
        rb = GetComponent<Rigidbody2D>();
    }


   
    // Update is called once per frame
    void Update()
    {
        //scoreText.text = "Score: " + score.ToString();
        if (lives <= 0)

        {
            Destroy(gameObject);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isJumping = false;
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            Destroy(collision.gameObject);
        }
    }

    public void resetPosition()
    {
        transform.position = new Vector3(0, 0, 0);
    }



}
