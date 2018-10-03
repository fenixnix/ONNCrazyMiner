using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothMov : MonoBehaviour {
    public Vector3 dst;
    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;

    // Use this for initialization
    void Start () {
        //dst = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.SmoothDamp(transform.position, dst, ref velocity, smoothTime);
    }

    public void MovTo(Vector3 newPosition, float time = 0.3f)
    {
        smoothTime = time;
        dst = newPosition;
    }
}
