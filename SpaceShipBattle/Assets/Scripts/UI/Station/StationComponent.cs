using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StationComponent : MonoBehaviour
{
    private ComponentShipData componentShipData;
    private StationComponentInfoPanel stationInfoPanel;
    [SerializeField] private Image image;
    [SerializeField] private Button button;
    private void OnEnable()
    {
        GameEventsManager.instance.playerEvents.onEquipComponentShip += ChangeSpriteImage;
    }

    public void SetComponent(ComponentShipData component, StationComponentInfoPanel stationComponentInfoPanel)
    {
        componentShipData = component;
        stationInfoPanel = stationComponentInfoPanel;
        image.sprite = componentShipData.sprite;
        button.onClick.AddListener(() => stationInfoPanel.OpenComponentInfoPanel(componentShipData));
    }

    public void ChangeSpriteImage(ComponentShipData component)
    {
        if (componentShipData.GetType() == component.GetType() && componentShipData.id != component.id)
        {
            image.sprite = component.sprite;
            componentShipData = component;
            button.onClick.AddListener(() => stationInfoPanel.OpenComponentInfoPanel(componentShipData));
        }
    }

    private void OnDisable()
    {
        GameEventsManager.instance.playerEvents.onEquipComponentShip -= ChangeSpriteImage;
    }
}
