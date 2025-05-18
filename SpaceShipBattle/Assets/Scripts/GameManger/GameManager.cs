using Assets.Scripts.Gold;
using Assets.Scripts.Rank;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public GoldManager goldManager;
    public RankManager rankManager;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        goldManager = new GoldManager();
        rankManager = new RankManager();
    }

    public void StopTime()
    {
        Time.timeScale = 0;
    }

    public void ResumeTime()
    {
        Time.timeScale = 1f;
    }

    public void DestroyGameObject(GameObject gameObject)
    {
        Destroy(gameObject);
    }
}
