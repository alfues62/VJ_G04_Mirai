using System;
using System.Collections.Generic;

public class CooldownTracker
{
    private Dictionary<string, DateTime> cooldowns;

    public CooldownTracker()
    {
        cooldowns = new Dictionary<string, DateTime>();
    }

    public void SetCooldown(string ability, TimeSpan duration)
    {
        cooldowns[ability] = DateTime.Now.Add(duration);
    }

    public bool IsOnCooldown(string ability)
    {
        DateTime cooldownEnd;
        if (cooldowns.TryGetValue(ability, out cooldownEnd))
        {
            return cooldownEnd > DateTime.Now;
        }
        return false;
    }

    public TimeSpan GetRemainingCooldown(string ability)
    {
        DateTime cooldownEnd;
        if (cooldowns.TryGetValue(ability, out cooldownEnd))
        {
            return cooldownEnd - DateTime.Now;
        }
        return TimeSpan.Zero;
    }
}
