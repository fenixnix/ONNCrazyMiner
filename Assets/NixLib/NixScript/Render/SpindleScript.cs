using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpindleScript : MonoBehaviour {
    int angle = 0;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        angle++;
        angle = angle % 30;
        transform.Rotate(new Vector3(0, 1, 0), 5);
    }
}
