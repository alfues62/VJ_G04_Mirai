using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DañoDisparo : MonoBehaviour
{
    Vida playerVida;

    public int cantidad;
    public float damageTime;
    float currentDamageTime;

    void Start()
    {
        playerVida = GameObject.FindWithTag("Enemy").GetComponent<Vida>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            currentDamageTime += Time.deltaTime;
            if (currentDamageTime > damageTime)
            {
                playerVida.vida += cantidad;
                currentDamageTime = 0.0f;
            }
        }

    }
}
