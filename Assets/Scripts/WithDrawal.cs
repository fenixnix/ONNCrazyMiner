using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class WithDrawal : MonoBehaviour {
    public InputField Addr;
    public InputField Amount;
    public ONNConnector onn;

    public void BtnWithDrawal()
    {
        if (Utils.CheckEthAddr(Addr.text))
        {
            Debug.Log("WithDrawal OK!!!");
            onn.WithDrawal(Addr.text, float.Parse(Amount.text));
        }
        else
        {
            Debug.Log("Invalid ETH Address!!!");
            Addr.text = "Invalid ETH Address!!!";
        }
    }
}
