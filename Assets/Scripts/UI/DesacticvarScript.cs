using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesacticvarScript : MonoBehaviour
{
    [Header("References")]
    public GameObject recogerTexto;
    public GameObject cosaPlayer;

    public KeyCode interactKey = KeyCode.F; // Tecla para interactuar
    private bool canInteract = false; // Variable para controlar si se puede interactuar
    private bool hasInteracted = false; // Variable para ver si ya ha interactuado

    private void Start()
    {
        recogerTexto.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if(hasInteracted == false)
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
        else 
        {
            recogerTexto.SetActive(false);
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
            // Desactiva el objeto en question
            this.gameObject.SetActive(false);
            hasInteracted = true;
        }

        if(hasInteracted == true)
        {
            cosaPlayer.SetActive(false);
            recogerTexto.SetActive(false);
        }
    }
}
