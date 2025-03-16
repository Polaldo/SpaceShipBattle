public class PlayerHealthController : UnitHealthController
{
    protected override void Awake()
    {
        spaceShipData = PlayerManager.Instance.shipData;
        base.Awake();
    }

    protected override void Kill()
    {
        LevelManager.Instance.GameOver();
    }
}
