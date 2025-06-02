using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MissionStepState
{
    public string state;
    public string status;

    public MissionStepState(string state, string status)
    {
        this.state = state;
        this.status = status;
    }

    public MissionStepState()
    {
        this.state = "";
        this.status = "";
    }
}
