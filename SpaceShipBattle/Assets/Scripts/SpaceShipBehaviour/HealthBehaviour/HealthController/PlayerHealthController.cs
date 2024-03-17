

using System;

public class PlayerHealthController : UnitHealthController
{
    protected override void Start()
    {
        spaceShipData = PlayerManager.Instance.shipData;
        base.Start();
    }

    protected override void Kill()
    {
        UiManager.Instance.OpenGameOverPannel();
        //TODO: open death menu
    }
}
