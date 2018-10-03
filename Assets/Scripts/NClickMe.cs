using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NClickMe : MonoBehaviour {

    bool isShaking = false;
    int count = 0;
	// Use this for initialization
	void Start () {
        InvokeRepeating("Shake", 1, 3);
	}
	
	// Update is called once per frame
	void Update () {
        if (!isShaking) return;
        var val = Random.Range(-6, 6);
        this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, val));
        count--;
        if(count <= 0)
        {
            this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            isShaking = false;
        }
	}

    void Shake()
    {
        isShaking = true;
        count = 30;
    }
}
