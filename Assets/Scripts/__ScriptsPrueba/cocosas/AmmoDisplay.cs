using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoDisplay : MonoBehaviour
{
    public Text ammoText;   // Reference to the Text component in the canvas
    public int ammoCount;   // Initial ammo count



    void Start()
    {

    }

    void Update()
    {
        
    }



    public void UpdateAmmoDisplay(int muni)
    {
        ammoText.text = "Ammo: " + muni.ToString();   // Update the Text component in the canvas
    }
}
