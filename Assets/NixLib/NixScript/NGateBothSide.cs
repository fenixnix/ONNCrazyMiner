using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NGateBothSide : MonoBehaviour {
    public NGate[] gates;

	// Use this for initialization
	void Start () {
        gates = GetComponents<NGate>();
	}
	
    public void Open()
    {
        foreach(var g in gates)
        {
            g.Open();
        }
    }

    public void Close()
    {
        foreach (var g in gates)
        {
            g.Close();
        }
    }
}
