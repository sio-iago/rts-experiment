using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    ResourceManager resourceManager;

    // Use this for initialization
    void Start()
    {
        resourceManager = gameObject.GetComponent<ResourceManager>();
        resourceManager.RegisterResource(new GoldResource(ResourceType.GOLD, 3));
        resourceManager.RegisterResource(new ArmyResource(ResourceType.ARMY, 2));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
