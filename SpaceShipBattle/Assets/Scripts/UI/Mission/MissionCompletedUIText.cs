using Assets.Scripts.MissionSystem;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MissionCompletedUIText : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private GameObject completeMissionMessagePanel;
    [SerializeField] private TextMeshProUGUI missionNameText;

    [Header("Animations Times")]
    [SerializeField] private int displayTime;
    [SerializeField] private int animationTime;

    private Queue<string> missionCompletedQueue = new Queue<string>();
    private Coroutine queueCoroutine;

    void Start()
    {
        GameEventsManager.instance.missionEvents.onMissionStateChange += ShowMessageMissionComplete;
    }

    private void OnDisable()
    {
        GameEventsManager.instance.missionEvents.onMissionStateChange += ShowMessageMissionComplete;
    }

    public void ShowMessageMissionComplete(Mission mission)
    {
        if (mission.missionState.Equals(MissionState.CAN_FINISH))
        {
            missionCompletedQueue.Enqueue(mission.missionInfo.displayName);
            if (queueCoroutine == null)
            {
                queueCoroutine = StartCoroutine(ProcessQueue());
            }
        }
    }
    private IEnumerator ProcessQueue()
    {
        while (missionCompletedQueue.Count > 0)
        {
            AudioManager.instance.PlayOneShot(FMODEvents.instance.missionComplete);
            canvasGroup.alpha = 1;
            missionNameText.text = missionCompletedQueue.Dequeue();
            completeMissionMessagePanel.SetActive(true);
            yield return new WaitForSeconds(displayTime);
            float time = 0f;
            while (time < animationTime)
            {
                time += Time.deltaTime;
                canvasGroup.alpha = 1 - (time / animationTime);
                yield return null;
            }
            canvasGroup.alpha = 0;
            completeMissionMessagePanel.SetActive(false);
        }
        queueCoroutine = null;
    }
}
