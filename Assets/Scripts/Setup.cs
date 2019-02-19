using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setup : MonoBehaviour {

    Camera camera;
    public GameObject boundry;

    public BoundaryInfo boundaryInfo;

    // Hardcoded values for left and right
    float scaleX = 145.5721f;
    float scaleY = 62.25f;


	// Use this for initialization
	void Awake () {
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

        boundaryInfo.minX = -distX;
        boundaryInfo.maxX = distX;
        boundaryInfo.minY = -distY;
        boundaryInfo.maxY = distY;
    }

    public struct BoundaryInfo
    {
        public float minX;
        public float minY;
        public float maxX;
        public float maxY;
    }
}
