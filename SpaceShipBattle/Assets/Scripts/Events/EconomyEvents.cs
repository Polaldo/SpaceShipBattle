using System;

public class EconomyEvents
{
    public event Action<int> onGalacticalCoinsGained;
    public void GalacticalCoinsGained(int gold)
    {
        if (onGalacticalCoinsGained != null)
        {
            onGalacticalCoinsGained(gold);
        }
    }

    public event Action<int> onGalacticalCoinChange;
    public void GalacticalCoinsChange(int gold)
    {
        if (onGalacticalCoinChange != null)
        {
            onGalacticalCoinChange(gold);
        }
    }

    public event Action<int> onDarkShardGained;
    public void DarkShardGained(int gold)
    {
        if (onDarkShardGained != null)
        {
            onDarkShardGained(gold);
        }
    }

    public event Action<int> onDarkShardChange;
    public void DarkShardChange(int gold)
    {
        if (onDarkShardChange != null)
        {
            onDarkShardChange(gold);
        }
    }
}
