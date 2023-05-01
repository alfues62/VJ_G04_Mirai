using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiarMunicion : MonoBehaviour
{
    private DispararKunai dispararKunai;
    private DispararShuriken dispararShuriken;
    private BombaHumo bombaHumo;
    private LanzarFireball lanzarFireball;

    public int ammo;

    void Start()
    {
        bombaHumo = GetComponent<BombaHumo>();
        dispararKunai = GetComponent<DispararKunai>();
        dispararShuriken = GetComponent<DispararShuriken>();
        lanzarFireball = GetComponent<LanzarFireball>();

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M)) // si se pulsa la tecla 'm'
        {
            // desactivar los otros scripts
            bombaHumo.enabled = false;
            dispararKunai.enabled = false;
            lanzarFireball.enabled = false;
            // activar el nuevo script para cambiar la munición que se dispara
            dispararShuriken.enabled = true;
            
        }
        else if (Input.GetKeyDown(KeyCode.N)) // si se pulsa la tecla 'n'
        {
            // desactivar los otros scripts
            bombaHumo.enabled = false;
            dispararShuriken.enabled = false;
            lanzarFireball.enabled = false;
            // activar el nuevo script para cambiar la munición que se dispara
            dispararKunai.enabled = true;
            ammo = dispararKunai.balasRestantes;
        }
        else if (Input.GetKeyDown(KeyCode.L)) // si se pulsa la tecla 'l'
        {
            // desactivar los otros scripts
            dispararKunai.enabled = false;
            dispararShuriken.enabled = false;
            lanzarFireball.enabled = false;
            // activar el nuevo script para cambiar la munición que se dispara
            bombaHumo.enabled = true;

        }
        else if (Input.GetKeyDown(KeyCode.K)) // si se pulsa la tecla 'k'
        {
            // desactivar los otros scripts
            dispararKunai.enabled = false;
            dispararShuriken.enabled = false;
            bombaHumo.enabled = false;
            // activar el nuevo script para cambiar la munición que se dispara
            lanzarFireball.enabled = true;
            ammo = lanzarFireball.totalThrows;
        }
    }
}

