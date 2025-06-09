using Assets.Scripts.MissionSystem;

public class GainCoinsMission : MissionStep
{
    private void Start()
    {
        GameEventsManager.instance.economyEvents.onGalacticalCoinsGained += GalacticalCoinsGained;
        UpdateState();
    }

    private void OnDisable()
    {
        GameEventsManager.instance.economyEvents.onGalacticalCoinsGained -= GalacticalCoinsGained;
    }

    private void GalacticalCoinsGained(int coins)
    {
        if (currentAmount < requiredAmount)
        {
            currentAmount += coins;
            UpdateState();
        }

        if (requiredAmount >= currentAmount)
        {
            FinishMissionStep();
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
