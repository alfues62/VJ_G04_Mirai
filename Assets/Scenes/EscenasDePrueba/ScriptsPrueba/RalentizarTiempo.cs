using UnityEngine;
using System.Collections;

public class TimeSlow : MonoBehaviour
{
    public float slowDownFactor = 0.5f; // Factor de ralentización
    public float slowDownLength = 5f; // Duración de la habilidad de ralentización
    public GameObject player; // Objeto del jugador

    private bool isSlowingDown = false; // Controla si se está ralentizando el tiempo
    private float originalTimeScale; // Guarda el timeScale original

    void Start()
    {
        originalTimeScale = Time.timeScale; // Guarda el timeScale original al inicio
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && !isSlowingDown) // Si se presiona la tecla R y no se está ralentizando
        {
            StartCoroutine(SlowDownTime()); // Empieza la corrutina de ralentización
        }
    }

    IEnumerator SlowDownTime()
    {
        isSlowingDown = true; // Se indica que se está ralentizando el tiempo
        float originalFixedDeltaTime = Time.fixedDeltaTime; // Guarda el fixedDeltaTime original
        Time.timeScale = slowDownFactor; // Se cambia el timeScale a slowDownFactor
        Time.fixedDeltaTime = Time.timeScale * originalFixedDeltaTime; // Se ajusta el fixedDeltaTime

        Rigidbody playerRigidbody = player.GetComponent<Rigidbody>(); // Obtiene el componente Rigidbody del jugador
        float originalPlayerTimeScale = playerRigidbody.angularDrag; // Guarda el angularDrag original del jugador

        while (Time.timeScale > slowDownFactor)
        {
            Time.timeScale -= slowDownFactor * Time.deltaTime / slowDownLength;
            Time.fixedDeltaTime = Time.timeScale * originalFixedDeltaTime; // Ajusta el fixedDeltaTime en cada frame
            playerRigidbody.angularDrag = originalPlayerTimeScale / Time.timeScale; // Ralentiza al jugador dividiendo el valor original por el nuevo timeScale
            yield return null;
        }

        Time.timeScale = originalTimeScale; // Se restaura el timeScale original
        Time.fixedDeltaTime = originalFixedDeltaTime; // Se restaura el fixedDeltaTime original
        playerRigidbody.angularDrag = originalPlayerTimeScale; // Se restaura el angularDrag original del jugador
        isSlowingDown = false; // Se indica que ya no se está ralentizando el tiempo
    }
}
