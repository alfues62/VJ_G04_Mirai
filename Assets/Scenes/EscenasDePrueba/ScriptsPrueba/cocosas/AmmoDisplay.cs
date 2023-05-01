using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoDisplay : MonoBehaviour
{
    public Text ammoText;   // Reference to the Text component in the canvas
    public int ammoCount;   // Initial ammo count
    private CambiarMunicion cm;

    void Start()
    {
        UpdateAmmoDisplay();   // Display initial ammo count
        cm = GetComponent<CambiarMunicion>();
    }

    void Update()
    {
        ammoCount = cm.ammo;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (ammoCount > 0)
            {
                ammoCount--;   // Decrease ammo count when space bar is pressed
                UpdateAmmoDisplay();   // Update the display
            }
        }
    }

    void UpdateAmmoDisplay()
    {
        ammoText.text = "Ammo: " + ammoCount.ToString();   // Update the Text component in the canvas
    }
}
