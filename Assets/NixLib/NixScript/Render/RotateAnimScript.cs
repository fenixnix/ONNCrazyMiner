using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAnimScript : MonoBehaviour {

    public bool start = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (start)
        {
            transform.Rotate(new Vector3(0, 1, 0), 3);
        }
        if(transform.localRotation.y <=0)
        {
            start = false;
            transform.localRotation = new Quaternion();
            Destroy(transform.GetComponent<RotateAnimScript>());
        }
	}

    public void Rotate()
    {
        start = true;
    }
}
