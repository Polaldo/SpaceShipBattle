using UnityEngine;
using UnityEngine.UI;

public class ButtonSoundPlayer : MonoBehaviour
{
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(() => AudioManager.instance.PlayOneShot(FMODEvents.instance.buttonClicked));
        }
    }
}
