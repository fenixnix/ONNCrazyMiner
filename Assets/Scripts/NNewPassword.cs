using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NNewPassword : MonoBehaviour {

    public InputField inputA;
    public InputField inputB;

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
        var res = inputA.text == inputB.text;
        if (res)
        {
            //Sent password;
            rawPWD = inputA.text;
        }
    }

    public bool WaitForInput()
    {
        return rawPWD == string.Empty;
    }
}
