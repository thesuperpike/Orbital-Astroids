using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    private Vector2 initVel;
    private Vector2 initDir;
    private float delay = 0.4f;
    public int power;
    // Use this for initialization
    void Start () {
        Destroy(gameObject, delay);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Bullet" && collision.tag != "Player")
        {
            if (power < 20 || collision.name == "Uranus")
            {
                Destroy(gameObject);
            }
            else
            {
                power = power - 55;
            }
        }
    }
}
