using System;

public class ResourceFormatter
{
    private const string FORMAT = "#.0";

    private const string K = "K";
    private const string M = "M";

    private ResourceFormatter()
    {
    }

    public static string Format(double amount)
    {
        if (amount < 1_000.0)
        {
            return amount.ToString(FORMAT);
        }
        else if (amount > 1000.0 && amount < 1_000_000.0)
        {
            return (amount / 1_000).ToString(FORMAT) + K;
        }
        else
        {
            return (amount / 1_000_000).ToString(FORMAT) + M;
        }
    }
}
