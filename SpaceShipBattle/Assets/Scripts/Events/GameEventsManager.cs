using Assets.Scripts.Events;
using UnityEngine;

public class GameEventsManager : MonoBehaviour
{
    public static GameEventsManager instance { get; private set; }

    public EconomyEvents economyEvents;
    public RankEvents rankEvents;
    public LevelEvents levelEvents;
    public MissionEvents missionEvents;
    public PlayerEvents playerEvents;
    public SceneEvents sceneEvents;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Found more than one Game Events Manager in the scene.");
            Destroy(gameObject);
        }
        instance = this;

        // initialize all events
        economyEvents = new EconomyEvents();
        rankEvents = new RankEvents();
        levelEvents = new LevelEvents();
        missionEvents = new MissionEvents();
        playerEvents = new PlayerEvents();
        sceneEvents = new SceneEvents();
    }
}
