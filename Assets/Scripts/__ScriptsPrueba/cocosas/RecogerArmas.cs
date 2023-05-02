using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecogerArmas : MonoBehaviour
{
    public KeyCode collectKey = KeyCode.F;
    public int targetObjectCount = 1;
    public DispararShuriken DispararShuriken;
    public DispararKunai DispararKunai;
    public BombaHumo BombaHumo;
    public AttackHandler DamagesMelee;
    public CambiarMunicion CambiarMunicion;
    private int collectedObjectCount = 0;


    void Start()
    {
        DispararShuriken.enabled = false;
        DispararKunai.enabled = false;
        BombaHumo.enabled = false;
        DamagesMelee.enabled = false;
        CambiarMunicion.enabled = false;

    }

    void Update()
    {
        if (Input.GetKeyDown(collectKey))
        {
            CollectObject();
        }


    }

    void CollectObject()
    {
        GameObject objectToCollect = FindObjectToCollect();
        if (objectToCollect != null)
        {
            Destroy(objectToCollect);
            collectedObjectCount++;

            if (collectedObjectCount >= targetObjectCount)
            {
                DispararKunai.enabled = true;
                DamagesMelee.enabled = true;
                CambiarMunicion.enabled = true;
            }
        }
    }


    GameObject FindObjectToCollect()
    {
        float collectRadius = 2.0f;
        Collider[] nearbyColliders = Physics.OverlapSphere(transform.position, collectRadius);
        foreach (Collider collider in nearbyColliders)
        {
            if (collider.gameObject.CompareTag("Especial"))
            {
                return collider.gameObject;
            }
        }

        return null;
    }
}