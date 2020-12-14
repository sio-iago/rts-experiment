
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ArmyResource : Resource
{
    public double upgradeCost { get; private set; } = 30f;

    protected double upgradeCostFactor = 2.42f;

    protected double upgradeMultiplier = 2.82f;

    public ArmyResource(string type, float growingRateSeconds) :
        base(type, growingRateSeconds)
    {
    }

    public void UpgradeArmy(GoldResource gold)
    {
        if (gold.currentAmount >= upgradeCost)
        {
            // Deduct gold
            gold.currentAmount -= upgradeCost;

            // Update growing rate and multipliers
            growingRateSeconds *= upgradeMultiplier;

            // Update upgrade cost
            upgradeCost *= upgradeCostFactor;
        }
    }
}
