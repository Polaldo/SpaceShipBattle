using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAlertUI : MonoBehaviour
{
    [SerializeField] private GameObject bossAlertPanel;

    void Start()
    {
        GameEventsManager.instance.levelEvents.onBossEnters += StartBossAlert;
    }

    void StartBossAlert()
    {
        StartCoroutine(ActivateBossAlert());
    }

    private IEnumerator ActivateBossAlert()
    {
        int lenghtSoundBooss = AudioManager.instance.GetLenght(FMODEvents.instance.bossEnters);
        int time = 0;
        while (time < lenghtSoundBooss)
        {
            bossAlertPanel.SetActive(true);
            time++;
        }
        bossAlertPanel.SetActive(false);
        return null;
    }

    private void OnDisable()
    {
        GameEventsManager.instance.levelEvents.onBossEnters -= StartBossAlert;
    }
}
