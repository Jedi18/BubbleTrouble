using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setup : MonoBehaviour {

    Camera camera;
    public GameObject boundry;

    // Hardcoded values for left and right
    float scaleX = 145.5721f;
    float scaleY = 62.25f;

	// Use this for initialization
	void Start () {
        camera = Camera.main;
        InstantiateColliders();
	}

    void InstantiateColliders()
    {
        float distY = camera.orthographicSize;
        float distX = distY * camera.aspect;

        // Left
        GameObject tra1 = (GameObject)Instantiate(boundry, new Vector2(-distX - 0.1f, 0), gameObject.transform.rotation);
        tra1.transform.localScale = new Vector2(tra1.transform.localScale.x, scaleY);

        // Right
        GameObject tra2 = (GameObject)Instantiate(boundry, new Vector2(distX + 0.1f, 0), gameObject.transform.rotation);
        tra2.transform.localScale = new Vector2(tra2.transform.localScale.x, scaleY);

        // Up
        GameObject tra3 = (GameObject)Instantiate(boundry, new Vector2(0, distY + 0.1f), gameObject.transform.rotation);
        tra3.transform.localScale = new Vector2(scaleX, tra3.transform.localScale.y);

        // Down
        GameObject tra4 = (GameObject)Instantiate(boundry, new Vector2(0, -distY - 0.1f), gameObject.transform.rotation);
        tra4.transform.localScale = new Vector2(scaleX, tra4.transform.localScale.y);

        Debug.Log(distY);
        Debug.Log(distX);
    }
}
