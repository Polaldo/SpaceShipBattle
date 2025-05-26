using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.MissionSystem
{
    public enum MissionState
    {
        REQUIREMENTS_NOT_MET,
        IN_PROGRESS,
        CAN_FINISH,
        FINISHED
    }
}