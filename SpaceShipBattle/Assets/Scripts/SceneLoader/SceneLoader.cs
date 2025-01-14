using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadLevel(string sceneName)
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

        GameObject spawner = GameObject.Find("Spawner");
        if (spawner != null)
        {
            spawner.GetComponent<Spawner>().StartSpawning();
        }
    }
}
