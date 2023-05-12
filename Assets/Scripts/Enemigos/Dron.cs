using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dron : MonoBehaviour
{
    public float speed = 5.0f;
    public float shootingDistance = 10.0f;
    public float stoppingDistance = 5.0f;
    public float shootingInterval = 1.0f;
    public float maxFollowDistance = 20.0f;
    public GameObject projectilePrefab;
    public Transform projectileSpawnPoint;

    private Transform player;
    private bool canShoot = true;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        Vector3 direction = player.position - transform.position;
        float distance = direction.magnitude;
        direction.Normalize();

        if (distance > maxFollowDistance)
        {
            return;
        }

        if (distance > stoppingDistance)
        {
            transform.position += direction * speed * Time.deltaTime;
        }

        transform.LookAt(player);

        if (distance < shootingDistance && canShoot)
        {
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        canShoot = false;

        GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, Quaternion.identity);
        Vector3 direction = player.position - projectile.transform.position;
        projectile.transform.rotation = Quaternion.LookRotation(direction);

        yield return new WaitForSeconds(shootingInterval);
        canShoot = true;
    }
}
