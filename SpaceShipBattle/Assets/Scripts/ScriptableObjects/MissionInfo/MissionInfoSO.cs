using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.ScriptableObjects.MissionInfo
{
    [CreateAssetMenu(fileName = "MissionInfoSO", menuName = "ScriptableObjects/MissionInfoSO")]
    public class MissionInfoSO : ScriptableObject
    {
        [field: SerializeField] public string id { get; private set; }

        [Header("General")]
        public string DisplayName;

        [Header("Requirments")]
        public int rankRequirment;
        public MissionInfoSO[] missionRequierment;

        [Header("Steps")]
        public GameObject[] steps;

        [Header("Rewards")]
        public int galacticalCoins;
        public int expPoints;

        //id will always be the same name as the SO created
        private void OnValidate()
        {
            #if UNITY_EDITOR
            id = this.name;
            UnityEditor.EditorUtility.SetDirty(this);
            #endif
        }
    }
}