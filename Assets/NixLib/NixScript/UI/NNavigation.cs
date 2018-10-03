using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NNavigation : MonoBehaviour {
    public GameObject[] panels;

    public void SetMenu(int index)
    {
        foreach(var p in panels)
        {
            p.SetActive(false);
        }
        panels[index].SetActive(true);
    }
}
