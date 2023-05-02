using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{

    public static bool Paused = false;
    public GameObject PauseMenuCanvas;


    // Start is called before the first fram
    void Start() {
        Time.timeScale = 1f;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
            if (Paused)
            {
                Play();
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            else {
                Stop();
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
    }

    void Stop() {
        PauseMenuCanvas.SetActive(true);
            Time.timeScale = 0f;
        Paused = true;
    }
   public void Play() {
        PauseMenuCanvas.SetActive(false);
        Time.timeScale = 1f;
        Paused = false;
    }

    public void MainMenuButton()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
