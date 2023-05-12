using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float delay = 3f;
    public float radius = 5f;
    public float Force = 20f;
    public GameObject explosionEffect;
    float countdown;
    public bool hasExploded = false;
    private Rigidbody playerRigidbody;
    Vida vidaplayer;




    private void Start()
    {
        vidaplayer = GetComponent<Vida>();
        playerRigidbody = GetComponent<Rigidbody>();
        countdown = delay;
    }

    private void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0f && !hasExploded)
        {
            Explode();
            hasExploded = true;
            LanzarGranadas lanzador = GameObject.FindObjectOfType<LanzarGranadas>();
            lanzador.lanzar = false;
        }
    }

    bool alreadyDamaged = false;

    void Explode()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);

        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(Force, transform.position, radius);
            }

            if (nearbyObject.CompareTag("Player") && !alreadyDamaged)
            {
                float distanceToPlayer = Vector3.Distance(transform.position, nearbyObject.transform.position);
                if (distanceToPlayer <= radius)
                {
                    Vida vidaJugador = nearbyObject.GetComponent<Vida>();
                    vidaJugador.vida -= 20;
                    alreadyDamaged = true;
                }
            }
        }



        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Get the direction from the other object to this object
            Vector3 pushDirection = transform.position - other.transform.position;

            // Normalize the direction vector to make it a unit vector
            pushDirection.Normalize();

            // Apply the push to the player using the Rigidbody.AddForce method
            playerRigidbody.AddForce(pushDirection * Force, ForceMode.Impulse);

        }
    }
}


