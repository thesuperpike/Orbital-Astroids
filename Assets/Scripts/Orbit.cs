using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour {
    private Rigidbody2D rbody;
    private Transform trans;
    private float mass;
    // Use this for initialization

    float bigMass = 10;
    //TODO

    void Start()
    {
        rbody = gameObject.GetComponent<Rigidbody2D>();
        trans = gameObject.GetComponent<Transform>();
        mass = rbody.mass;
        if(rbody.velocity.Equals(new Vector2(0, 0)))
        {
            float x = trans.position.x;
            float y = trans.position.y;
            float r = Mathf.Sqrt((x * x) + (y * y))+1;
            rbody.velocity = new Vector2((-Mathf.Sqrt(bigMass) * y / (Mathf.Sqrt(r) * r)), (Mathf.Sqrt(bigMass) * x / (Mathf.Sqrt(r) * r)));
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
