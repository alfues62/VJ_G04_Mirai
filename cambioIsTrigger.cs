using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cambioIsTrigger : MonoBehaviour
{
    public int numero;

    private void OnTriggerEnter(Collider tag)
    {
        if(tag.tag == "Player")
        {
            SceneManager.LoadScene(numero);
        }
    }
}
