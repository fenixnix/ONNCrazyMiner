using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI;

public class NUGUI_Panel : MonoBehaviour,NUGUI_PanelBse {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnEnter()
    {
        gameObject.SetActive(true);
    }

    public void OnExit()
    {
        gameObject.SetActive(false);
    }

    public void OnPause()
    {
        
    }

    public void OnResume()
    {

    }
}
