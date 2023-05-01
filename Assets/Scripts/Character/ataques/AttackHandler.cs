using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHandler : MonoBehaviour
{
    public float jumpDamage = 30f; // Daño al saltar
    public float groundDamage = 50f; // Daño en el suelo
    public float chargeDamage = 60f; // Daño al Cargar

    public DamagesMelee dm;
    public PruebaMovimientoCapsula pm;

    // Start is called before the first frame update
    void Start()
    {
        pm = GetComponent<PruebaMovimientoCapsula>();
        dm = GetComponent<DamagesMelee>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!pm.grounded)
        {
            dm.damage = jumpDamage;
        }
        else if(pm.isSprinting == true)
        {
            dm.damage = chargeDamage;
        }
        else
        {
            dm.damage = groundDamage;
        }
    }

}
