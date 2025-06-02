using Assets.Scripts.MissionSystem;
using System;

public class MissionEvents
{
    public event Action<string> onStartMission;

    public void StartMission(string id)
    {
        if (onStartMission != null)
        {
            onStartMission(id);
        }
    }

    public event Action<string> onAdvancedMission;

    public void AdvancedMission(string id)
    {
        if (onAdvancedMission != null)
        {
            onAdvancedMission(id);
        }
    }

    public event Action<string> onFinishMission;

    public void FinishMission(string id)
    {
        if (onFinishMission != null)
        {
            onFinishMission(id);
        }
    }

    public event Action<Mission> onMissionStateChange;

    public void MissionStateChange(Mission mission)
    {
        if (onMissionStateChange != null)
        {
            onMissionStateChange(mission);
        }
    }

    public event Action<string, int, MissionStepState> onMissionStepStateChange;
    public void MissionStepStateChange(string id, int stepIndex, MissionStepState missionStepState)
    {
        if (onMissionStepStateChange != null)
        {
            onMissionStepStateChange(id, stepIndex, missionStepState);
        }
    }
}
