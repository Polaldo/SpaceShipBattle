using TMPro;
using UnityEngine;

public class EconomyUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI galacticalCoinsText;
    //[SerializeField] TextMeshProUGUI darkShardText;

    void Start()
    {
        GameEventsManager.instance.economyEvents.onGalacticalCoinChange += ChangeGalacticalCoinsText;

        //darkShardText.text = PlayerManager.Instance.shipData.darkShards.ToString();
    }

    private void OnDisable()
    {
        GameEventsManager.instance.economyEvents.onGalacticalCoinChange -= ChangeGalacticalCoinsText;
    }

    void ChangeGalacticalCoinsText(int coins)
    {
        //galacticalCoinsText.text = PlayerManager.Instance.shipData.galacticalCoins.ToString();
        galacticalCoinsText.text = coins.ToString();
    }
}
