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
}
