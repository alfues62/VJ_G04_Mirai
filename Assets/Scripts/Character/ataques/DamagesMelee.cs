using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagesMelee : MonoBehaviour
{

    private void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            VidaEnemigos vidaEnemigo = other.GetComponent<VidaEnemigos>();
            if (vidaEnemigo != null)
            {
                vidaEnemigo.vida -= 50f; // Restar 10 de vida al enemigo
            }
        }
    }
}

