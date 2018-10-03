using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NLauncher : MonoBehaviour {
    public GameObject BulletPrefab;
    public Transform Taget;
    public int interval = 5;
    public float force = 100;
    public bool Active = false;

    int cnt = 0;
	// Use this for initialization
	void Start () {
		
	}

    void Launch()
    {
        GameObject bulletInstance = Instantiate(BulletPrefab, transform.position, transform.rotation);
        Rigidbody bulletRigidBody = bulletInstance.GetComponent<Rigidbody>();
        bulletRigidBody.velocity = force * transform.forward;

        var rocket = bulletInstance.GetComponent<NRocket>();
        if (rocket == null) return;
        rocket.Taget = Taget;
    }

    public void Sync()
    {
        if (!Active)
        {
            return;
        }

        if (cnt == interval)
        {
            Launch();
            cnt = 0;
        }
        else
        {
            cnt++;
        }
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        Sync();
	}
}
