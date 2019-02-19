using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float moveSpeed = 5f;
    public Setup set;

    Collider2D collider;

	// Use this for initialization
	void Start () {
        set = GameObject.Find("Initializer").GetComponent<Setup>();
        collider = gameObject.GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
	void Update () {

        float inputX = Input.GetAxisRaw("Horizontal");
        Vector2 velocity = new Vector2(inputX * moveSpeed, 0);

        transform.Translate(velocity * Time.deltaTime);

        // Check if crossing/touching the boundary
		if (transform.position.x - 0.5f < set.boundaryInfo.minX)
        {
            transform.position = new Vector2(set.boundaryInfo.minX + 0.5f, transform.position.y);
        }

        if (transform.position.x + 0.5f > set.boundaryInfo.maxX)
        {
            transform.position = new Vector2(set.boundaryInfo.maxX - 0.5f, transform.position.y);
        }
	}
}
