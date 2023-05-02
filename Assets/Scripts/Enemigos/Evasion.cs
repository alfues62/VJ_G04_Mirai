using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evasion : MonoBehaviour
{

    public float distanciaMantener = 5f;
    public float velocidad = 5f;
    public Transform jugador;
    public float rangoDeAlerta;
    public LayerMask capaDelJugador;
    public bool estarAlerta;
    public GameObject cubo;
    public bool activar;




    private void Update()
    {
        MantenerDistancia();
    }
    public void MantenerDistancia()
    {
        estarAlerta = Physics.CheckSphere(transform.position, rangoDeAlerta, capaDelJugador);
        if (estarAlerta)
        {
            Vector3 direccionJugador = jugador.position - transform.position;
            direccionJugador.y = 0f;
            Vector3 direccionDistancia = direccionJugador.normalized * distanciaMantener;
            Vector3 nuevaPosicion = transform.position - direccionDistancia; // huir hacia atrás
            transform.rotation = Quaternion.LookRotation(direccionJugador); // mirar hacia atrás
            transform.position = Vector3.MoveTowards(transform.position, nuevaPosicion, velocidad * Time.deltaTime);
            cubo.GetComponent<Renderer>().material.color = Color.blue;
        }
        else
        {
            cubo.GetComponent<Renderer>().material.color = Color.yellow;
        }
    }
}
