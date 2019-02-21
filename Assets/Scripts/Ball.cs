using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Ball : MonoBehaviour {

    public SpriteRenderer spriteRenderer;
    public Sprite sprite;
    public GameObject ballPrefab;

    public float gravity = -1;
    public float bounceHeight = 10;
    public float speed = 0.01f;
    public float speedX = 100f;

    // public for debugging purposes
    public float velocityY = 0;
    public int directionX = 1;

	// Use this for initialization
	void Start () {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        // Retain required height (Depends on current height on instantiation)
        float groundY = GameObject.Find("Ground").transform.position.y;
        velocityY = Mathf.Sqrt(-2 * gravity * (bounceHeight - (transform.position.y - groundY)));
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        // Calculating Y velocity
        velocityY += gravity * Time.deltaTime;
        float velY = velocityY * speed;

        // Calculating X velocity
        float velX = speedX * directionX * speed;

        Vector3 finalVelocity = new Vector3(velX,velY);

        transform.Translate(finalVelocity);
	}

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            velocityY = Mathf.Sqrt(-2 * gravity * bounceHeight);
        }else if(collision.gameObject.layer == 10)
        {
            directionX *= -1;
        }
    }

    public void setDirection(int dir)
    {
        if (dir == 1 || dir == -1)
        {
            directionX = dir;
        }
        else
        {
            Debug.Log("Provide correct value for direction (1 or -1)");
        }
    }

    public void reduceJumpHeight(float ballHeight)
    {
        bounceHeight = ballHeight;
    }

    public void hookCollided()
    {
        float ball1Height = bounceHeight / 1.25f;
        float ball2Height = bounceHeight / 1.25f;

        // No disintegration if bounceHeight is less than 6
        if (ball1Height < 7)
        {
            // Because of some minor issues
            Invoke("destroyGameObject", 0.01f);
            return;
        }

        GameObject ball1 = Instantiate(ballPrefab, gameObject.transform.position, gameObject.transform.rotation);

        // Had issues with instantiating at the same time so using coroutine instead to ensure small time gap
        // if wondering why not invoke, it's so that I can pass parameters

        StartCoroutine(instantiateBall(ball2Height));

        ball1.SendMessage("setDirection", directionX * -1);
        ball1.SendMessage("reduceJumpHeight", ball1Height);
        ball1.transform.localScale = ball1.transform.localScale / Mathf.Sqrt(2);
    }

    IEnumerator instantiateBall(float ball2Height)
    {
        yield return new WaitForSeconds(0.01f);
        // Ball 2 direction is to be the same as the parent
        GameObject ball2 = Instantiate(ballPrefab, gameObject.transform.position, gameObject.transform.rotation);
        ball2.SendMessage("reduceJumpHeight", ball2Height);
        ball2.transform.localScale = ball2.transform.localScale / Mathf.Sqrt(2);

        Destroy(gameObject);
    }

    public void destroyGameObject()
    {
        Destroy(gameObject);
    }
}
