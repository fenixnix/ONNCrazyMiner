using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ZoomIn()
    {
        var cam = GetComponent<Camera>();
        cam.orthographicSize += 1;
    }

    public void ZoomOut()
    {
        var cam = GetComponent<Camera>();
        var tmp = cam.orthographicSize - 1;
        if (tmp < 1) { tmp = 1; }
        if (tmp > 8) { tmp = 8; }
        cam.orthographicSize = tmp;
    }
}
