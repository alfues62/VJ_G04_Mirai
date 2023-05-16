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

    public lockOn lok;

    public GameObject obetivo;


    void Start()
    {

    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.V))
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
        else if(lok.isTargeting == true && Input.GetKeyDown(KeyCode.V))
        {
            Debug.Log("isTargeting: " + lok.isTargeting + ", target: " + lok.target);

            obetivo = lok.target;
            GameObject newBullet;
            newBullet = Instantiate(bullet, spawnpoint.position, spawnpoint.rotation);
            Vector3 direction = (obetivo.transform.position - transform.position).normalized;
            newBullet.GetComponent<Rigidbody>().AddForce(direction * shotForce, ForceMode.Force);
            shotRateTime = Time.time + shotRate;
            Destroy(newBullet, 2);
            balasRestantes--;

            if (cm.kunai == true)
            {
                ad.UpdateAmmoDisplay(balasRestantes);
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
