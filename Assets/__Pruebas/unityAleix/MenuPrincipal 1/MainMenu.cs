using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Jugar()
    {
        SceneManager.LoadScene(2);
    }

    public void options()
    {
        SceneManager.LoadScene(5);
    }
    public void adios()
    {
        Application.Quit();
    }
}
