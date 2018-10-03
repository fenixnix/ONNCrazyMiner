using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NAimAt : MonoBehaviour {
    public Transform Taget = null;
    public bool LockX = false;
    public bool LockY = false;
    public bool LockZ = false;
    // Use this for initialization
    void Start () {
		
	}
	
    void Sync()
    {
        Vector3 t = Taget.position;
        if (LockX) t.x = transform.position.x;
        if (LockY) t.y = transform.position.y;
        if (LockZ) t.z = transform.position.z;
        transform.LookAt(t);
    }

	// Update is called once per frame
	void Update () {
        if(Taget == null)
        {
            return;
        }
        Sync();
	}
}
