using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MissionLogButton : MonoBehaviour, ISelectHandler
{
    private TextMeshProUGUI buttonText;
    private TextMeshProUGUI sliderText;
    private int requiere;
    public Button button { get; private set; }
    public Slider slider { get; private set; }

    private UnityAction onSelectAction;

    public void Initialize(string displayName, UnityAction selectAction, int requiere, int current, bool isInteractable)
    {
        this.button = this.GetComponent<Button>();
        this.buttonText = this.GetComponentInChildren<TextMeshProUGUI>();
        this.slider = this.GetComponentInChildren<Slider>();
        this.buttonText.text = displayName;
        this.onSelectAction = selectAction;
        slider.maxValue = requiere;
        slider.value = current;
        this.sliderText = this.slider.GetComponentInChildren<TextMeshProUGUI>();
        this.requiere = requiere;
        this.sliderText.text = current + "/" + requiere;
        this.button.interactable = isInteractable;
    }

    public void OnSelect(BaseEventData eventData)
    {
        onSelectAction();
    }

    public void changeButtonState(bool isInteractable)
    {
        EventSystem.current.SetSelectedGameObject(null);
        button.interactable = isInteractable;
    }

    public void changeCurrentSliderValue(int currentValue)
    {
        slider.value = currentValue;
        sliderText.text = currentValue + "/" + requiere;
    }
}
