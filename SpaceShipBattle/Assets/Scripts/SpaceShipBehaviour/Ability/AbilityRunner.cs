using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Assets.Scripts.SpaceShipBehaviour.Ability.AbilityWeaponBehaviour;

public class AbilityRunner : MonoBehaviour
{
    IAbility currentAbility;

    private void Start()
    {
        currentAbility = GetComponent<IAbility>();
    }

    void Update()
    {
        if(InputManager.Instance.GetInputShoot())
        {
            currentAbility?.Use();
        }
    }
}
