using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecogerScript : MonoBehaviour
{
    public GameObject recogerTexto;

    void Start()
    {
        recogerTexto.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Entro");
        recogerTexto.SetActive(true);

        if (other.CompareTag("Player"))
        {

            if (Input.GetKey(KeyCode.F))
            {
                Debug.Log("Estoy Pulsando la F Hijo de Puuuuuuuuuuuuta");
                recogerTexto.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Salgo");
        recogerTexto.SetActive(false);
    }
}
