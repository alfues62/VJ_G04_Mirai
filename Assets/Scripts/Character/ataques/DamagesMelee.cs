using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagesMelee : MonoBehaviour
{
    [Header("References")]
    public float damage;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemigo"))
        {
            VidaEnemigos vidaEnemigo = other.GetComponent<VidaEnemigos>();
            if (vidaEnemigo != null)
            {
                vidaEnemigo.vida -= damage; // Restar vida al enemigo
            }
        }
    }
}

