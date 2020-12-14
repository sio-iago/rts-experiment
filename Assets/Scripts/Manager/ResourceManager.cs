using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    private Dictionary<string, Resource> resources = new Dictionary<string, Resource>();

    // Use this for initialization
    void Start()
    {
        // Load saved list later
    }

    // Update is called once per frame
    void Update()
    {
        float secondFraction = Time.deltaTime % 60;

        foreach (Resource res in resources.Values)
        {
            res.currentAmount += res.GetGeneratedPerSecond() * secondFraction;
        }
    }

    public void RegisterResource(Resource resource)
    {
        resources.Add(resource.type, resource);
    }

    public Dictionary<string, Resource> GetResources()
    {
        return resources;
    }


    public void UpgradeArmy()
    {
        ArmyResource army = (ArmyResource)resources[ResourceType.ARMY];
        army.UpgradeArmy((GoldResource)resources[ResourceType.GOLD]);
    }

    public void UpgradeGold()
    {
        GoldResource gold = (GoldResource)resources[ResourceType.GOLD];
        gold.UpgradeGold((ArmyResource)resources[ResourceType.ARMY]);
    }

    public void AddResourceModifier(ResourceModifier modifier)
    {
        Resource resource = resources[modifier.resourceType];
        resource.AddModifier(modifier);
    }
}
