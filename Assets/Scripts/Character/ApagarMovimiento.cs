using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApagarMovimiento : MonoBehaviour
{
    PruebaMovimientoCapsula pruebaMovimientoCapsula;
    DialogueManager estahablando;

    // Start is called before the first frame update
    void Start()
    {
        // Busca el objeto que tiene el DialogueManager en la escena
        estahablando = GameObject.FindObjectOfType<DialogueManager>();
        pruebaMovimientoCapsula = GetComponent<PruebaMovimientoCapsula>();
    }

    // Update is called once per frame
    void Update()
    {
        // Si está hablando el DialogueManager, apaga el movimiento
        if (estahablando.estahablando)
        {
            pruebaMovimientoCapsula.enabled = false;
        }
        else
        {
            pruebaMovimientoCapsula.enabled = true;
        }
    }
}