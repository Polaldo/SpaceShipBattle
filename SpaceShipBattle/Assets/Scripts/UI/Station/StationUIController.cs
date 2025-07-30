using UnityEngine;
using UnityEngine.UI;

public class StationUIController : MonoBehaviour
{
    private PlayerShipData playerShipData;

    [Header("Components Ship UI")]
    [SerializeField] private GameObject baseShip;
    [SerializeField] private GameObject weapon;
    [SerializeField] private GameObject abilityWeapon;
    [SerializeField] private GameObject engine;

    [Header("Info Panel")]
    [SerializeField] private StationComponentInfoPanel stationInfoPanel;

    private void Start()
    {
        playerShipData = PlayerManager.Instance.shipData;
        SetStationComponent();
    }

    private void SetStationComponent()
    {
        baseShip.GetComponent<StationComponent>().SetComponent(playerShipData.baseShipData, stationInfoPanel);
        weapon.GetComponent<StationComponent>().SetComponent(playerShipData.primaryWeaponData, stationInfoPanel);
        abilityWeapon.GetComponent<StationComponent>().SetComponent(playerShipData.abilityWeaponData, stationInfoPanel);
        engine.GetComponent<StationComponent>().SetComponent(playerShipData.engineData, stationInfoPanel);
    }
}
