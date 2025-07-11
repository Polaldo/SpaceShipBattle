using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAlertUI : MonoBehaviour
{
    [SerializeField] private GameObject bossAlertPanel;

    void OnEnable()
    {
        GameEventsManager.instance.levelEvents.onBossEnters += StartBossAlert;
    }

    void StartBossAlert()
    {
        StartCoroutine(ActivateBossAlert());
    }

    private IEnumerator ActivateBossAlert()
    {
        bossAlertPanel.SetActive(true);
        yield return new WaitForSeconds(5);//hardcoded for now dc there is a problem with the method getlength 
        bossAlertPanel.SetActive(false);
    }

    private void OnDisable()
    {
        GameEventsManager.instance.levelEvents.onBossEnters -= StartBossAlert;
    }
}
