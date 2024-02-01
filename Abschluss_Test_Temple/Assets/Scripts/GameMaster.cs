using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public int AppleScore;

    private SoundManager soundManager;

    [SerializeField] private int maxApples = 3;

    void Start()
    {
        soundManager = GameObject.Find("Main Camera").GetComponent<SoundManager>();
    }

    void Update()
    {
        if (AppleScore >= maxApples)
        {
            soundManager.PlayWinSound();
        }
    }
}
