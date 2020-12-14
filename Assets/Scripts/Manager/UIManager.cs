using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class UIManager : MonoBehaviour
{
    private const string FORMAT = "#";

    private ResourceManager resourceManager;

    void Start()
    {
        resourceManager = gameObject.GetComponent<ResourceManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Dictionary<string, Resource> resources = resourceManager.GetResources();

        UpdateResource(resources, UIConstants.GOLD_TEXT, ResourceType.GOLD);
        UpdateResource(resources, UIConstants.ARMY_TEXT, ResourceType.ARMY);

        UpdateArmyCost(resources);
        UpdateGoldCost(resources);
    }

    void UpdateResource(Dictionary<string, Resource> resources,
        string textKey,
        string resourceKey)
    {
        Text resourceText = GameObject.Find(textKey)
            .GetComponent<Text>();
        Resource resource = resources[resourceKey];

        resourceText.text = ResourceFormatter.Format(resource.currentAmount);
    }

    void UpdateArmyCost(Dictionary<string, Resource> resources)
    {
        ArmyResource army = (ArmyResource)resources[ResourceType.ARMY];

        Text armyCost = GameObject.Find(UIConstants.UPGRADE_GOLD_COST)
            .GetComponent<Text>();

        armyCost.text = ResourceFormatter.Format(army.upgradeCost) + " " +
            UIConstants.GOLD_SYMBOL;
    }

    void UpdateGoldCost(Dictionary<string, Resource> resources)
    {
        GoldResource gold = (GoldResource)resources[ResourceType.GOLD];

        Text goldCost = GameObject.Find(UIConstants.UPGRADE_ARMY_COST)
            .GetComponent<Text>();

        goldCost.text = ResourceFormatter.Format(gold.upgradeCost) + " " +
            UIConstants.ARMY_SYMBOL;
    }
}
