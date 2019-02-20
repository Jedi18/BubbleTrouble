using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookScript : MonoBehaviour {

    public float hookSpeed = 5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.Translate(Vector2.up * hookSpeed * Time.deltaTime);
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            hookSpeed = 0;
            Invoke("DestroyProj", 0.5f);
        }

        // Ball collision
        if (collision.gameObject.layer == 9)
        {
            collision.gameObject.SendMessage("hookCollided");
            Destroy(gameObject);
        }
    }

    public void DestroyProj()
    {
        Destroy(gameObject);
    }
}
