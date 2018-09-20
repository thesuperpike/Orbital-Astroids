using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controll : MonoBehaviour {
    Rigidbody2D rbody;
    Transform trans;
    public int speed = 100;
    public Bullet bullet;
    private int bulletSpeed = 10;
    private int canShoot = 0;
    // Use this for initialization
    void Start () {
        rbody = gameObject.GetComponent<Rigidbody2D>();
        trans = gameObject.GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update () {
        float force = speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            trans.Rotate(new Vector3(0,0,-force));
            
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            trans.Rotate(new Vector3(0, 0, force));
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            float direction = -(trans.rotation.eulerAngles.z - 90) * Mathf.PI / 180;
            rbody.AddForce(new Vector2(-force * Mathf.Cos(direction), Mathf.Sin(direction) * force));
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            float direction = -(trans.rotation.eulerAngles.z - 90) * Mathf.PI / 180;
            rbody.AddForce(new Vector2(force * Mathf.Cos(direction), -force * Mathf.Sin(direction)));
        }
        if (Input.GetKey(KeyCode.Space) && canShoot-- <= 0)
        {
            float direction = -(trans.rotation.eulerAngles.z - 90) * Mathf.PI / 180;
            GameObject bullet = Instantiate(Resources.Load("Bullet"), new Vector3(trans.position.x - (Mathf.Cos(direction) / 2), trans.position.y + (Mathf.Sin(direction) / 2), 0), Quaternion.identity) as GameObject;
            bullet.GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity + new Vector2(-Mathf.Cos(direction)* bulletSpeed, Mathf.Sin(direction) * bulletSpeed);
            canShoot = 20;
        }
    }
}
