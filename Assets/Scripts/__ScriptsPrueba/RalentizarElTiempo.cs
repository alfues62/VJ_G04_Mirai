using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RalentizarElTiempo : MonoBehaviour
{
    public float slowDownFactor = 0.3f; // Factor de ralentizaci�n
    public float slowDownLength = 5f; // Duraci�n de la habilidad de ralentizaci�n
    public float playerRadius = 5f; // Radio de la esfera que se utiliza para detectar los objetos que no son el jugador
    public float abilityCooldown = 6f; // Tiempo de enfriamiento de la habilidad

    private bool isSlowingDown = false; // Controla si se est� ralentizando el tiempo
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
        if (Input.GetKeyDown(KeyCode.Z) && !isSlowingDown && abilityTimer <= 0f) // Si se presiona la tecla R y no se est� ralentizando y no est� en enfriamiento
        {
            StartCoroutine(SlowDownTime()); // Empieza la corrutina de ralentizaci�n
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

        // Increase player speed
        float originalPlayerSpeed = player.GetComponent<PruebaMovimientoCapsula>().walkSpeed;
        player.GetComponent<PruebaMovimientoCapsula>().walkSpeed *= (1f / slowDownFactor);

        float originalPlayerMaxSpeed = player.GetComponent<PruebaMovimientoCapsula>().maxYSpeed;
        player.GetComponent<PruebaMovimientoCapsula>().maxYSpeed *= (1f / slowDownFactor);

        float originalPlayerSprint = player.GetComponent<PruebaMovimientoCapsula>().sprintSpeed;
        player.GetComponent<PruebaMovimientoCapsula>().sprintSpeed *= (1f / slowDownFactor);

        float originalPlayerRotationSpeed = player.GetComponent<PruebaMovimientoCapsula>().rotationSpeed;
        player.GetComponent<PruebaMovimientoCapsula>().rotationSpeed *= (1f / slowDownFactor);

        float originalPlayerDashSpeed = player.GetComponent<PruebaMovimientoCapsula>().dashSpeed;
        player.GetComponent<PruebaMovimientoCapsula>().dashSpeed *= (1f / slowDownFactor);

        float originalPlayerCrouchSpeed = player.GetComponent<PruebaMovimientoCapsula>().crouchSpeed;
        player.GetComponent<PruebaMovimientoCapsula>().crouchSpeed *= (1f / slowDownFactor);

        foreach (Collider collider in colliders)
        {
            // Check if the collider is NOT the player AND has a Rigidbody component AND is not the camera
            if (collider.gameObject.tag != "Player" && collider.gameObject.GetComponent<Rigidbody>() != null
                && collider.gameObject.tag != "MainCamera")
            {
                Rigidbody rb = collider.gameObject.GetComponent<Rigidbody>();
                rb.velocity *= slowDownFactor;
                rb.angularVelocity *= slowDownFactor;
            }
        }

        Time.timeScale = slowDownFactor;
        yield return new WaitForSecondsRealtime(slowDownLength);
        Time.timeScale = originalTimeScale;

        // Restore player speed
        player.GetComponent<PruebaMovimientoCapsula>().walkSpeed = originalPlayerSpeed;
        player.GetComponent<PruebaMovimientoCapsula>().maxYSpeed = originalPlayerMaxSpeed;
        player.GetComponent<PruebaMovimientoCapsula>().sprintSpeed = originalPlayerSprint;
        player.GetComponent<PruebaMovimientoCapsula>().rotationSpeed = originalPlayerRotationSpeed;
        player.GetComponent<PruebaMovimientoCapsula>().dashSpeed = originalPlayerDashSpeed;
        player.GetComponent<PruebaMovimientoCapsula>().crouchSpeed = originalPlayerCrouchSpeed;

        foreach (Collider collider in colliders)
        {
            // Check if the collider is NOT the player AND has a Rigidbody component AND is not the camera
            if (collider.gameObject.tag != "Player" && collider.gameObject.GetComponent<Rigidbody>() != null
                && collider.gameObject.tag != "MainCamera")
            {
                Rigidbody rb = collider.gameObject.GetComponent<Rigidbody>();
                rb.velocity /= slowDownFactor;
                rb.angularVelocity /= slowDownFactor;
            }
        }

        isSlowingDown = false;
    }


}