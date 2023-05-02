using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoEnemigo : MonoBehaviour
{

    public GameObject[] bullets;
    public Transform spawnpoint;

    public float shotForce = 1500;
    public float shotRate = 0.5f;
    public float bulletOffset = 0.5f;

    Patrulla activarpatrulla;

    Vector3 adelantar = new Vector3(0, 0, 2);

    private float shotRateTime;
    // Start is called before the first frame update
    void Start()
    {
        activarpatrulla = GetComponent<Patrulla>();
    }

    // Update is called once per frame
    void Update()
    {
        if (activarpatrulla.estarAlerta)
        {
            if (Time.time > shotRateTime)
            {
                string bulletTag = "EnemyBullet";
                GameObject newBullet = Instantiate(bullets[0], spawnpoint.position, Quaternion.Euler(spawnpoint.rotation.eulerAngles));
                newBullet.tag = bulletTag;
                newBullet.GetComponent<Rigidbody>().AddForce(spawnpoint.forward * shotForce);
                newBullet.GetComponent<Rigidbody>().AddForce(newBullet.transform.forward * shotForce);
                Destroy(newBullet, 2);

                shotRateTime = Time.time + shotRate;
            }
        }
    
            }
        }
    

