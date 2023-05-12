using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiarMunicion : MonoBehaviour
{
    private DispararKunai dispararKunai;
    private DispararShuriken dispararShuriken;
    private BombaHumo bombaHumo;
    private LanzarFireball lanzarFireball;

    private AmmoDisplay ad;

    public int ammo;

    public bool shuriken;
    public bool bombhum;
    public bool kunai;
    public bool bola;

    void Start()
    {
        bombaHumo = GetComponent<BombaHumo>();
        dispararKunai = GetComponent<DispararKunai>();
        dispararShuriken = GetComponent<DispararShuriken>();
        lanzarFireball = GetComponent<LanzarFireball>();
        ad = GetComponent<AmmoDisplay>();

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
            ad.UpdateAmmoDisplay(dispararShuriken.municion);
            shuriken = true;
            bombhum = false;
            kunai = false;
            bola = false;


        }
        else if (Input.GetKeyDown(KeyCode.N)) // si se pulsa la tecla 'n'
        {
            // desactivar los otros scripts
            bombaHumo.enabled = false;
            dispararShuriken.enabled = false;
            lanzarFireball.enabled = false;
            // activar el nuevo script para cambiar la munición que se dispara
            dispararKunai.enabled = true;
            ad.UpdateAmmoDisplay(dispararKunai.balasRestantes);
            shuriken = false;
            bombhum = false;
            kunai = true;
            bola = false;
        }
        else if (Input.GetKeyDown(KeyCode.L)) // si se pulsa la tecla 'l'
        {
            // desactivar los otros scripts
            dispararKunai.enabled = false;
            dispararShuriken.enabled = false;
            lanzarFireball.enabled = false;
            // activar el nuevo script para cambiar la munición que se dispara
            bombaHumo.enabled = true;
            ad.UpdateAmmoDisplay(bombaHumo.muni);
            shuriken = false;
            bombhum = true;
            kunai = false;
            bola = false;

        }
        else if (Input.GetKeyDown(KeyCode.K)) // si se pulsa la tecla 'k'
        {
            // desactivar los otros scripts
            dispararKunai.enabled = false;
            dispararShuriken.enabled = false;
            bombaHumo.enabled = false;
            // activar el nuevo script para cambiar la munición que se dispara
            lanzarFireball.enabled = true;
            ad.UpdateAmmoDisplay(lanzarFireball.totalThrows);
            shuriken = false;
            bombhum = false;
            kunai = false;
            bola = true;
        }
    }
}

