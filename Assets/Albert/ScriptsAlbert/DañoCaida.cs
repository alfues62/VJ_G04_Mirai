using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DañoCaida : MonoBehaviour
{
    [SerializeField] float allowedYSpeed;
    Rigidbody rb;
    [SerializeField] float speedBeforeLanding;

    public float groundDistance = 0.4f;
    public LayerMask groundMask;
     bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundDistance, groundMask);
    }

    void FixedUpdate()
    {
        if (!isGrounded)
        {
            speedBeforeLanding = rb.velocity.y;
        }
        else
        {
            if (speedBeforeLanding < allowedYSpeed)
            {
                Debug.Log("Caidaaaa");
                GetComponent<Vida>().VidaCaida(-20);
                speedBeforeLanding = 0;
            }
        }
    }
}
