 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{

    public float delay = 1f;
    float countdown;
    bool hasExploded = false;
    public GameObject explosionEffect;
    public float radius = 5f;
    public float force = 700f;
    
  



    // Start is called before the first frame update
    void Start()
    {

        countdown = delay;
    }

    // Update is called once per frame
    void Update()
    {

        countdown -= Time.deltaTime;
        if (countdown <= 0f && hasExploded == false)
        {
            Explode();
            hasExploded = true;
        }
    }
    void Explode()
    {

        Instantiate(explosionEffect, transform.position, transform.rotation);

        Collider[] collidersToDestroy = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearbyObject in collidersToDestroy)

        {
            Destructible dest = nearbyObject.GetComponent<Destructible>();
            if (dest != null)
            {
                dest.Destroy();
            }
        }

        Collider[] collidersToMove = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearbyObject in collidersToMove)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(force, transform.position, radius);
            }
            Destroy(this.gameObject);
            
            

        }
           
    }
}