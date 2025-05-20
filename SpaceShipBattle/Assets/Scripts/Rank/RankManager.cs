using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Rank
{
    public class RankManager : MonoBehaviour
    {
        public static RankManager Instance { get; private set; }
        [Header("Configuration")]
        [SerializeField] private int startingLevel = 1;
        [SerializeField] private int startingExperience = 0;

        private int currentLevel;
        private int currentExperience;

        private void Awake()
        {
            currentLevel = startingLevel;
            currentExperience = startingExperience;
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
            GameEventsManager.instance.rankEvents.onExperiencePointsGained -= ExperienceGained;
        }

        private void Start()
        {
            GameEventsManager.instance.rankEvents.onExperiencePointsGained += ExperienceGained;
            GameEventsManager.instance.rankEvents.ExperiencePointsChanged(PlayerManager.Instance.shipData.currentExperience);
        }

        private void ExperienceGained(int experience)
        {
            currentExperience += experience;
            PlayerManager.Instance.shipData.currentExperience += experience;
            GameEventsManager.instance.rankEvents.ExperiencePointsChanged(experience);
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