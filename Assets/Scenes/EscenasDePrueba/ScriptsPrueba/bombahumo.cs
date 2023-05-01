using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanzarBombaHumo : MonoBehaviour
{
    public float smokeForce = 20f;
    public GameObject smokeBombPrefab;
    public Transform spawnpoint;
    public float smokeDamage = 5f;
    public float smokeDuration = 5f;
    public float smokeRadius = 5f;
    public LayerMask enemyLayer;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            ThrowSmokeBomb();
        }
    }

    void ThrowSmokeBomb()
    {
        GameObject smokeBomb = Instantiate(smokeBombPrefab, spawnpoint.position, Quaternion.identity);
        Rigidbody rb = smokeBomb.GetComponent<Rigidbody>();
        rb.velocity = transform.forward * smokeForce;

        StartCoroutine(DetonateSmokeBomb(smokeBomb));
    }

    IEnumerator DetonateSmokeBomb(GameObject smokeBomb)
    {
        yield return new WaitForSeconds(smokeDuration);

        Collider[] colliders = Physics.OverlapSphere(smokeBomb.transform.position, smokeRadius, enemyLayer);
        foreach (Collider col in colliders)
        {
            VidaEnemigo vida = col.GetComponent<VidaEnemigo>();
            if (vida != null)
            {
                vida.QuitarVida(Mathf.RoundToInt(smokeDamage));

            }
        }

        Destroy(smokeBomb);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, smokeRadius);
    }
}
