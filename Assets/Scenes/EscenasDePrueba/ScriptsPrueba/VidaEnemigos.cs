using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaEnemigos : MonoBehaviour
{
    public float vida = 100;
   
    void Update()
    {
        vida = Mathf.Clamp(vida, 0, 100);

        if(vida == 0)
        {
            Destroy(gameObject);
        }
    }
    public void VidaCaida(float cantidad)
    {
        vida += cantidad;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            vida -= 10f;
            Destroy(other.gameObject); // Destruir la bala
        }
    }
}
