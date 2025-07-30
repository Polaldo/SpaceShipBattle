using System;

public class PlayerEvents
{
    public event Action onKillPlayer;
    public void KillPlayer()
    {
        if (onKillPlayer != null)
        {
            onKillPlayer();
        }
    }

    public event Action<ComponentShipData> onEquipComponentShip;
    public void EquipComponentShip(ComponentShipData componentShipData)
    {
        if (onEquipComponentShip != null)
        {
            onEquipComponentShip(componentShipData);
        }
    }
}
