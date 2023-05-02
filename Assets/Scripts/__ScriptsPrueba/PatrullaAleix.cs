using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrullaAleix : MonoBehaviour
{
    public Transform[] checkpoints;
    private NavMeshAgent agent;
    private int currentCheckpoint = 0;
    private Patrulla activar;
    private Transform jugador;
    private bool enPersecucion = false;
    private Vector3 ultimaPosicionJugador;
    private int checkpointAnterior = -1;

    void Start()
    {
        activar = GetComponent<Patrulla>();
        agent = GetComponent<NavMeshAgent>();
        jugador = GameObject.FindGameObjectWithTag("Player").transform;
        agent.SetDestination(checkpoints[0].position);
    }

    void Update()
    {
        if (!activar.estarAlerta)
        {
            if (agent.remainingDistance == 0)
            {
                if (enPersecucion)
                {
                    // Vuelve a la patrulla despu�s de dejar de perseguir al jugador
                    currentCheckpoint = (checkpointAnterior + 1) % checkpoints.Length;
                    enPersecucion = false;
                }
                else
                {
                    currentCheckpoint++;
                }
                agent.SetDestination(checkpoints[currentCheckpoint % checkpoints.Length].position);
            }
            else if (enPersecucion)
            {
                agent.SetDestination(ultimaPosicionJugador);
            }
        }
        else
        {
            enPersecucion = true;
            checkpointAnterior = currentCheckpoint;
            ultimaPosicionJugador = jugador.position;
            agent.SetDestination(ultimaPosicionJugador);
            activar.Perseguir();
        }
    }

}