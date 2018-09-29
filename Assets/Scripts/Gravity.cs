using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour {
    Rigidbody2D rbody;
    Transform trans;
    float mass;

    // Use this for initialization
    void Start () {
        rbody = gameObject.GetComponent<Rigidbody2D>();
        trans = gameObject.GetComponent<Transform>();
        mass = rbody.mass;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void FixedUpdate()
    {
        float x = trans.position.x;
        float y = trans.position.y;
        float distanceSquared = (x * x) + (y * y);
        x = -x / Mathf.Sqrt(distanceSquared);
        y = -y / Mathf.Sqrt(distanceSquared);
        rbody.AddForce(new Vector2(mass * UranusClass.uranusMass * x / distanceSquared,mass * UranusClass.uranusMass * y / distanceSquared));
    }
}
