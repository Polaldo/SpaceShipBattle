using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSpwanerTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Spawner").GetComponent<Spawner>().StartSpawning();
    }

}
