using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUIController : MonoBehaviour
{
    public List<GameObject> pannel;
    private UiUtils uiUtils;

    private void Start()
    {
        //StartPannel();
    }

    public void StartPannel()
    {
        pannel.Find(p => p.gameObject.name == UiUtils.homePannelName).SetActive(true);
    }

    public void DesactivatePannel()
    {
        //GameObject g = pannel.Find(match: p => p.activeSelf);
        // Debug.Log(g);
        //uiUtils.DesactivatePannel(g);
        pannel.Find(match: p => p.activeSelf).SetActive(false);
    }

    public void ChangePannel(GameObject pannelActivate)
    {
        DesactivatePannel();
        pannelActivate.SetActive(true);
    }
}
