using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DispararKunai : MonoBehaviour
{
    public GameObject bullet;
    public Transform spawnpoint;

    public float shotForce = 1500;
    public float shotRate = 0.5f;

    private float shotRateTime;
    private int balasRestantes = 10;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (Time.time > shotRateTime && balasRestantes > 0)
            {
                GameObject newBullet;
                newBullet = Instantiate(bullet, spawnpoint.position, spawnpoint.rotation);
                newBullet.GetComponent<Rigidbody>().AddForce(spawnpoint.forward * shotForce);
                shotRateTime = Time.time + shotRate;
                Destroy(newBullet, 2);
                balasRestantes--;
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemigo"))
        {
            VidaEnemigo vidaEnemigo = collision.gameObject.GetComponent<VidaEnemigo>();
            if (vidaEnemigo != null)
            {
                vidaEnemigo.QuitarVida(20);
            }
            Destroy(gameObject);
        }
    }
}