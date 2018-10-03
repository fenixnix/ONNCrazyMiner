using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NMsgLabel : MonoBehaviour {
    public Text label;
    public Text msg;

    private void Start()
    {
        Invoke("DelLater", 3);
    }

    void DelLater()
    {
        Destroy(transform.gameObject);
    }
}
