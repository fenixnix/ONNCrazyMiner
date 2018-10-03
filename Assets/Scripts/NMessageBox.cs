using System.Collections;
using UnityEngine;

public class NMessageBox : MonoBehaviour
{
    public GameObject msgBoxPrefab;
    public Transform root;

    public void ShowMsgBox(string title, string context)
    {
        var go = Instantiate(msgBoxPrefab, root);
        var label = go.GetComponent<NMsgLabel>();
        label.label.text = title;
        label.msg.text = context;
    }
}

