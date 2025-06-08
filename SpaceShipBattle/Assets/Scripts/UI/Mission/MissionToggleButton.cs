using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MissionToggleButton : MonoBehaviour
{

    public UnityEvent onClickEvent;

    void Start()
    {
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(HandleButtonClick);
        }
    }

    void HandleButtonClick()
    {
        GameObject.Find("MissionsPanel").GetComponent<MissionLogUI>().MissionLogToggleButtonPressed();
    }
}
