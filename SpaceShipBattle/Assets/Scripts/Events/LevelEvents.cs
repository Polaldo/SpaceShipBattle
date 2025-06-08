using System;

namespace Assets.Scripts.Events
{
    public class LevelEvents
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