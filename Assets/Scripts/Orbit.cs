using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour {
    private Rigidbody2D rbody;
    private Transform trans;
    // Use this for initialization
    //TODO

    void Start()
    {
        rbody = gameObject.GetComponent<Rigidbody2D>();
        trans = gameObject.GetComponent<Transform>();
        if (rbody.velocity.Equals(new Vector2(0, 0)))
        {
            float x = trans.position.x;
            float y = trans.position.y;
            float r = Mathf.Sqrt((x * x) + (y * y));
            rbody.velocity = new Vector2((-Mathf.Sqrt(UranusClass.uranusMass) * y / (Mathf.Sqrt(r) * r)), (Mathf.Sqrt(UranusClass.uranusMass) * x / (Mathf.Sqrt(r) * r)));
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ConformToOrbit()
    {
        float x = trans.position.x;
        float y = trans.position.y;
        float r = Mathf.Sqrt((x * x) + (y * y));
        rbody.velocity = new Vector2((-Mathf.Sqrt(UranusClass.uranusMass) * y / (Mathf.Sqrt(r) * r)), (Mathf.Sqrt(UranusClass.uranusMass) * x / (Mathf.Sqrt(r) * r)));
    }
}
