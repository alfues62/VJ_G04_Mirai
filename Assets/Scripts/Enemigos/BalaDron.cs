using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaDron : MonoBehaviour
{
    GameObject target;
    public float speed;
    Rigidbody Balaa;

    private void Start()
    {
        Balaa = GetComponent<Rigidbody>();
        target = GameObject.FindGameObjectWithTag("Player");
        Vector3 moveDir = (target.transform.position - transform.position).normalized;
        Balaa.velocity = moveDir * speed;
        Destroy(this.gameObject, 2);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }

}
