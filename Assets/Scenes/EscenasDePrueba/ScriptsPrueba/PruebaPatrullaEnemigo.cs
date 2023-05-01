using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PruebaPatrullaEnemigo : MonoBehaviour
{
    [SerializeField] Transform[] waypoints;
    Vector3 siguientePosicion;
    float velocidad = 2.0f;
    float distanciaCambio = 0.5f;
    int numerosiguientePosicion = 0;
    void Start()
    {
        siguientePosicion = waypoints[0].position;
    }

    
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, siguientePosicion, velocidad * Time.deltaTime);

        if(Vector3.Distance(transform.position, siguientePosicion) < distanciaCambio)
        {

            numerosiguientePosicion++;

            if(numerosiguientePosicion >= waypoints.Length)
            {
                numerosiguientePosicion = 0;
                siguientePosicion = waypoints[numerosiguientePosicion].position;

            }

        }
    }
}
