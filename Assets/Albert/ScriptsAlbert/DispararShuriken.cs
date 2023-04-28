using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DispararShuriken : MonoBehaviour

{
    public GameObject[] bullets;
    public Transform spawnpoint;

    public float shotForce = 1500;
    public float shotRate = 0.5f;
    public float bulletOffset = 0.5f;

    Vector3 adelantar = new Vector3(0, 0, 2);

    private float shotRateTime;

    private void Start()
    {

    }


    void Update()
    
    {
        if (Input.GetButtonDown("Fire1"))
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
                    }
                    else if (i == 1)
                    {
                        newBullet = Instantiate(bullets[i], spawnpoint.position + spawnpoint.forward * (i * bulletOffset), Quaternion.Euler(spawnpoint.rotation.eulerAngles));
                        newBullet.tag = bulletTag;
                        newBullet.GetComponent<Rigidbody>().AddForce((spawnpoint.forward + spawnpoint.right * bulletOffset).normalized * shotForce);
                    }
                    else
                    {
                        newBullet = Instantiate(bullets[i], spawnpoint.position + spawnpoint.forward * (i * bulletOffset), Quaternion.Euler(spawnpoint.rotation.eulerAngles));
                        newBullet.tag = bulletTag;
                        newBullet.GetComponent<Rigidbody>().AddForce((spawnpoint.forward - spawnpoint.right * bulletOffset).normalized * shotForce);
                    }

                    newBullet.GetComponent<Rigidbody>().AddForce(newBullet.transform.forward * shotForce);

               

                    Destroy(newBullet, 2);
                 
                }
                 
                

                shotRateTime = Time.time + shotRate;
            }
        }
    }

  
}