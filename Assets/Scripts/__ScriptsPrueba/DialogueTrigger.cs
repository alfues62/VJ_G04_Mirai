using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{

    public Dialogue dialogue;
    public bool autoStart = false;
    public float interactionRange = 2f;
    public bool isInRange = false;
    public float rangoDeAlerta;
    public LayerMask capaDelJugador;

    private void Update()
    {
        isInRange = Physics.CheckSphere(transform.position, interactionRange, capaDelJugador);

        if (isInRange)
        {
            if (autoStart)
            {
                TriggerDialogue();
                AutoStartoff();
            }
            else if (Input.GetKeyDown(KeyCode.F))
                TriggerDialogue();
        }


    }

    public void AutoStartoff()
    {
        autoStart = false;
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

}
