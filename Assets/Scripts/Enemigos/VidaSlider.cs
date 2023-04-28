using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaSlider : MonoBehaviour
{
    public float health;
    public float maxHealth;

    public GameObject healthBarUI;
    public Slider slider;

    private VidaEnemigos vidaEnemigo;

    // Start is called before the first frame update
    void Start()
    {
        vidaEnemigo = GetComponent<VidaEnemigos>();
        maxHealth = vidaEnemigo.vida;
        health = maxHealth;
        slider.value = calcHealth();

    }

    // Update is called once per frame
    void Update()
    {
        health = vidaEnemigo.vida; // Actualiza el valor de maxHealth
        slider.value = calcHealth();

        if (health < maxHealth)
        {
            healthBarUI.SetActive(true);
        }

        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }

    float calcHealth()
    {
        return health / maxHealth;
    }
}
