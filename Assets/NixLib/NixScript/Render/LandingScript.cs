using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandingScript : MonoBehaviour {

    // Use this for initialization
    void Start () {
        transform.localPosition = new Vector3(0, 1, -0.1f);
        transform.gameObject.AddComponent<SpindleScript>();
        var smov = transform.gameObject.AddComponent<SmoothMov>();
        smov.MovTo(transform.parent.transform.position, 1);
        Invoke("SelfKill", 3);
    }
	
	// Update is called once per frame
	void Update () {

    }

    void SelfKill()
    {
        transform.localRotation = new Quaternion();
        Destroy(GetComponent<SpindleScript>());
        Destroy(GetComponent<SmoothMov>());
        Destroy(GetComponent<LandingScript>());
    }
}
