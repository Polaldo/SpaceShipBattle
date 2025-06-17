using Assets.Scripts.MissionSystem;

public class GainCoinsMission : MissionStep
{
    protected void Start()
    {
        base.Start();
        GameEventsManager.instance.economyEvents.onGalacticalCoinsGained += GalacticalCoinsGained;
        UpdateState();
    }

    protected void OnDisable()
    {
        base.OnDisable();
        GameEventsManager.instance.economyEvents.onGalacticalCoinsGained -= GalacticalCoinsGained;
    }

    private void GalacticalCoinsGained(int coins)
    {
        currentAmount += coins;
        UpdateState();

        if (currentAmount >= requiredAmount)
        {
            currentAmount = requiredAmount;
            UpdateState();
            FinishMissionStep();
            Destroy(gameObject);
        }
    }

    protected override void UpdateState()
    {
        string state = currentAmount.ToString();
        string status = "Coins gained " + currentAmount + " / " + requiredAmount + ".";
        ChangeState(state, status, requiredAmount, currentAmount);
    }

    protected override void SetMissionStepState(string state)
    {
        this.currentAmount = System.Int32.Parse(state);
        UpdateState();
    }
}
