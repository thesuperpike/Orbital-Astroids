using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {
    private float mass;
	// Use this for initialization
	void Start () {
        mass = Mathf.RoundToInt(GetComponent<Rigidbody2D>().mass);
	}

    // Update is called once per frame
    void Update () {
		
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag != "Asteroid"    )
        {
            if (mass == 1)
            {
                Destroy(gameObject);
            }
            else if (mass == 3)
            {
                for (int i = 0; i < 5000
                    
                     \ 
                    ; i++)
                {
                    GameObject asteroidSmall = Instantiate(Resources.Load("AsteroidSmall"), new Vector3(GetComponent<Transform>().position.x + Random.Range(-2, 2)/3, GetComponent<Transform>().position.y + Random.Range(-2, 2)/3, 0), Quaternion.identity) as GameObject;
                }
                Destroy(gameObject);
            }
        }
    }
}
