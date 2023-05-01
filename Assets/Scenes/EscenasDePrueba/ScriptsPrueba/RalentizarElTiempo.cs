using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RalentizarElTiempo : MonoBehaviour
{
    public float slowDownFactor = 0.5f; // Factor de ralentización
    public float slowDownLength = 5f; // Duración de la habilidad de ralentización

    private bool isSlowingDown = false; // Controla si se está ralentizando el tiempo
    private float originalTimeScale; // Guarda el timeScale original

    void Start()
    {
        originalTimeScale = Time.timeScale; // Guarda el timeScale original al inicio
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && !isSlowingDown) // Si se presiona la tecla R y no se está ralentizando
        {
            StartCoroutine(SlowDownTime()); // Empieza la corrutina de ralentización
        }
    }

    IEnumerator SlowDownTime()
    {
        isSlowingDown = true; // Se indica que se está ralentizando el tiempo
        Time.timeScale = slowDownFactor; // Se cambia el timeScale a slowDownFactor
        yield return new WaitForSecondsRealtime(slowDownLength); // Espera slowDownLength segundos (ignorando el timeScale)
        Time.timeScale = originalTimeScale; // Se restaura el timeScale original
        isSlowingDown = false; // Se indica que ya no se está ralentizando el tiempo
    }
}
