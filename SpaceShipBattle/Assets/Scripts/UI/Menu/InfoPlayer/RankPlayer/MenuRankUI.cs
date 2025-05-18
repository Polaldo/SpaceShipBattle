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
            setRankInfo();

        }

        private void setRankInfo()
        {
            rankText.text = PlayerManager.Instance.shipData.currentRank.ToString();
            experienceReamingText.text = PlayerManager.Instance.shipData.experienceToRanklUp.ToString();
            sliderRank.maxValue = PlayerManager.Instance.shipData.experienceToRanklUp;
            sliderRank.value = PlayerManager.Instance.shipData.currentExperience;
        }
    }
}