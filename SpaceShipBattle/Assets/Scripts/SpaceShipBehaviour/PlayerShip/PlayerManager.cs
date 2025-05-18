using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance { get; private set; }

    public PlayerShipData shipData;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public GameObject GetPlayer()
    {
        return GameObject.Find("Player");
    }

    public GameObject GetPlayerWeaponAbility()
    {
        return GameObject.Find("WeaponAbility");
    }

    private void Start()
    {
        CalculateAllStats();//TODO: change this 
    }

    public void CalculateAllStats()
    {
        ResetStats();

        List<ComponentShipData> components = new List<ComponentShipData>() {
            shipData.baseShipData, shipData.primaryWeaponData, shipData.abilityWeaponData, shipData.engineData
        };

        foreach (ComponentShipData component in components)
        {
            shipData.health += component.health;
            shipData.damage += component.damage;
            shipData.defense += component.defense;
            shipData.speed += component.speed;
        }
    }

    public void ResetStats()
    {
        shipData.health = 0;
        shipData.damage = 0;
        shipData.defense = 0;
        shipData.speed = 0;
    }

    public void addExp(int exp)
    {
        shipData.currentExperience += exp;
        if (checkAbleToRankUp()) RankUp();
    }

    public bool checkAbleToRankUp()
    {
        return shipData.currentExperience > shipData.experienceToRanklUp;
    }

    public void RankUp()
    {
        shipData.currentRank++;
        shipData.currentExperience = 0;
        shipData.experienceToRanklUp = (int)Mathf.Round(400 * Mathf.Log(shipData.currentRank + 1));
    }
}
