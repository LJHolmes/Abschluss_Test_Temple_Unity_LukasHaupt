using UnityEngine;
using UnityEngine.SceneManagement;

public class Rizzle3Master : MonoBehaviour
{
    private SoundManager soundManager;

    [SerializeField] private GameObject winScreenPanel;

    [SerializeField] private int correctStatueCount = 0;
    [SerializeField] private int correctStatueMax = 4;

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
        if (correctStatueCount >= correctStatueMax)
        {
            winScreenPanel.SetActive(true);
        }
    }

    private void ChangeScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
