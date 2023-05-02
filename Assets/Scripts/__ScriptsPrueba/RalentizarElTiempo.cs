using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RalentizarElTiempo : MonoBehaviour
{
    public float slowDownFactor = 0.5f; // Factor de ralentización
    public float slowDownLength = 5f; // Duración de la habilidad de ralentización
    public float playerRadius = 3f; // Radio de la esfera que se utiliza para detectar los objetos que no son el jugador
    public float abilityCooldown = 6f; // Tiempo de enfriamiento de la habilidad

    private bool isSlowingDown = false; // Controla si se está ralentizando el tiempo
    private float originalTimeScale; // Guarda el timeScale original
    private GameObject player; // Referencia al objeto del jugador
    private float abilityTimer = 0f; // Temporizador de enfriamiento de la habilidad

    void Start()
    {
        originalTimeScale = Time.timeScale; // Guarda el timeScale original al inicio
        player = GameObject.FindGameObjectWithTag("Player"); // Busca el objeto del jugador por su tag
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && !isSlowingDown && abilityTimer <= 0f) // Si se presiona la tecla R y no se está ralentizando y no está en enfriamiento
        {
            StartCoroutine(SlowDownTime()); // Empieza la corrutina de ralentización
            abilityTimer = abilityCooldown; // Inicia el enfriamiento
        }

        if (abilityTimer > 0f)
        {
            abilityTimer -= Time.deltaTime; // Reduce el tiempo de enfriamiento
        }
    }

    IEnumerator SlowDownTime()
    {
        isSlowingDown = true;

        Collider[] colliders = Physics.OverlapSphere(player.transform.position, playerRadius);

        foreach (Collider collider in colliders)
        {
            // Check if the collider is NOT the player AND has a Rigidbody component
            if (collider.gameObject.tag != "Player" && collider.gameObject.GetComponent<Rigidbody>() != null)
            {
                Rigidbody rb = collider.gameObject.GetComponent<Rigidbody>();
                rb.velocity *= slowDownFactor;
                rb.angularVelocity *= slowDownFactor;
            }
        }

        Time.timeScale = slowDownFactor;
        yield return new WaitForSecondsRealtime(slowDownLength);
        Time.timeScale = originalTimeScale;

        foreach (Collider collider in colliders)
        {
            // Check if the collider is NOT the player AND has a Rigidbody component
            if (collider.gameObject.tag != "Player" && collider.gameObject.GetComponent<Rigidbody>() != null)
            {
                Rigidbody rb = collider.gameObject.GetComponent<Rigidbody>();
                rb.velocity /= slowDownFactor;
                rb.angularVelocity /= slowDownFactor;
            }
        }

        isSlowingDown = false;
    }

}