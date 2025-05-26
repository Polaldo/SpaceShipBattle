using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Events
{
    public class LevelEvents : MonoBehaviour
    {
        public event Action<LevelData> onLevelCompleted;
        public void LevelCompleted(LevelData levelCompletedData)
        {
            if (onLevelCompleted != null)
            {
                onLevelCompleted(levelCompletedData);
            }
        }
    }
}