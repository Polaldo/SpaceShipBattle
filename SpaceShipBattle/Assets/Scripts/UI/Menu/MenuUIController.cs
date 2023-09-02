using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUIController : MonoBehaviour
{
    private GameObject NewGamePannel;
    private GameObject ContinuePannel;
    private GameObject OptionsPannel;
    private GameObject MessagePannel;

    public void InactiveThisGO()
    {
        this.gameObject.SetActive(false);
    }
    
    public void ActiveThisGO()
    {
        this.gameObject.SetActive(true);
    }

    public void OnClickNewGame()
    {
        InactiveThisGO();
        NewGamePannel.SetActive(true);
    }

    public void OnClickContinueGame()
    {
        InactiveThisGO();
        ContinuePannel.SetActive(true);
    }

    public void OnClickOptions()
    {
        InactiveThisGO();
        OptionsPannel.SetActive(true);
    }

    public void OnClickExit()
    {
        MessagePannel.SetActive(true);
        //TODO: active method rettur true or false
        Application.Quit();
    }

    public void BackButton(GameObject GO)
    {
        GO.SetActive(false);
        ActiveThisGO();
    }

}
