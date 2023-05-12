using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombaHumo : MonoBehaviour
{
    public float smokeForce = 20f;
    public GameObject smokeBombPrefab;
    public Transform spawnpoint;
    public float smokeDamage = 5f;
    public float smokeDuration = 5f;
    public float smokeRadius = 5f;
    public LayerMask enemyLayer;
    public GameObject smokeExplosionPrefab;

    public int muni;

    public CambiarMunicion cm;
    public AmmoDisplay ad;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && muni > 0)
        {
            ThrowSmokeBomb();
            muni--;

            if(cm.bombhum == true)
            {
                ad.UpdateAmmoDisplay(muni);
            }
        }
    }

    void ThrowSmokeBomb()
    {
        GameObject smokeBomb = Instantiate(smokeBombPrefab, spawnpoint.position, spawnpoint.rotation);
        Rigidbody rb = smokeBomb.GetComponent<Rigidbody>();
        rb.AddForce(smokeBomb.transform.forward * smokeForce, ForceMode.VelocityChange);

        StartCoroutine(DetonateSmokeBomb(smokeBomb));
    }

    IEnumerator DetonateSmokeBomb(GameObject smokeBomb)
    {
        // Wait for explosion
        yield return new WaitForSeconds(3f);

        // Instantiate smoke explosion effect
        GameObject smokeExplosion = Instantiate(smokeExplosionPrefab, smokeBomb.transform.position, Quaternion.identity);

        // Loop for smoke duration
        float timeElapsed = 0f;
        while (timeElapsed < smokeDuration)
        {
            // Get all colliders within smoke radius
            Collider[] colliders = Physics.OverlapSphere(smokeBomb.transform.position, smokeRadius, enemyLayer);

            // Deal damage to each enemy within the radius
            foreach (Collider col in colliders)
            {
                Vida vida = col.GetComponent<Vida>();
                if (vida != null)
                {
                    vida.vida -= (smokeDamage * Time.deltaTime);
                }
                VidaEnemigos vida2 = col.GetComponent<VidaEnemigos>();
                if (vida != null)
                {
                    vida2.vida -= (smokeDamage * Time.deltaTime);
                }
            }

            // Wait for one frame
            yield return null;

            // Increment time elapsed
            timeElapsed += Time.deltaTime;
        }

        // Destroy smoke explosion effect
        Destroy(smokeExplosion);

        // Destroy smoke bomb
        Destroy(smokeBomb);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, smokeRadius);
    }
}


