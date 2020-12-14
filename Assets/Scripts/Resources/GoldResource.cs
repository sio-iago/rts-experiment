
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GoldResource : Resource
{
    public float upgradeCost { get; private set; } = 40f;

    protected float upgradeCostFactor = 2.74f;

    protected float upgradeMultiplier = 1.85f;

    public GoldResource(string type, float growingRateSeconds) :
        base(type, growingRateSeconds)
    {
    }

    public void UpgradeGold(ArmyResource armyResource)
    {
        if (armyResource.currentAmount >= upgradeCost)
        {
            // Deduct armies
            armyResource.currentAmount -= upgradeCost;

            // Update growing rate and multipliers
            growingRateSeconds *= upgradeMultiplier;

            // Update upgrade cost
            upgradeCost *= upgradeCostFactor;
        }
    }
}
