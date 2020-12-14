using System;
public class ResourceModifier
{
    public string resourceType { get; private set; } = null;

    public double amount { get; private set; } = 0.0;

    public ResourceModifier(string resourceType, double amount)
    {
        this.resourceType = resourceType;
        this.amount = amount;
    }

    public bool canApply(Resource resource)
    {
        return resource.type.Equals(resourceType);
    }
}
