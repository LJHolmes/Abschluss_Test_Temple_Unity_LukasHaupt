using UnityEngine;
using UnityEngine.SceneManagement;

public class Rizzle3Master : MonoBehaviour
{
    private SoundManager soundManager;

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

    }

    private void ChangeScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
