using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Gold
{
    public class GoldManager : MonoBehaviour
    {
        [Header("Configuration")]
        [SerializeField] private int startingGold = 5;

        public int currentGold { get; private set; }

        private void Awake()
        {
            currentGold = startingGold;
        }

        private void OnDisable()
        {
            GameEventsManager.instance.economyEvents.onGalacticalCoinsGained -= GoldGained;
        }

        private void Start()
        {
            Debug.Log("GoldManager: OnEnable");
            GameEventsManager.instance.economyEvents.onGalacticalCoinsGained += GoldGained;
            GameEventsManager.instance.economyEvents.GalacticalCoinsChange(currentGold);
        }

        private void GoldGained(int gold)
        {
            currentGold += gold;
            PlayerManager.Instance.shipData.galacticalCoins += gold;
            Debug.Log(PlayerManager.Instance.shipData.galacticalCoins + " gold gained");
            Debug.Log(currentGold + " current gold");
            GameEventsManager.instance.economyEvents.GalacticalCoinsChange(currentGold);
        }
    }
}