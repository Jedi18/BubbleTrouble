using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Ball : MonoBehaviour {

    public SpriteRenderer spriteRenderer;
    public Sprite sprite;

    public float gravity = -1;
    public float bounceHeight = 10;
    public float speed = 0.01f;
    public float speedX = 100f;

    float velocityY = 0;
    int directionX = 1;

	// Use this for initialization
	void Start () {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        velocityY = Mathf.Sqrt(-2 * gravity * bounceHeight);
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
}
