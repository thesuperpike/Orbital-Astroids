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
    private int health;
    private int score;
    private int moonsLeft;
    public Text healthText;
    public Text scoreText;
    public Text moonText;
    // Use this for initialization
    void Start()
    {
        rbody = gameObject.GetComponent<Rigidbody2D>();
        trans = gameObject.GetComponent<Transform>();
        queueIndex = 0;
        health = 10;
        currentBulletQueue = new GameObject[5];
        score = UranusClass.score;
        moonsLeft = UranusClass.MoonsLeft;
        healthText.text = "Health: " + health;
        scoreText.text = "Score: " + score;
        moonText.text = "Moons Left: " + moonsLeft;
    }

    // Update is called once per frame
    void Update()
    {
        if(UranusClass.score != score)
        {
            score = UranusClass.score;
            scoreText.text = "Score: " + score;
        }
        if (UranusClass.MoonsLeft != moonsLeft)
        {
            moonsLeft = UranusClass.MoonsLeft;
            moonText.text = "Moons Left: " + moonsLeft;
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
            currentBulletQueue[queueIndex].GetComponent<Transform>().localScale *= Mathf.Min(1 + ((float)power/32), 4);
            currentBulletQueue[queueIndex].GetComponent<SpriteRenderer>().color = Color.Lerp(new Color(1 / 6, 1, 0), new Color(1, 1/6, 0), ((float)power) / 100);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            float direction = -(trans.rotation.eulerAngles.z - 90) * Mathf.PI / 180;
            currentBulletQueue[queueIndex].GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity + new Vector2(-Mathf.Cos(direction) * (bulletSpeed + (power>>5)), Mathf.Sin(direction) * (bulletSpeed+ (power>>5)));
            currentBulletQueue[queueIndex].GetComponent<Bullet>().power = power;
            queueIndex = (queueIndex + 1) % 5;
            power = 0;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag != "Bullet")
        {
            healthText.text = "Health: " + --health;
            if(health == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
