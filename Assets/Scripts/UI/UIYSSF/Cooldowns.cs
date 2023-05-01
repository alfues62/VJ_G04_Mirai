using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityCooldownExample : MonoBehaviour
{
    public Image ability1Icon;
    public Image ability2Icon;
    public Image ability3Icon;
    public Image ability4Icon;

    public Text ability1Text;
    public Text ability2Text;
    public Text ability3Text;
    public Text ability4Text;

    private CooldownTracker tracker;

    void Start()
    {
        tracker = new CooldownTracker();
        tracker.SetCooldown("Habilidad 1", TimeSpan.FromSeconds(10));
        tracker.SetCooldown("Habilidad 2", TimeSpan.FromSeconds(5));
        tracker.SetCooldown("Habilidad 3", TimeSpan.FromSeconds(15));
        tracker.SetCooldown("Habilidad 4", TimeSpan.FromSeconds(20));
    }

    void Update()
    {
        tracker.SetCooldown("Habilidad 1", TimeSpan.FromSeconds(10));
        tracker.SetCooldown("Habilidad 2", TimeSpan.FromSeconds(5));
        tracker.SetCooldown("Habilidad 3", TimeSpan.FromSeconds(15));
        tracker.SetCooldown("Habilidad 4", TimeSpan.FromSeconds(20));

        UpdateAbility("Habilidad 1", ability1Icon, ability1Text);
        UpdateAbility("Habilidad 2", ability2Icon, ability2Text);
        UpdateAbility("Habilidad 3", ability3Icon, ability3Text);
        UpdateAbility("Habilidad 4", ability4Icon, ability4Text);
    }

    void UpdateAbility(string ability, Image icon, Text text)
    {
        if (tracker.IsOnCooldown(ability))
        {
            TimeSpan remainingTime = tracker.GetRemainingCooldown(ability);
            text.text = remainingTime.ToString("ss\\.ff");
            float fillAmount = (float)remainingTime.TotalSeconds / (float)tracker.GetRemainingCooldown(ability).TotalSeconds;
            icon.fillAmount = fillAmount;
            icon.color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
        }
        else
        {
            text.text = "Ready!";
            icon.fillAmount = 1.0f;
            icon.color = Color.white;
        }
    }
}
