using Assets.Scripts.MissionSystem;

public class ReachXRank : MissionStep
{
    protected new void Start()
    {
        base.Start();
        GameEventsManager.instance.rankEvents.onRankUpChange += ChangeRank;
        currentAmount = PlayerManager.Instance.shipData.currentRank;
        UpdateState();
        ChangeRank(PlayerManager.Instance.shipData.currentRank);
    }

    protected new void OnDisable()
    {
        base.OnDisable();
        GameEventsManager.instance.rankEvents.onRankUpChange -= ChangeRank;
    }

    private void ChangeRank(int level)
    {
        currentAmount = level;
        if (currentAmount <= requiredAmount)
        {
            UpdateState();
        }

        if (currentAmount >= requiredAmount)
        {
            FinishMissionStep();
            Destroy(gameObject);
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
