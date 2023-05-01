using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsarRecogidoScript : MonoBehaviour
{
    [Header("References")]
    public bool hasPicked;

    void Start()
    {
        hasPicked = false;
    }

    private void Update()
    {
        if (gameObject.activeSelf)
        {
            hasPicked = true;
        }
        else
        {
            hasPicked = false;
        }
    }

}
