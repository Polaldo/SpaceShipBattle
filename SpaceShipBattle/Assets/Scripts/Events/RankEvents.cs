using System;

namespace Assets.Scripts.Events
{
    public class RankEvents
    {
        public event Action<int> onExperiencePointsGained;
        public void ExperiencePointsGained(int expPoints)
        {
            if (onExperiencePointsGained != null)
            {
                onExperiencePointsGained(expPoints);
            }
        }

        public event Action<int> onExperiencePointsChanged;
        public void ExperiencePointsChanged(int expPoints)
        {
            if (onExperiencePointsChanged != null)
            {
                onExperiencePointsChanged(expPoints);
            }
        }

        public event Action<int> onRankUpChange;
        public void RankUpChange(int level)
        {
            if (onRankUpChange != null)
            {
                onRankUpChange(level);
            }
        }
    }
}
