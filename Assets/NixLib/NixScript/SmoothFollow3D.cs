using UnityEngine;

public class SmoothFollow3D : MonoBehaviour {
    public Transform taget = null;
    public float m_DampTime = 0.1f;                 // Approximate time for the camera to refocus.
    private Vector3 m_MoveVelocity;                 // Reference velocity for the smooth damping of the position.
    float speed = 6f;

    private void Start()
    {
        
    }

    public void Init()
    {
        transform.parent = null;
    }
    // Update is called once per frame
    void Update () {
        if (transform == null) return;
        transform.position = Vector3.SmoothDamp(transform.position, taget.position, ref m_MoveVelocity, m_DampTime);
        transform.rotation = Quaternion.Slerp(transform.rotation, taget.rotation, speed * Time.deltaTime);
    }
}
