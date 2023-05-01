using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RalentizarElTiempo : MonoBehaviour
{
    public float slowDownFactor = 0.5f; // Factor de ralentizaci�n
    public float slowDownLength = 5f; // Duraci�n de la habilidad de ralentizaci�n

    private bool isSlowingDown = false; // Controla si se est� ralentizando el tiempo
    private float originalTimeScale; // Guarda el timeScale original

    void Start()
    {
        originalTimeScale = Time.timeScale; // Guarda el timeScale original al inicio
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && !isSlowingDown) // Si se presiona la tecla R y no se est� ralentizando
        {
            StartCoroutine(SlowDownTime()); // Empieza la corrutina de ralentizaci�n
        }
    }

    IEnumerator SlowDownTime()
    {
        isSlowingDown = true; // Se indica que se est� ralentizando el tiempo
        Time.timeScale = slowDownFactor; // Se cambia el timeScale a slowDownFactor
        yield return new WaitForSecondsRealtime(slowDownLength); // Espera slowDownLength segundos (ignorando el timeScale)
        Time.timeScale = originalTimeScale; // Se restaura el timeScale original
        isSlowingDown = false; // Se indica que ya no se est� ralentizando el tiempo
    }
}
