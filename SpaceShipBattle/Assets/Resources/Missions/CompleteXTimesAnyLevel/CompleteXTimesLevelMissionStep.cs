using Assets.Scripts.MissionSystem;


public class CompleteXTimesLevelMissionStep : MissionStep
{

    protected void Start()
    {
        base.Start();
        GameEventsManager.instance.levelEvents.onLevelCompleted += LevelCompleted;
        UpdateState();
    }

    protected void OnDisable()
    {
        base.OnDisable();
        GameEventsManager.instance.levelEvents.onLevelCompleted -= LevelCompleted;
    }

    private void LevelCompleted(LevelData levelData)
    {
        if (currentAmount < requiredAmount)
        {
            currentAmount++;
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
        string status = "Level completed " + currentAmount + " / " + requiredAmount + ".";
        ChangeState(state, status, requiredAmount, currentAmount);
    }

    protected override void SetMissionStepState(string state)
    {
        this.currentAmount = System.Int32.Parse(state);
        UpdateState();
    }
}