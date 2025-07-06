using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FMODEvents : MonoBehaviour
{

    public static FMODEvents instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Found more than one fmod event");
        }
        else
        {
            instance = this;
        }
    }
    [field: Header("Music")]

    [field: Header("Main menu music")]
    [field: SerializeField] public EventReference mainMenuMusic { get; private set; }

    [field: Header("Boss music")]
    [field: SerializeField] public EventReference bossMusic { get; private set; }

    [field: Header("SFX sounds")]

    [field: Header("Button click")]
    [field: SerializeField] public EventReference buttonClicked { get; private set; }

    [field: Header("Mission complete")]
    [field: SerializeField] public EventReference missionComplete { get; private set; }

    [field: Header("Rank up")]
    [field: SerializeField] public EventReference rankUp { get; private set; }

    [field: Header("Level complete")]
    [field: SerializeField] public EventReference levelComplete { get; private set; }

    [field: Header("Get galactical coin")]
    [field: SerializeField] public EventReference getGalacticalCoin { get; private set; }

    [field: Header("Get power up")]
    [field: SerializeField] public EventReference getPowerUp { get; private set; }

    [field: Header("Boss enters")]
    [field: SerializeField] public EventReference bossEnters { get; private set; }
}
