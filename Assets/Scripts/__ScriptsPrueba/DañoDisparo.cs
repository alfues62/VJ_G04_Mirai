using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DañoDisparo : MonoBehaviour
{
    VidaEnemigos vida;

    public int cantidad;
    public float damageTime = 1.0f;
    float currentDamageTime;
    private bool hasHit = false;

    void Start()
    {
        vida = GameObject.FindWithTag("Enemy").GetComponent<VidaEnemigos>();
    }
  


}
