using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookScript : MonoBehaviour {

    public float hookSpeed = 5f;
    public GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
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
            DestroyProj();
        }
    }

    public void DestroyProj()
    {
        player.SendMessage("allowToShoot", true);
        Destroy(gameObject);
    }
}
