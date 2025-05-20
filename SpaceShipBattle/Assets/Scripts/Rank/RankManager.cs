using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Rank
{
    public class RankManager : MonoBehaviour
    {
        [Header("Configuration")]
        [SerializeField] private int startingLevel = 1;
        [SerializeField] private int startingExperience = 0;

        private int currentLevel;
        private int currentExperience;

        private void Awake()
        {
            currentLevel = startingLevel;
            currentExperience = startingExperience;
        }


        private void OnDisable()
        {
            GameEventsManager.instance.rankEvents.onExperiencePointsGained -= ExperienceGained;
        }

        private void Start()
        {
            GameEventsManager.instance.rankEvents.onExperiencePointsGained += ExperienceGained;
            GameEventsManager.instance.rankEvents.RankUpChange(currentLevel);
            GameEventsManager.instance.rankEvents.ExperiencePointsChanged(currentExperience);
        }

        private void ExperienceGained(int experience)
        {
            currentExperience += experience;
            PlayerManager.Instance.shipData.currentExperience += experience;
            GameEventsManager.instance.rankEvents.ExperiencePointsChanged(currentExperience);
            Debug.Log(PlayerManager.Instance.shipData.currentExperience + " xp gained");
            Debug.Log(currentExperience + " current xp");
            // check if we're ready to level up
            while (PlayerManager.Instance.shipData.currentExperience >= PlayerManager.Instance.shipData.experienceToRanklUp)
            {
                PlayerManager.Instance.shipData.currentExperience -= PlayerManager.Instance.shipData.experienceToRanklUp;
                currentLevel++;
                PlayerManager.Instance.shipData.currentRank++;
                GameEventsManager.instance.rankEvents.RankUpChange(currentLevel);
            }
            
        }
    }
}