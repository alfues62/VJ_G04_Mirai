using UnityEngine;

public class ObjectCollector : MonoBehaviour
{
    public KeyCode collectKey = KeyCode.F;
    public int targetObjectCount = 10;
    public Behaviour DispararShuriken;
    private int collectedObjectCount = 0;


    void Start()
    {
        DispararShuriken.enabled = false;
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
                DispararShuriken.enabled = true;
            }
        }
    }


    GameObject FindObjectToCollect()
    {
        float collectRadius = 2.0f;
        Collider[] nearbyColliders = Physics.OverlapSphere(transform.position, collectRadius);
        foreach (Collider collider in nearbyColliders)
        {
            if (collider.gameObject.CompareTag("Collectible"))
            {
                return collider.gameObject;
            }
        }

        return null;
    }
}