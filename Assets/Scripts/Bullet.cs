using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    private Vector2 initVel;
    private Vector2 initDir;
    private float delay = 0.4f;
    // Use this for initialization
    void Start () {
        Destroy(gameObject, delay);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag != "Bullet")
        {
            Destroy(gameObject);
        }
    }
}
