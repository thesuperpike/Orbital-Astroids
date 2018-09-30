using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitalCalculator : MonoBehaviour {

    float velocity, r, a, b, c, e = 0, littleOmega, theta, trueAnomaly;
    Vector2 eccentricity;
    public GameObject greenEllipse, blackEllipse;
    //Initialize for efficiency
    float mass;

    // Use this for initialization
    void Start () {
        mass = UranusClass.uranusMass;
	}
	
	// Update is called once per frame
	void Update () {
        velocity = gameObject.GetComponent<Rigidbody2D>().velocity.magnitude;
        r = gameObject.GetComponent<Rigidbody2D>().position.magnitude;

        eccentricity = calculateEccentricityVector(gameObject.GetComponent<Rigidbody2D>().position,
            gameObject.GetComponent<Rigidbody2D>().velocity);
        e = eccentricity.magnitude;

        a = calculateSemiMajorAxisDist();
        b = calculateSemiMinorAxisDist();
        c = calculateCenterOffset();
        littleOmega = calculateLittleOmega();
        Vector3 posVec = new Vector3(c * Mathf.Cos(littleOmega), c * Mathf.Sin(littleOmega), 0);
        Vector3 eulerVec = new Vector3(0, 0, 180 / Mathf.PI * littleOmega);
        greenEllipse.GetComponent<Transform>().position = posVec;
        greenEllipse.GetComponent<Transform>().eulerAngles = eulerVec;
        greenEllipse.GetComponent<Transform>().localScale = new Vector3(a * 2 + 0.04f, b * 2 + 0.04f, 1);

        blackEllipse.GetComponent<Transform>().position = posVec;
        blackEllipse.GetComponent<Transform>().eulerAngles = eulerVec;
        blackEllipse.GetComponent<Transform>().localScale = new Vector3(a * 2 , b * 2 , 1);
    }

    float calculateSemiMajorAxisDist()
    {
        return 1 / ((2 / r) - (velocity * velocity / mass));
    }

    float calculateOmega(Vector2 pos, Vector2 vel)
    {
        return Mathf.Atan(-pos.x / pos.y) - Mathf.Atan(vel.y / vel.x);
    }

    float calculateSemiMinorAxisDist()
    {
        return a * Mathf.Sqrt(1-(e*e));
    }

    float calculateCenterOffset()
    {
        return Mathf.Sqrt((a * a) - (b * b));
    }

    float calculateLittleOmega()
    {
        float lilOmega = Mathf.Atan(eccentricity.y / eccentricity.x) + Mathf.PI;
        if(eccentricity.x < 0)
        {
            lilOmega += Mathf.PI;
        }
        return lilOmega;
    }

    Vector2 calculateEccentricityVector(Vector2 pos, Vector2 vel)
    {
        return (((Vector2.Dot(vel, vel) * pos) - (Vector2.Dot(pos, vel)*vel))/mass) - (pos / pos.magnitude);
    }
}
