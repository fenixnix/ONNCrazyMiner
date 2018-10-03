using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatScript : MonoBehaviour {
    
    public float floatRange = 0.1f;
    public float floatSpeed = 1.0f;

    Vector3 oriLoc;
    Transform root;
    float frame = 0;
	// Use this for initialization
	void Start () {
        oriLoc = transform.localPosition;
        root = transform;
	}
	
	// Update is called once per frame
	void Update () {
        frame+=0.05f*floatSpeed;
        frame = frame % 360;
        ///float val = (frame - 30) / 60.0f;
        float val = Mathf.Sin(frame)* floatRange;
        root.localPosition = new Vector3(oriLoc.x,oriLoc.y+val,oriLoc.y);
	}
}
