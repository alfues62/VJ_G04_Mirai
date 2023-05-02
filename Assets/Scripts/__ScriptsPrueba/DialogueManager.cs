using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager: MonoBehaviour
{
    public Text nameText;
    public Animator animator;
    public Text dialogueText;
    private Queue<string> sentences;
    public GameObject desactivar;
    PruebaMovimientoCapsula pruebaMovimientoCapsula;
    public bool estahablando;
    // Start is called before the first frame update
    void Start()
    {
        pruebaMovimientoCapsula = GetComponent<PruebaMovimientoCapsula>();
        sentences = new Queue<string>();


    }

    public void StartDialogue(Dialogue dialogue)
    {
        estahablando = true;
        animator.SetBool("IsOpen", true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            DisplayNextSentence();
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        Cursor.lockState = CursorLockMode.None;

        if (sentences.Count == 0)
        {

            EndDialogue();
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";

        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {

        estahablando = false;
        animator.SetBool("IsOpen", false);
        dialogueText.text = ""; // Vaciar el texto de la UI
        sentences.Clear(); // Vaciar la lista de frases
    }


}
