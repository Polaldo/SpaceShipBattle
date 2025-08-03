using System.Collections.Generic;
using Unity.VisualScripting;
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

    private void Start()
    {
        GameEventsManager.instance.playerEvents.onEquipComponentShip += EquipComponentShip;
    }

    public GameObject GetPlayer()
    {
        return GameObject.Find("Player");
    }

    public GameObject GetPlayerWeaponAbility()
    {
        return GameObject.Find("WeaponAbility");
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

        GameEventsManager.instance.playerEvents.ChangeShipStats(shipData);
    }

    private void EquipComponentShip(ComponentShipData component)
    {
        if (component == null) return;
        switch (component)
        {
            case BaseShipData baseShipData:
                shipData.baseShipData = baseShipData;
                break;
            case PrimaryWeaponData primaryWeaponData:
                shipData.primaryWeaponData = primaryWeaponData;
                break;
            case AbilityWeaponData abilityWeaponData:
                shipData.abilityWeaponData = abilityWeaponData;
                break;
            case EngineData engineData:
                shipData.engineData = engineData;
                break;
            default:
                Debug.LogWarning("Unknown component type: " + component.GetType());
                return;
        }
        CalculateAllStats();
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

    private void OnDisable()
    {
        GameEventsManager.instance.playerEvents.onEquipComponentShip -= EquipComponentShip;
    }
}
