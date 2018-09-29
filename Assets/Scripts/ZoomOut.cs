using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomOut : MonoBehaviour {
    int previousScore = 0;
	// Use this for initialization
	void Start () {
        //InvokeRepeating("ZoomOutCamera", 2f, .2f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        if(UranusClass.score > previousScore)
        {
            ZoomOutCamera();
            previousScore = UranusClass.score;
        }
    }

    void ZoomOutCamera()
    {
        gameObject.GetComponent<Camera>().orthographicSize += .01f;
    }
}
