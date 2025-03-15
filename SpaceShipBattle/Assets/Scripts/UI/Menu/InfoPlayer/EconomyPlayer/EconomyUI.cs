using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EconomyUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI galacticalCoinsText;
    //[SerializeField] TextMeshProUGUI darkShardText;

    void Start()
    {
        galacticalCoinsText.text = PlayerManager.Instance.shipData.galacticalCoins.ToString();
        //darkShardText.text = PlayerManager.Instance.shipData.darkShards.ToString();
    }

}
