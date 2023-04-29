using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UsarScript : MonoBehaviour
{
    public GameObject recogerTexto;

    public KeyCode interactKey = KeyCode.F; // Tecla para interactuar
    private bool canInteract = false; // Variable para controlar si se puede interactuar

    private void Start()
    {
        recogerTexto.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        recogerTexto.SetActive(true);

        // Comprueba si el objeto que entra en la colisión es el objeto child del jugador
        if (other.gameObject.CompareTag("Key"))
        {
            // Comprueba si hasPicked es verdadero
            if (other.gameObject.GetComponent<UsarRecogidoScript>().hasPicked)
            {
                canInteract = true; // Puede interactuar
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        recogerTexto.SetActive(false);
        // Reinicia la variable de interacción cuando el objeto sale de la colisión
        canInteract = false;
    }

    void Update()
    {
        // Si se puede interactuar y el jugador pulsa la tecla F
        if (canInteract && Input.GetKeyDown(interactKey))
        {
            // Carga la siguiente escena
            SceneManager.LoadScene(1);
        }
    }
}

