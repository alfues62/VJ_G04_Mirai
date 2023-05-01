using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaEnemigo : MonoBehaviour
{
    public int vidaMaxima = 100;
    private int vidaActual;

    private void Start()
    {
        vidaActual = vidaMaxima;
    }

    public void QuitarVida(int cantidad)
    {
        vidaActual -= cantidad;
        if (vidaActual <= 0)
        {
            Morir();
        }
    }

    private void Morir()
    {
        // Aquí puede agregar la lógica que desea ejecutar cuando el enemigo muere, como reproducir una animación o generar efectos de partículas.
        Destroy(gameObject);
    }
}