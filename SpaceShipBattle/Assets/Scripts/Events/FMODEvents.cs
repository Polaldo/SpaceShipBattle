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

    [field: Header("SFX sounds")]

    [field: Header("Button click")]
    [field: SerializeField] public EventReference buttonClicked { get; private set; }

    [field: Header("Mission Complete")]
    [field: SerializeField] public EventReference missionComplete { get; private set; }
}
