using Assets.Scripts.SpaceShipBehaviour.Ability;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Assets.Scripts.SpaceShipBehaviour.Ability.AbilityWeaponBehaviour;

public class AbilityRunner : MonoBehaviour
{

    public delegate void CooldownUi(float cooldown);
    public static event CooldownUi cooldownUi;
    IAbility currentAbility;

    float timeCooldown;
    float time;

    private void Start()
    {
        currentAbility = GetComponent<IAbility>();
        timeCooldown = GetComponent<AbilityWeaponBehaviour>().weaponData.cooldown;
    }

    void Update()
    {
        if(InputManager.Instance.GetInputShoot() && IsNotCooldown()) {
            currentAbility?.Use();
            if (cooldownUi != null) cooldownUi(timeCooldown);
            time = 0;
        }
        else {
            time += Time.deltaTime;
        }
    }

    public bool IsNotCooldown()
    {
        return time > timeCooldown;
    }
}
