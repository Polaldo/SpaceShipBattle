using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.Menu.InfoPlayer.RankPlayer
{
    public class MenuRankUI : MonoBehaviour
    {

        [SerializeField] private TextMeshProUGUI rankText;
        [SerializeField] private TextMeshProUGUI experienceReamingText;
        [SerializeField] private Slider sliderRank;

        private void Start()
        {
            GameEventsManager.instance.rankEvents.onExperiencePointsChanged += setRankInfo;
        }

        private void OnDisable()
        {
            GameEventsManager.instance.rankEvents.onExperiencePointsChanged -= setRankInfo;
        }

        private void setRankInfo(int currentExp)
        {
            rankText.text = PlayerManager.Instance.shipData.currentRank.ToString();
            experienceReamingText.text = GameConstants.toRankUpText + " " + PlayerManager.Instance.shipData.experienceToRanklUp.ToString();
            sliderRank.maxValue = PlayerManager.Instance.shipData.experienceToRanklUp;
            sliderRank.value = currentExp;
        }
    }
}