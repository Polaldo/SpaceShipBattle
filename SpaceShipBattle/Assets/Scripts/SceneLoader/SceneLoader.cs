using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadAsyncScene(string sceneName)
    {
        StartCoroutine(LoadSceneAndStartSpawning(sceneName));
    }

    private IEnumerator LoadSceneAndStartSpawning(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
