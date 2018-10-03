using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mute : MonoBehaviour {
    public GameObject audioObject;
    Toggle toggleBtn;
    public void SetAudio()
    {
        audioObject.SetActive(!toggleBtn.isOn);
    }
	// Use this for initialization
	void Start () {
        toggleBtn = GetComponent<Toggle>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
