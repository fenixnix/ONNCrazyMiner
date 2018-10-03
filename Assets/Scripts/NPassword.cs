using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPassword : MonoBehaviour {

    public InputField inputA;

    public string rawPWD = string.Empty;

    UGUI_MenuSwitch menu;

    private void Start()
    {
        menu = GetComponent<UGUI_MenuSwitch>();
    }

    public void Init()
    {
        rawPWD = string.Empty;
        menu.Show();
    }

    public void Confir()
    {
        rawPWD = inputA.text;
    }

    public bool WaitForInput()
    {
        return rawPWD == string.Empty;
    }
}
