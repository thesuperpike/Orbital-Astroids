using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controll : MonoBehaviour
{
    private Rigidbody2D rbody;
    private Transform trans;
    private int speed = 20;
    public Bullet bullet;
    private int bulletSpeed = 3;
    private int power = 0;
    private GameObject [] currentBulletQueue;
    private int queueIndex;
    private int damageCounter = 10;
    // Use this for initialization
    void Start()
    {
        damageCounter = 5;
        rbody = gameObject.GetComponent<Rigidbody2D>();
        trans = gameObject.GetComponent<Transform>();
        queueIndex = 0;

        currentBulletQueue = new GameObject[5];
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!UranusClass.gameOver)
        {
            if(Mathf.Abs(GetComponent<Transform>().position.x) > 13 || Mathf.Abs(GetComponent<Transform>().position.y) > 8){
                if (--damageCounter == 0)
                {
                    damageCounter = 5;
                    if (--UranusClass.health == 0)
                    {
                        UranusClass.lost = true;
                        Destroy(gameObject);
                    }
                }
            }
            float force = speed * Time.deltaTime;
            if (Input.GetKey(KeyCode.RightArrow))
            {
                trans.Rotate(new Vector3(0, 0, -force * 7));

            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                trans.Rotate(new Vector3(0, 0, force * 7));
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
            if (Input.GetKey(KeyCode.Space))
            {
                power = Mathf.Min(power + 1, 300);
                float direction = -(trans.rotation.eulerAngles.z - 90) * Mathf.PI / 180;

                Destroy(currentBulletQueue[queueIndex]);

                currentBulletQueue[queueIndex] = Instantiate(Resources.Load("Bullet"), new Vector3(trans.position.x - (Mathf.Cos(direction) / 5), trans.position.y + (Mathf.Sin(direction) / 5), 0), Quaternion.identity) as GameObject;
                currentBulletQueue[queueIndex].GetComponent<Transform>().localScale *= Mathf.Min(1 + ((float)power / 32), 4);
                currentBulletQueue[queueIndex].GetComponent<SpriteRenderer>().color = Color.Lerp(new Color(1 / 6, 1, 0), new Color(1, 1 / 6, 0), ((float)power) / 100);
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                GetComponent<AudioSource>().pitch = Mathf.Max(1 - (float)power / 300, .7f);
                GetComponent<AudioSource>().Play();
                float direction = -(trans.rotation.eulerAngles.z - 90) * Mathf.PI / 180;
                currentBulletQueue[queueIndex].GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity + new Vector2(-Mathf.Cos(direction) * (bulletSpeed + (power >> 5)), Mathf.Sin(direction) * (bulletSpeed + (power >> 5)));
                currentBulletQueue[queueIndex].GetComponent<Bullet>().power = power;
                queueIndex = (queueIndex + 1) % 5;
                power = 0;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag != "Bullet" && collision.collider.tag != "Uranus")
        {
            if(--UranusClass.health == 0)
            {
                UranusClass.lost = true;
                Destroy(gameObject);
            }
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.collider.name == "Uranus" && --damageCounter == 0)
        {
            damageCounter = 5;
            if (--UranusClass.health == 0)
            {
                UranusClass.lost = true;
                Destroy(gameObject);
            }
        }
    }
}
