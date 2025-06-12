using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneEvents
{
    public event Action<string> onSceneLoaded;
    public void SceneLoaded(string sceneName)
    {
        if (onSceneLoaded != null)
        {
            onSceneLoaded(sceneName);
        }
    }
}

