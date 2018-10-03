using UnityEngine;

public class NBullet : MonoBehaviour {
    public float m_Damage = 10f;                    // The amount of damage done if the explosion is centred on a tank.
    public float m_Force = 10;                // The amount of force added to a tank at the centre of the explosion.
    public float m_MaxLifeTime = 2f;                    // The time in seconds before the shell is removed.
    public float m_EffactRadius = 1f;                // The maximum distance away from the explosion tanks can be and are still affected.

    private void Start()
    {
        Destroy(gameObject, m_MaxLifeTime);
    }

    private void OnTriggerEnter(Collider other)
    {
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
