using UnityEngine;

public class DontDuplicateObjectOnLoad : MonoBehaviour
{
    public static DontDuplicateObjectOnLoad Instance;
    public string tagName;

    void Awake()
    {
        var objs = GameObject.FindGameObjectsWithTag(tagName);
        if (objs.Length > 1)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }
}
