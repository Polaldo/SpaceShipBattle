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
        SetSpritesUI();
        SetListenersToButtons();
    }

    private void SetSpritesUI()
    {
        //Hardcoded bc we want the child component and not the component of itself
        baseShip.GetComponentsInChildren<Image>()[1].sprite = playerShipData.baseShipData.sprite;
        weapon.GetComponentsInChildren<Image>()[1].sprite = playerShipData.primaryWeaponData.sprite;
        abilityWeapon.GetComponentsInChildren<Image>()[1].sprite = playerShipData.abilityWeaponData.sprite;
        engine.GetComponentsInChildren<Image>()[1].sprite = playerShipData.engineData.sprite;
    }

    private void SetListenersToButtons()
    {
        baseShip.GetComponent<Button>().onClick.AddListener(() => stationInfoPanel.OpenComponentInfoPanel(playerShipData.baseShipData));
        weapon.GetComponent<Button>().onClick.AddListener(() => stationInfoPanel.OpenComponentInfoPanel(playerShipData.primaryWeaponData));
        abilityWeapon.GetComponent<Button>().onClick.AddListener(() => stationInfoPanel.OpenComponentInfoPanel(playerShipData.abilityWeaponData));
        engine.GetComponent<Button>().onClick.AddListener(() => stationInfoPanel.OpenComponentInfoPanel(playerShipData.engineData));
    }
}
