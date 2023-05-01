using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RalentizarElTiempo : MonoBehaviour
{
    public float slowDownFactor = 0.5f; // Factor de ralentizaci�n
    public float slowDownLength = 5f; // Duraci�n de la habilidad de ralentizaci�n
    public float playerRadius = 5f; // Radio de la esfera que se utiliza para detectar los objetos que no son el jugador

    private bool isSlowingDown = false; // Controla si se est� ralentizando el tiempo
    private float originalTimeScale; // Guarda el timeScale original
    private GameObject player; // Referencia al objeto del jugador

    void Start()
    {
        originalTimeScale = Time.timeScale; // Guarda el timeScale original al inicio
        player = GameObject.FindGameObjectWithTag("Player"); // Busca el objeto del jugador por su tag
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

        // Obtiene una lista de todos los objetos en la escena que est�n dentro de un radio determinado desde la posici�n del jugador
        Collider[] colliders = Physics.OverlapSphere(player.transform.position, playerRadius);

        // Itera a trav�s de la lista y configura el Time.timeScale de cada objeto que no sea el jugador
        foreach (Collider collider in colliders)
        {
            if (collider.gameObject != player) // Si el objeto no es el jugador
            {
                Rigidbody rb = collider.gameObject.GetComponent<Rigidbody>();
                if (rb != null) // Si el objeto tiene un Rigidbody
                {
                    rb.velocity *= slowDownFactor; // Ralentiza la velocidad del objeto
                    rb.angularVelocity *= slowDownFactor; // Ralentiza la velocidad angular del objeto
                }
            }
        }

        Time.timeScale = slowDownFactor; // Se cambia el timeScale a slowDownFactor
        yield return new WaitForSecondsRealtime(slowDownLength); // Espera slowDownLength segundos (ignorando el timeScale)
        Time.timeScale = originalTimeScale; // Se restaura el timeScale original

        // Itera a trav�s de la lista y configura el Time.timeScale de cada objeto que no sea el jugador
        foreach (Collider collider in colliders)
        {
            if (collider.gameObject != player) // Si el objeto no es el jugador
            {
                Rigidbody rb = collider.gameObject.GetComponent<Rigidbody>();
                if (rb != null) // Si el objeto tiene un Rigidbody
                {
                    rb.velocity /= slowDownFactor; // Restaura la velocidad del objeto
                    rb.angularVelocity /= slowDownFactor; // Restaura la velocidad angular del objeto
                }
            }
        }

        isSlowingDown = false; // Se indica que ya no se est� ralentizando el tiempo
    }
}