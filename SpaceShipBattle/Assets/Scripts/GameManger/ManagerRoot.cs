using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerRoot : MonoBehaviour
{
    private static ManagerRoot instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Persiste entre escenas
        }
        else
        {
            Destroy(gameObject); // Destruye duplicados al cargar nuevas escenas
        }
    }
}
