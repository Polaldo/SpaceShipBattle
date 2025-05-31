using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MissionLogButton : MonoBehaviour, ISelectHandler
{
        private TextMeshProUGUI buttonText;
        public Button button {get; private set;}

        private UnityAction onSelectAction;

        public void Initialize(string displayName, UnityAction selectAction)
        {
            this.button = this.GetComponent<Button>();
            this.buttonText = this.GetComponentInChildren<TextMeshProUGUI>();
            this.buttonText.text = displayName;
            this.onSelectAction = selectAction;
        }
        public void OnSelect(BaseEventData eventData)
        {
            onSelectAction();
            Debug.Log("hahaha im here");
        }
    }
