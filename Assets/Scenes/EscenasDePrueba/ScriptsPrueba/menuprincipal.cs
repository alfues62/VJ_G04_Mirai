using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuprincipal : MonoBehaviour
{
    public void EscenaJuego()
    {
        SceneManager.LoadScene("Jugar");

    }

    public void CargarNivel(string nombreNivel)
    {

        SceneManager.LoadScene(nombreNivel);

    }

    public void Salir()
    {

        Application.Quit();

    }

}
