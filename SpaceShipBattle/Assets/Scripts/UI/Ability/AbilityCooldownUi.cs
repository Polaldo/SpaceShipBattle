using Assets.Scripts.SpaceShipBehaviour.Ability;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityCooldownUi : MonoBehaviour
{
    [SerializeField]  Image cooldownUI;

    [SerializeField] Button abilityButton;

    float timeCooldown;

    float cooldownTimer;

    void Start()
    {
        AbilityRunner.cooldownUi += StartCooldownUi;
    }

    void Update()
    {
        cooldownTimer -= Time.deltaTime;

        if (cooldownTimer >= 0.0f)
        {
            
            cooldownUI.fillAmount = cooldownTimer / timeCooldown;
        }
        else
        {
            cooldownUI.fillAmount = 0.0f;
           abilityButton.interactable = true;
        }
    }

    public void StartCooldownUi(float timeCooldown)
    {
        this.timeCooldown = timeCooldown;
        cooldownTimer = timeCooldown;
        abilityButton.interactable = false;
    }


    private void OnDisable()
    {
        AbilityRunner.cooldownUi -= StartCooldownUi;
    }
}
