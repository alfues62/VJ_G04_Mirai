using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DispararShuriken : MonoBehaviour

{
    public GameObject bullet;
    public Transform spawnpoint;

    public float shotForce = 1500;
    public float shotRate = 0.5f;

    private float shotRateTime;

    private void Start()
    {
    
    }


    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if(Time.time > shotRateTime)
            {
                GameObject newBullet;

                newBullet = Instantiate(bullet,spawnpoint.position,spawnpoint.rotation);

                newBullet.GetComponent<Rigidbody>().AddForce(spawnpoint.forward*shotForce);

                shotRateTime = Time.time + shotRate;

                Destroy(newBullet, 2);
            }

        }
    }


}
