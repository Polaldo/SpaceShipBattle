using UnityEngine;

namespace Assets.Scripts.Gold
{
    public class GoldManager : MonoBehaviour
    {
        public static GoldManager Instance { get; private set; }

        [Header("Configuration")]
        [SerializeField] private int startingGold = 5;

        public int currentGold { get; private set; }

        private void Awake()
        {
            currentGold = startingGold;
            if (Instance != null && Instance != this)
            {
                Destroy(this);
            }
            else
            {
                Instance = this;
            }
        }

        private void OnDisable()
        {
            GameEventsManager.instance.economyEvents.onGalacticalCoinsGained -= GoldGained;
        }

        private void Start()
        {
            GameEventsManager.instance.economyEvents.onGalacticalCoinsGained += GoldGained;
            GameEventsManager.instance.economyEvents.GalacticalCoinsChange(PlayerManager.Instance.shipData.galacticalCoins);
        }

        private void GoldGained(int gold)
        {
            currentGold += gold;
            PlayerManager.Instance.shipData.galacticalCoins += gold;
            //Debug.Log(PlayerManager.Instance.shipData.galacticalCoins + " gold gained");
            Debug.Log(currentGold + " current gold");
            GameEventsManager.instance.economyEvents.GalacticalCoinsChange(PlayerManager.Instance.shipData.galacticalCoins);
        }
    }
}