using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NTransformFixer : MonoBehaviour {

	// Use this for initialization
	void Start () {
        FixChildrenTransform(transform);
	}

    void FixChildrenTransform(Transform tra)
    {
        tra.gameObject.isStatic = true;
        tra.position = new Vector3(Mathf.Round(tra.position.x), Mathf.Round(tra.position.y), Mathf.Round(tra.position.z));
        foreach (Transform t in tra)
        {
            FixChildrenTransform(t);
        }
    }
}
