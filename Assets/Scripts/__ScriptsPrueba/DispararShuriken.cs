using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DispararShuriken : MonoBehaviour

{
    public GameObject[] bullets;
    public Transform spawnpoint;


    private bool hasCollided = false;
    private Rigidbody rb;

    public float shotForce = 1500;
    public float shotRate = 0.5f;
    public float bulletOffset = 0.5f;
    public int municion;

    Vector3 adelantar = new Vector3(0, 0, 2);

    private float shotRateTime;

    public CambiarMunicion cm;
    public AmmoDisplay ad;



    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (!hasCollided)
    //    {
    //        hasCollided = true;
    //        rb.useGravity = true;
    //    }
    //}

    private void disparos()
    {
        if (Time.time > shotRateTime)
        {
            for (int i = 0; i < 3; i++)
            {
                string bulletTag = "PlayerBullet";
                GameObject newBullet;

                if (i == 0)
                {
                    newBullet = Instantiate(bullets[i], spawnpoint.position + spawnpoint.forward * (i * bulletOffset), Quaternion.Euler(spawnpoint.rotation.eulerAngles));
                    newBullet.tag = bulletTag;
                    newBullet.GetComponent<Rigidbody>().AddForce(spawnpoint.forward * shotForce);
                    municion--;
                    Destroy(newBullet, 5f);

                }
                else if (i == 1)
                {
                    newBullet = Instantiate(bullets[i], spawnpoint.position + spawnpoint.forward * (i * bulletOffset), Quaternion.Euler(spawnpoint.rotation.eulerAngles));
                    newBullet.tag = bulletTag;
                    newBullet.GetComponent<Rigidbody>().AddForce((spawnpoint.forward + spawnpoint.right * bulletOffset).normalized * shotForce);
                    municion--;
                    Destroy(newBullet, 5f);
                }
                else
                {
                    newBullet = Instantiate(bullets[i], spawnpoint.position + spawnpoint.forward * (i * bulletOffset), Quaternion.Euler(spawnpoint.rotation.eulerAngles));
                    newBullet.tag = bulletTag;
                    newBullet.GetComponent<Rigidbody>().AddForce((spawnpoint.forward - spawnpoint.right * bulletOffset).normalized * shotForce);
                    municion--;
                    Destroy(newBullet, 5f);
                }

                newBullet.GetComponent<Rigidbody>().AddForce(newBullet.transform.forward * shotForce);




            }


            shotRateTime = Time.time + shotRate;
        }
    }

    void Update()
    {
        
        if(municion != 0)
        {
            if (Input.GetKeyDown(KeyCode.V))
                disparos();

            if(cm.shuriken == true)
            {
                ad.UpdateAmmoDisplay(municion);
            }
        }
        else
        {

        }
    }

  
}
