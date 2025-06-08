using TMPro;
using UnityEngine;

public class VersionUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI versionText;
    void Start()
    {
        versionText.text = "Spaceship battle v" + Application.version;
    }
}
