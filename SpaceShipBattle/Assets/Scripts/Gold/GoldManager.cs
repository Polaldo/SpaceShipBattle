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

        private void OnEnable()
        {
            GameEventsManager.instance.economyEvents.onGalacticalCoinsGained += GoldGained;
        }

        private void OnDisable()
        {
            GameEventsManager.instance.economyEvents.onGalacticalCoinsGained -= GoldGained;
        }

        private void Start()
        {
            GameEventsManager.instance.economyEvents.GalacticalCoinsChange(currentGold);
        }

        private void GoldGained(int gold)
        {
            currentGold += gold;
            PlayerManager.Instance.shipData.galacticalCoins += gold;
            GameEventsManager.instance.economyEvents.GalacticalCoinsChange(currentGold);
        }
    }
}