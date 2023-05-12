using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanzarGranadas : MonoBehaviour
{
    public float ThrowForce = 40f;
    public GameObject grenadePrefab;
    public Transform spawnpoint;


    VidaEnemigos Vida;
    int numGrenades = 0;
    Patrulla activado;
    public bool lanzar = false;

    private void Start()
    {
        Vida = GetComponent<VidaEnemigos>();
        activado = GetComponent<Patrulla>();
    }

    private void Update()
    {
        if (activado.estarAlerta && !lanzar)
        {
            ThrowGrenade();
            lanzar = true;
        }

    }
    void ThrowGrenade()
    {

        int numGrenades = 0;
        float vidaPercent = Vida.vida ;

        if (vidaPercent <= 100)
        {
            numGrenades = 1;
        }
        else if (vidaPercent <= 75)
        {
            numGrenades = 2;
        }
        else if (vidaPercent <= 50)
        {
            numGrenades = 3;
        }
        else if (vidaPercent <= 25)
        {
            numGrenades = 4;
        }

        for (int i = 0; i < numGrenades; i++)
        {
            float angle = i * 2f * Mathf.PI / numGrenades; // Divide el c�rculo en partes iguales
            Vector3 direction = new Vector3(Mathf.Sin(angle), 0f, Mathf.Cos(angle)); // Vector que apunta en la direcci�n correspondiente
            Quaternion rotation = Quaternion.LookRotation(direction); // Rotaci�n que apunta en la direcci�n correspondiente
            GameObject grenade = Instantiate(grenadePrefab, spawnpoint.position, rotation); // Instancia la granada con la rotaci�n correspondiente
            Rigidbody rb = grenade.GetComponent<Rigidbody>();
            rb.AddForce(direction * ThrowForce, ForceMode.VelocityChange); // Aplica una fuerza a la granada en la direcci�n correspondiente
        }
        lanzar = false; // establece lanzar en false antes de salir de la funci�n

    }
}
