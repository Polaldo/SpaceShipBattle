using UnityEngine;

public class StartMenuUIController : MonoBehaviour
{
    [SerializeField] private GameObject startMenuPannel;
    [SerializeField] private GameObject NewGamePannel;
    [SerializeField] private GameObject ContinuePannel;
    [SerializeField] private GameObject OptionsPannel;
    [SerializeField] private GameObject MessagePannel;

    public void InactiveThisGO()
    {
        startMenuPannel.gameObject.SetActive(false);
    }

    public void ActiveThisGO()
    {
        startMenuPannel.gameObject.SetActive(true);
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
