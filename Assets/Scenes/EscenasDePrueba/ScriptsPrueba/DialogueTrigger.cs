using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{

    public Dialogue dialogue;
 
    public float interactionRange = 2f;
    public bool isInRange = false;
    public float rangoDeAlerta;

    public LayerMask capaDelJugador;


    private void Start()
    {

    }


 

    private void Update()
    {

        isInRange = Physics.CheckSphere(transform.position, interactionRange, capaDelJugador);

            if (isInRange && Input.GetKeyDown(KeyCode.F))
        {
       
                TriggerDialogue();
        }
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

}
