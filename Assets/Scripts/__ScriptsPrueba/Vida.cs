using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Vida : MonoBehaviour
{
    public float vida = 100;
    public Image barraDeVida;
    public Retry retry;

    private void Start()
    {
        retry = GetComponent<Retry>();
    }
    void Update()
    {
        vida = Mathf.Clamp(vida, 0, 100);
        barraDeVida.fillAmount = vida / 100;

        if(vida == 0)
        {
            Destroy(gameObject);
            if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                retry.TaskOnClick();
            }
        }

     
    }
   public void VidaCaida(float cantidad)
    {
        vida += cantidad;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyBullet"))
        {
            vida -= 10f; // Reducir la vida en 10
            Destroy(other.gameObject); // Destruir la bala
        }
    }
}


