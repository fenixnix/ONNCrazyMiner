using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NTextInput : MonoBehaviour {

    public InputField input;

    public string rawDat = string.Empty;

    UGUI_MenuSwitch menu;

    private void Start()
    {
        menu = GetComponent<UGUI_MenuSwitch>();
    }

    public void Init()
    {
        rawDat = string.Empty;
        menu.Show();
    }

    public void Confir()
    {
        rawDat = input.text;
        menu.Hide();
    }

    public bool WaitForInput()
    {
        return rawDat == string.Empty;
    }
}
