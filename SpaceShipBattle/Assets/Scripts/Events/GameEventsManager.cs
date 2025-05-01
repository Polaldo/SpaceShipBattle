using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventsManager : MonoBehaviour
{
    public static GameEventsManager instance { get; private set; }

    public EconomyEvents economyEvents;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Game Events Manager in the scene.");
            Destroy(gameObject);
        }
        instance = this;

        // initialize all events
        economyEvents = new EconomyEvents();
        DontDestroyOnLoad(gameObject);
    }
}
