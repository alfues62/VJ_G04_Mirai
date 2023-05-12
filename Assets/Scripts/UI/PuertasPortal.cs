using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuertasPortal : MonoBehaviour
{
    [Header("References")]
    public GameObject recogerTexto;

    public KeyCode interactKey = KeyCode.F; // Tecla para interactuar
    private bool canInteract = false; // Variable para controlar si se puede interactuar
    private bool hasInteracted = false; // Variable para ver si ya ha interactuado

    private void Start()
    {
        recogerTexto.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        recogerTexto.SetActive(true);
        SceneManager.LoadScene(3);
        if (Input.GetKeyDown(interactKey))
        {
            Debug.Log("Estoy");
            SceneManager.LoadScene(3);
        }

    }

    void OnTriggerExit(Collider other)
    {
        recogerTexto.SetActive(false);
    }
}
