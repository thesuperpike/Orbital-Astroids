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
            UranusClass.score++;
            Vector2 oldVelocity = gameObject.GetComponent<Rigidbody2D>().velocity;
            if (mass == 1)
            {
                Destroy(gameObject);
                
            }
            else if (mass == 2)
            {
                for (int i = 0; i < 3; i++)
                {
                    float randX = Random.Range(-10, 10) / 80f;
                    float randY = Random.Range(-10, 10) / 80f;
                    GameObject newAsteroid = Instantiate(Resources.Load("AsteroidSmall"), new Vector3(GetComponent<Transform>().position.x + randX, GetComponent<Transform>().position.y + randY, 0), Quaternion.identity) as GameObject;
                    newAsteroid.GetComponent<Rigidbody2D>().velocity = new Vector2(randX + oldVelocity.x, randY + oldVelocity.y);
                }
                Destroy(gameObject);
            }
            else if (mass == 3)
            {
                for (int i = 0; i < 3; i++)
                {
                    float randX = Random.Range(-10, 10) / 80f;
                    float randY = Random.Range(-10, 10) / 80f;
                    GameObject newAsteroid = Instantiate(Resources.Load("AsteroidMedium"), new Vector3(GetComponent<Transform>().position.x + randX, GetComponent<Transform>().position.y + randY, 0), Quaternion.identity) as GameObject;
                    newAsteroid.GetComponent<Rigidbody2D>().velocity = new Vector2(randX + oldVelocity.x, randY + oldVelocity.y);
                }
                Destroy(gameObject);
            }
            else if (mass == 4)
            {
                for (int i = 0; i < 5; i++)
                {
                    float randX = Random.Range(-10, 10) / 80f;
                    float randY = Random.Range(-10, 10) / 80f;
                    GameObject newAsteroid = Instantiate(Resources.Load("AsteroidLarge"), new Vector3(GetComponent<Transform>().position.x + randX, GetComponent<Transform>().position.y + randY, 0), Quaternion.identity) as GameObject;
                    newAsteroid.GetComponent<Rigidbody2D>().velocity = new Vector2(randX + oldVelocity.x, randY + oldVelocity.y);
                }
                Destroy(gameObject);
            }
        }
    }
}
