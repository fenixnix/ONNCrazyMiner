using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NRocket : MonoBehaviour {

    public float m_Damage = 10f;                    // The amount of damage done if the explosion is centred on a tank.
    public float m_Force = 10;                // The amount of force added to a tank at the centre of the explosion.
    public float m_EffactRadius = 1f;                // The maximum distance away from the explosion tanks can be and are still affected.
    public float m_MaxLifeTime = 8f;                    // The time in seconds before the shell is removed.

    public Transform Taget = null;
    public float Force = 0.2f;
    public float DampTime = 1f;
    public float speed = 0.2f;

    bool Track = false;
    Rigidbody rigidBody;
	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
        Invoke("Tracking", 0.5f);
        Destroy(gameObject, m_MaxLifeTime);
    }

    void Tracking()
    {
        Track = true;
    }
	
    public void Sync()
    {
        if ((Taget != null)&&(Track))
        {
            var t = transform.position + (Taget.position - transform.position).normalized;
            transform.LookAt(Taget);      
            transform.position = Vector3.Slerp(transform.position, t, DampTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, Taget.rotation, speed * Time.deltaTime);
        }
        else
        {
            rigidBody.AddForce(transform.forward * Force);
        }
    }

    void FixedUpdate()
    {
        Sync();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("sensor"))
        {
            return;
        }
        Rigidbody targetRigidbody = other.GetComponent<Rigidbody>();
        if (!targetRigidbody)
            return;
        targetRigidbody.AddExplosionForce(m_Force, transform.position, m_EffactRadius);
        //    TankData tagetData = targetRigidbody.GetComponent<TankData>();
        //// If there is no TankHealth script attached to the gameobject, go on to the next collider.
        //if (!tagetData)
        //    return;
        //    // Calculate the amount of damage the target should take based on it's distance from the shell.
        //    float damage = CalculateDamage(targetRigidbody.position);
        //    // Deal this damage to the tank.
        //    tagetData.TakeDamage(damage);
        //}

        Destroy(gameObject);
    }
}
