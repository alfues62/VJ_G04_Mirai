using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrullaEvasion : MonoBehaviour
{
    public Transform[] checkpoints;
    private NavMeshAgent agent;
    private int currentCheckpoint = 0;
    private Evasion activar;
    private Transform jugador;
    private bool enPersecucion = false;
    private Vector3 ultimaPosicionJugador;
    private int checkpointAnterior = -1;

    void Start()
    {
        activar = GetComponent<Evasion>();
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
                    // Vuelve a la patrulla después de dejar de perseguir al jugador
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
                activar.MantenerDistancia();
            }
        }
        else
        {
            enPersecucion = true;
            checkpointAnterior = currentCheckpoint;
            ultimaPosicionJugador = jugador.position;
            agent.SetDestination(ultimaPosicionJugador);
            activar.MantenerDistancia();
        }
    }

}
