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
    public int balasRestantes = 10;

    public CambiarMunicion cm;
    public AmmoDisplay ad;


    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (Time.time > shotRateTime && balasRestantes > 0)
            {
                GameObject newBullet;
                newBullet = Instantiate(bullet, spawnpoint.position, spawnpoint.rotation);
                newBullet.GetComponent<Rigidbody>().AddForce(spawnpoint.forward * shotForce);
                shotRateTime = Time.time + shotRate;
                Destroy(newBullet, 2);
                balasRestantes--;

                if(cm.kunai == true)
                {
                    ad.UpdateAmmoDisplay(balasRestantes);
                }
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemigo"))
        {
            VidaEnemigos vidaEnemigo = collision.gameObject.GetComponent<VidaEnemigos>();
            if (vidaEnemigo != null)
            {
                vidaEnemigo.vida -= 10;
            }
            Destroy(gameObject);
        }
    }
}
