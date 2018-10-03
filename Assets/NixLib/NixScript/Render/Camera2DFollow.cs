using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera2DFollow : MonoBehaviour
{
    Camera camera;
    SmoothMov mov;
    Vector3 taget;
    // Use this for initialization
    void Start()
    {
        camera = GetComponent<Camera>();
        mov = GetComponent<SmoothMov>();
    }

    public void SetTaget(Vector3 t)
    {
        taget = t;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            camera.orthographicSize *= 1.1f;
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            camera.orthographicSize *= 0.9f;
        }

        if (Input.GetMouseButton(2))
        {
            mov.MovTo(camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -10.0f)));
        }
        else
        {
            mov.MovTo(taget);
        }
    }
}

