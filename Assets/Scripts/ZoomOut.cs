using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomOut : MonoBehaviour {

	// Use this for initialization
	void Start () {
        InvokeRepeating("ZoomOutCamera", 2f, .2f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void ZoomOutCamera()
    {
        gameObject.GetComponent<Camera>().orthographicSize += .01f;
    }
}
