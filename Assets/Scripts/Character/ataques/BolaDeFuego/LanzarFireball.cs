using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanzarFireball : MonoBehaviour
{
    [Header("References")] // He modificado el script para solucionar el error del spawnpoint
    public GameObject bullet;
    public Transform spawnpoint;

    public float shotForce = 10;
    public float shotRate = 1.75f;

    private float shotRateTime;
    public int totalThrows = 5;

    public CambiarMunicion cm;
    public AmmoDisplay ad;

    public lockOn lok;

    public GameObject obetivo;


    void Start()
    {

    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.V))
        {
            if (Time.time > shotRateTime && totalThrows > 0)
            {
                GameObject newBullet;
                newBullet = Instantiate(bullet, spawnpoint.position, spawnpoint.rotation);
                newBullet.GetComponent<Rigidbody>().AddForce(spawnpoint.forward * shotForce);
                shotRateTime = Time.time + shotRate;
                Destroy(newBullet, 2);
                totalThrows--;

                if (cm.kunai == true)
                {
                    ad.UpdateAmmoDisplay(totalThrows);
                }
            }
        }
        else if (lok.isTargeting == true && Input.GetKeyDown(KeyCode.V))
        {
            obetivo = lok.target;
            GameObject newBullet;
            newBullet = Instantiate(bullet, spawnpoint.position, spawnpoint.rotation);
            Vector3 direction = (obetivo.transform.position - transform.position).normalized;
            newBullet.GetComponent<Rigidbody>().AddForce(direction * shotForce, ForceMode.Force);
            shotRateTime = Time.time + shotRate;
            Destroy(newBullet, 2);
            totalThrows--;

            if (cm.kunai == true)
            {
                ad.UpdateAmmoDisplay(totalThrows);
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
