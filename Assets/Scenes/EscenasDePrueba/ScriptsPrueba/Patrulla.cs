using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrulla : MonoBehaviour
{
        public float rangoDeAlerta;

        public LayerMask capaDelJugador;

        public Transform jugador;

      public bool estarAlerta;

        public GameObject cubo;

      public float velocidad;

      public bool activar;

       LanzarGranadas Lanzabomba;


 void Start()
    {
       
    }

 void Update()
    {
        Perseguir();
    }
         private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, rangoDeAlerta);

        }

    public void Perseguir()
    {
        estarAlerta = Physics.CheckSphere(transform.position, rangoDeAlerta, capaDelJugador);
        if (estarAlerta == true)
        {
            //transform. LookAt (jugador);
            Vector3 posJugador = (new Vector3(jugador.position.x, transform.position.y, jugador.position.z));
            transform.LookAt(posJugador);
            transform.position = Vector3.MoveTowards(transform.position, posJugador, velocidad * Time.deltaTime);
            cubo.GetComponent<Renderer>().material.color = Color.blue;
        }
        else
        {
            cubo.GetComponent<Renderer>().material.color = Color.yellow;
        }

    }
    }

