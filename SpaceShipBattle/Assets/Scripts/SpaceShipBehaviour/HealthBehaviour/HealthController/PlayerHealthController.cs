public class PlayerHealthController : UnitHealthController
{
    protected override void Start()
    {
        spaceShipData = PlayerManager.Instance.shipData;
        base.Start();
    }

    protected override void Kill()
    {
        LevelManager.Instance.GameOver();
    }
}
