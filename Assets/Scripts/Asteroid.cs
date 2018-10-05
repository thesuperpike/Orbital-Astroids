using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {
    private float mass;
    private float decay = 0.9f;
    public AudioSource explode;
    // Use this for initialization
    void Start() {
        mass = Mathf.RoundToInt(GetComponent<Rigidbody2D>().mass);
        if (name != "Moon")
        {
            GetComponent<Transform>().Rotate(new Vector3(0, 0, Random.Range(0, 259)));
        }

    }
    // Update is called once per frame
    void Update() {
        if (name == "Moon" || name == "SmallMoon")
        {
            GetComponent<Rigidbody2D>().velocity *= .99997f;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    { 
        UranusClass.score++;
        DestroyAsteroid();    
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.name == "Uranus")
        {
            if(name == "Moon" || name == "SmallMoon")
            {
                UranusClass.lost = true;
                Vector2 oldVelocity = gameObject.GetComponent<Rigidbody2D>().velocity;
                for (int i = 0; i < mass; i++)
                {
                    float randX = Random.Range(-10, 10) / 80f;
                    float randY = Random.Range(-10, 10) / 80f;
                    GameObject newAsteroid = Instantiate(Resources.Load("AsteroidMedium"), new Vector3(GetComponent<Transform>().position.x + randX, GetComponent<Transform>().position.y + randY, 0), Quaternion.identity) as GameObject;
                    newAsteroid.GetComponent<Rigidbody2D>().velocity = new Vector2((randX + oldVelocity.x) * decay, (randY + oldVelocity.y) * decay);
                }
                for (int i = 0; i < mass + 2; i++)
                {
                    float randX = Random.Range(-10, 10) / 80f;
                    float randY = Random.Range(-10, 10) / 80f;
                    GameObject newAsteroid = Instantiate(Resources.Load("AsteroidSmall"), new Vector3(GetComponent<Transform>().position.x + randX, GetComponent<Transform>().position.y + randY, 0), Quaternion.identity) as GameObject;
                    newAsteroid.GetComponent<Rigidbody2D>().velocity = new Vector2((randX + oldVelocity.x) * decay, (randY + oldVelocity.y) * decay);
                }
                for (int i = 0; i < mass -3; i++)
                {
                    float randX = Random.Range(-10, 10) / 80f;
                    float randY = Random.Range(-10, 10) / 80f;
                    GameObject newAsteroid = Instantiate(Resources.Load("SmallMoon"), new Vector3(GetComponent<Transform>().position.x + randX, GetComponent<Transform>().position.y + randY, 0), Quaternion.identity) as GameObject;
                    newAsteroid.GetComponent<Rigidbody2D>().velocity = new Vector2((randX + oldVelocity.x) * decay, (randY + oldVelocity.y) * decay);
                }
            }
            Destroy(gameObject);
        }
        if(collision.collider.name == "Ship")
        {
            DestroyAsteroid();
        }
    }
    private void OnBecameInvisible()
    {

        if (name != "Moon" && UranusClass.score > 0)
        {
            GetComponent<Rigidbody2D>().velocity *= new Vector2(.5f, .5f);
        }
    }
    private void DestroyAsteroid()
    {
        Vector2 oldVelocity = gameObject.GetComponent<Rigidbody2D>().velocity;
        if (mass == 1)
        {
            Destroy(gameObject);

        }
        else if (mass == 2)
        {
            for (int i = 0; i < 2; i++)
            {
                float randX = Random.Range(-10, 10) / 80f;
                float randY = Random.Range(-10, 10) / 80f;
                GameObject newAsteroid = Instantiate(Resources.Load("AsteroidSmall"), new Vector3(GetComponent<Transform>().position.x + randX, GetComponent<Transform>().position.y + randY, 0), Quaternion.identity) as GameObject;
                newAsteroid.GetComponent<Rigidbody2D>().velocity = new Vector2((randX + oldVelocity.x) * decay, (randY + oldVelocity.y) * decay);
            }
            Destroy(gameObject);
        }
        else if (mass == 3)
        {
            UranusClass.moonsLeft--;
            for (int i = 0; i < 2; i++)
            {
                float randX = Random.Range(-10, 10) / 80f;
                float randY = Random.Range(-10, 10) / 80f;
                GameObject newAsteroid = Instantiate(Resources.Load("AsteroidMedium"), new Vector3(GetComponent<Transform>().position.x + randX, GetComponent<Transform>().position.y + randY, 0), Quaternion.identity) as GameObject;
                newAsteroid.GetComponent<Rigidbody2D>().velocity = new Vector2((randX + oldVelocity.x) * decay, (randY + oldVelocity.y) * decay);
            }
            for (int i = 0; i < 3; i++)
            {
                float randX = Random.Range(-10, 10) / 80f;
                float randY = Random.Range(-10, 10) / 80f;
                GameObject newAsteroid = Instantiate(Resources.Load("AsteroidSmall"), new Vector3(GetComponent<Transform>().position.x + randX, GetComponent<Transform>().position.y + randY, 0), Quaternion.identity) as GameObject;
                newAsteroid.GetComponent<Rigidbody2D>().velocity = new Vector2((randX + oldVelocity.x) * decay, (randY + oldVelocity.y) * decay);
            }
            Destroy(gameObject);
        }
        else if (mass == 4)
        {
            UranusClass.moonsLeft--;
            for (int i = 0; i < 2; i++)
            {
                float randX = Random.Range(-10, 10) / 80f;
                float randY = Random.Range(-10, 10) / 80f;
                GameObject newAsteroid = Instantiate(Resources.Load("SmallMoon"), new Vector3(GetComponent<Transform>().position.x + randX, GetComponent<Transform>().position.y + randY, 0), Quaternion.identity) as GameObject;
                newAsteroid.GetComponent<Rigidbody2D>().velocity = new Vector2((randX / 3 + oldVelocity.x) * decay, (randY / 3 + oldVelocity.y) * decay);
                newAsteroid.name = "Moon";
            }
            for (int i = 0; i < 3; i++)
            {
                float randX = Random.Range(-10, 10) / 80f;
                float randY = Random.Range(-10, 10) / 80f;
                GameObject newAsteroid = Instantiate(Resources.Load("AsteroidMedium"), new Vector3(GetComponent<Transform>().position.x + randX, GetComponent<Transform>().position.y + randY, 0), Quaternion.identity) as GameObject;
                newAsteroid.GetComponent<Rigidbody2D>().velocity = new Vector2((randX + oldVelocity.x) * decay, (randY + oldVelocity.y) * decay);
            }
            for (int i = 0; i < 7; i++)
            {
                float randX = Random.Range(-10, 10) / 80f;
                float randY = Random.Range(-10, 10) / 80f;
                GameObject newAsteroid = Instantiate(Resources.Load("AsteroidSmall"), new Vector3(GetComponent<Transform>().position.x + randX, GetComponent<Transform>().position.y + randY, 0), Quaternion.identity) as GameObject;
                newAsteroid.GetComponent<Rigidbody2D>().velocity = new Vector2((randX + oldVelocity.x) * decay, (randY + oldVelocity.y) * decay);
            }
            Destroy(gameObject);
        }
        else if (mass == 5)
        {
            UranusClass.moonsLeft--;
            for (int i = 0; i < 5; i++)
            {
                float randX = Random.Range(-10, 10) / 80f;
                float randY = Random.Range(-10, 10) / 80f;
                GameObject newAsteroid = Instantiate(Resources.Load("SmallMoon"), new Vector3(GetComponent<Transform>().position.x + randX, GetComponent<Transform>().position.y + randY, 0), Quaternion.identity) as GameObject;
                newAsteroid.GetComponent<Rigidbody2D>().velocity = new Vector2((randX / 3 + oldVelocity.x) * decay, (randY / 3 + oldVelocity.y) * decay);
                newAsteroid.name = "Moon";
            }
            for (int i = 0; i < 8; i++)
            {
                float randX = Random.Range(-10, 10) / 80f;
                float randY = Random.Range(-10, 10) / 80f;
                GameObject newAsteroid = Instantiate(Resources.Load("AsteroidMedium"), new Vector3(GetComponent<Transform>().position.x + randX, GetComponent<Transform>().position.y + randY, 0), Quaternion.identity) as GameObject;
                newAsteroid.GetComponent<Rigidbody2D>().velocity = new Vector2((randX + oldVelocity.x) * decay, (randY + oldVelocity.y) * decay);
            }
            for (int i = 0; i < 7; i++)
            {
                float randX = Random.Range(-10, 10) / 80f;
                float randY = Random.Range(-10, 10) / 80f;
                GameObject newAsteroid = Instantiate(Resources.Load("AsteroidSmall"), new Vector3(GetComponent<Transform>().position.x + randX, GetComponent<Transform>().position.y + randY, 0), Quaternion.identity) as GameObject;
                newAsteroid.GetComponent<Rigidbody2D>().velocity = new Vector2((randX + oldVelocity.x) * decay, (randY + oldVelocity.y) * decay);
            }
            Destroy(gameObject);
        }
        else if (mass == 6)
        {
            UranusClass.moonsLeft--;
            for (int i = 0; i < 6; i++)
            {
                float randX = Random.Range(-10, 10) / 80f;
                float randY = Random.Range(-10, 10) / 80f;
                GameObject newAsteroid = Instantiate(Resources.Load("SmallMoon"), new Vector3(GetComponent<Transform>().position.x + randX, GetComponent<Transform>().position.y + randY, 0), Quaternion.identity) as GameObject;
                newAsteroid.GetComponent<Rigidbody2D>().velocity = new Vector2((randX / 3 + oldVelocity.x) * decay, (randY / 3 + oldVelocity.y) * decay);
                newAsteroid.name = "Moon";
            }
            for (int i = 0; i < 12; i++)
            {
                float randX = Random.Range(-10, 10) / 80f;
                float randY = Random.Range(-10, 10) / 80f;
                GameObject newAsteroid = Instantiate(Resources.Load("AsteroidMedium"), new Vector3(GetComponent<Transform>().position.x + randX, GetComponent<Transform>().position.y + randY, 0), Quaternion.identity) as GameObject;
                newAsteroid.GetComponent<Rigidbody2D>().velocity = new Vector2((randX + oldVelocity.x) * decay, (randY + oldVelocity.y) * decay);
            }
            for (int i = 0; i < 9; i++)
            {
                float randX = Random.Range(-10, 10) / 80f;
                float randY = Random.Range(-10, 10) / 80f;
                GameObject newAsteroid = Instantiate(Resources.Load("AsteroidSmall"), new Vector3(GetComponent<Transform>().position.x + randX, GetComponent<Transform>().position.y + randY, 0), Quaternion.identity) as GameObject;
                newAsteroid.GetComponent<Rigidbody2D>().velocity = new Vector2((randX + oldVelocity.x) * decay, (randY + oldVelocity.y) * decay);
            }
            Destroy(gameObject);
        }
    }
}
