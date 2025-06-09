using Assets.Scripts.MissionSystem;

public class ReachXRank : MissionStep
{
    private void Start()
    {
        GameEventsManager.instance.rankEvents.onRankUpChange += GalacticalCoinsGained;
        currentAmount = PlayerManager.Instance.shipData.currentRank;
        UpdateState();
    }

    private void OnDisable()
    {
        GameEventsManager.instance.rankEvents.onRankUpChange -= GalacticalCoinsGained;
    }

    private void GalacticalCoinsGained(int level)
    {
        currentAmount = level;
        if (currentAmount < requiredAmount)
        {
            UpdateState();
        }

        if (currentAmount >= requiredAmount)
        {
            FinishMissionStep();
        }
    }

    protected override void UpdateState()
    {
        string state = currentAmount.ToString();
        string status = "Rank up to: " + currentAmount + " / " + requiredAmount + ".";
        ChangeState(state, status, requiredAmount, currentAmount);
    }

    protected override void SetMissionStepState(string state)
    {
        this.currentAmount = System.Int32.Parse(state);
        UpdateState();
    }
}
