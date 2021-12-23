using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grenadeThrower : MonoBehaviour
{

    public float throwForce = 40f;
    public GameObject grenadePrefab;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Throwgrenade();
        }
    }

    void Throwgrenade()
    {
        GameObject grenade = Instantiate(grenadePrefab, transform.position, transform.rotation);
        Rigidbody rb = grenade.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * throwForce, ForceMode.VelocityChange);
    }
}