using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Resource
{
    public double currentAmount;

    public double growingRateSeconds;

    public string type;

    private List<ResourceModifier> resourceModifiers = new List<ResourceModifier>();

    public Resource(string type, float growingRateSeconds)
    {
        this.type = type;
        this.growingRateSeconds = growingRateSeconds;
    }

    public double GetGeneratedPerSecond()
    {
        double actualGeneration = growingRateSeconds;
        foreach (ResourceModifier modifier in resourceModifiers)
        {
            if (modifier.canApply(this))
            {
                actualGeneration += modifier.amount;
            }
        }

        return actualGeneration;
    }

    public void AddModifier(ResourceModifier modifier)
    {
        this.resourceModifiers.Add(modifier);
    }
}
