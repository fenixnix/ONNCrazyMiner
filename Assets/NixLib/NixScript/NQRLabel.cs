using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NQRLabel : MonoBehaviour {
    public CreateQR qr;
    public InputField text;
    public UGUI_MenuSwitch menu;
	// Use this for initialization
	void Start () {
        qr = GetComponent<CreateQR>();
        text = GetComponentInChildren<InputField>();
        menu = GetComponent<UGUI_MenuSwitch>();
	}
	
	public void Set(string str)
    {
        qr.CreatQr(str);
        text.text = str;
        menu.Show();
    }
}
