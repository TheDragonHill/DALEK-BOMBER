using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float delay = 1f;
    public float radius = 6f;
    public float force = 700f;

    public GameObject explosionEffect;

    float countdown;
    bool hasExploded = false;

    void Start()
    {
        countdown = delay;
    }

    void Update()
    {
		//Start the Countdown
        countdown -= Time.deltaTime;
        if (countdown <= 0f && !hasExploded)
        {
            Explode();
            hasExploded = true;
        }
    }

	/// <summary>
	/// Add a explosion to the grenade, now they can kill enemys within his range and show a effect 
	/// </summary>
    void Explode()
    {
        //Show effect
        Instantiate(explosionEffect, transform.position, transform.rotation);

        //Get nearby objects
        Collider[] collidersToDestroy = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearbyObject in collidersToDestroy)
        {
            //Damage
            Enemy destruct = nearbyObject.GetComponent<Enemy>();
            if (destruct != null)
            {
                destruct.Destroy();
            }
        }

        Collider[] collidersToMove = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearbyObject in collidersToMove)
        {
            //Add force
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(force, transform.position, radius);
            }
        }

        //Remoce grenade
        Destroy(gameObject);
    }
}
