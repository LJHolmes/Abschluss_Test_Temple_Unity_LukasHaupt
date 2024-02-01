using UnityEngine;
using UnityEngine.SceneManagement;

public class Rizzle1Master : MonoBehaviour
{
    public int AppleScore = 0;

    private SoundManager soundManager;

    [SerializeField] private GameObject startScreen;

    [SerializeField] private int maxApples = 4;

    void Start()
    {
        soundManager = GameObject.Find("Main Camera").GetComponent<SoundManager>();
    }

    void Update()
    {
        CheckLevelIsWon();
    }

    private void CheckLevelIsWon()
    {
        if (AppleScore >= maxApples)
        {
            soundManager.PlayWinSound();

            ChangeScene(1);
        }
    }

    private void ChangeScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void StartRizzle1()
    {
        startScreen.SetActive(false);
    }
}
