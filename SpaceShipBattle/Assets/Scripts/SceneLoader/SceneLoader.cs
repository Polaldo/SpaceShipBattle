using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance { get; private set; }

    [SerializeField] private GameObject loadScreen;
    [SerializeField] private Slider loadingSlider;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadAsyncScene(string sceneName, GameObject canvasToDesactivate)
    {
        canvasToDesactivate.SetActive(false);
        loadScreen.SetActive(true);
        StartCoroutine(AsyncLoadScene(sceneName));
    }

    public void LoadAsyncScene(string sceneName)
    {
        StartCoroutine(AsyncLoadScene(sceneName));
    }

    private IEnumerator AsyncLoadScene(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        while (!asyncLoad.isDone)
        {
            loadingSlider.value = Mathf.Clamp01(asyncLoad.progress / 0.09f);
            loadScreen.SetActive(false);
            yield return null;
        }

    }
}
