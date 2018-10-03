using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NGate : MonoBehaviour {
    public GameObject Gate;
    public Vector3 GateOpen;
    Vector3 GateClose;
    Vector3 Velocity = new Vector3();
    public float smoothTime = 2.0f;

    bool toggle = true;//true open; false close;
    bool running = false;

    public void Open()
    {
        toggle = false;
        running = true;
    }

    public void Close()
    {
        toggle = true;
        running = true;
    }

	// Use this for initialization
	void Start () {
        GateClose = Gate.transform.localPosition;
	}
	
    public void Sync()
    {
        if(running)
        {
            Vector3 taget;
            if (toggle) {
                taget = GateOpen;
            }
            else
            {
                taget = GateClose;
            }
            Gate.transform.localPosition = Vector3.SmoothDamp(Gate.transform.localPosition, taget, ref Velocity, smoothTime);
            if ((Gate.transform.localPosition - taget).magnitude < 0.01)
            {
                running = false;
            }
        }
    }

    private void FixedUpdate()
    {
        Sync();
    }

    //// Update is called once per frame
    //void Update () {
    //       Sync();
    //}
}
