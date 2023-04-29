using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecogerScript : MonoBehaviour
{
    public GameObject recogerTexto;
    public GameObject objetoPlayer;
    public bool hasPicked;

    void Start()
    {
        recogerTexto.SetActive(false);
        objetoPlayer.SetActive(false);
        hasPicked = false;
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            recogerTexto.SetActive(true);


            if (Input.GetKey(KeyCode.F))
            {
                hasPicked = true;
                this.gameObject.SetActive(false);
                recogerTexto.SetActive(false);
                objetoPlayer.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        recogerTexto.SetActive(false);
    }
}
