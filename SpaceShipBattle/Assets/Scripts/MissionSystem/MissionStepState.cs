[System.Serializable]
public class MissionStepState
{
    public string state;
    public string status;
    public int required;
    public int current;

    public MissionStepState(string state, string status)
    {
        this.state = state;
        this.status = status;
        this.required = 1;
        this.current = 0;
    }

    public MissionStepState()
    {
        this.state = "";
        this.status = "";
        this.required = 0;
        this.current = 0;
    }

    public MissionStepState(string state, string status, int required, int current)
    {
        this.state = state;
        this.status = status;
        this.required = required;
        this.current = current;
    }
}
