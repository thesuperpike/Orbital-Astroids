using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomOut : MonoBehaviour {
    int previousScore = 0;
    int counter = 121;

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Transform>().Translate(new Vector3(0,12.1f,0),Space.World);

    }
	
	// Update is called once per frame
	void Update () {
        if(--counter > 0)
        {
            panDown(counter);
            if(counter == 1)
            {
                gameObject.GetComponent<Transform>().position = new Vector3(0,0,-10);
            }
        }
	}

    private void FixedUpdate()
    {
        if(UranusClass.score > previousScore)
        {
            ZoomOutCamera();
            previousScore = UranusClass.score;
        }
    }

    private void ZoomOutCamera()
    {
        gameObject.GetComponent<Camera>().orthographicSize += .01f;
    }
    private void panDown(int counter)
    {
        gameObject.GetComponent<Transform>().Translate(new Vector3(0, -(float)counter/600, 0), Space.World);
    }

}
