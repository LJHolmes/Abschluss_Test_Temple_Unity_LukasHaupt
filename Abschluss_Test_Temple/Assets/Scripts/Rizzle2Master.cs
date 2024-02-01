using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rizzle2Master : MonoBehaviour
{
    private SoundManager soundManager;

    [SerializeField] private List<GameObject> pillarList;

    [SerializeField] private bool isRedLightOn;
    [SerializeField] private bool isBlueLightOn;
    [SerializeField] private bool isGreenLightOn;

    void Start()
    {
        soundManager = GameObject.Find("Main Camera").GetComponent<SoundManager>();

        FindPillars();
    }

    private void ChangeScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    private void FindPillars()
    {
        foreach (GameObject pillar in GameObject.FindGameObjectsWithTag("LightPillar"))
        {
            AddToList(pillar);
        }
    }

    private void AddToList(GameObject pillar)
    {
        pillarList.Add(pillar);
    }

    public void TurnedLightOn(GameObject pillar)
    {
        if (pillar.GetComponent<LightPillar>().PillarRed)
        {
            isRedLightOn = true;

            if (isBlueLightOn || isGreenLightOn)
            {
                soundManager.PlayWrongSound();
                Invoke("TurnAllLightsOff", 0.5f);
                return;
            }

            soundManager.PlayCorrectSound();
        }
        if (pillar.GetComponent<LightPillar>().PillarBlue)
        {
            isBlueLightOn = true;

            if (!isRedLightOn || isGreenLightOn)
            {
                soundManager.PlayWrongSound();
                Invoke("TurnAllLightsOff", 0.5f);
                return;
            }

            soundManager.PlayCorrectSound();
        }
        if (pillar.GetComponent<LightPillar>().PillarGreen)
        {
            if (isRedLightOn && isBlueLightOn)
            {
                isGreenLightOn = true;

                soundManager.PlayWinSound();

                ChangeScene(2);
            }
            else
            {
                soundManager.PlayWrongSound();
                Invoke("TurnAllLightsOff", 0.5f);
            }
        }
    }

    public void TurnLightsOff(GameObject pillar)
    {
        if (pillar.GetComponent<LightPillar>().PillarRed)
        {
            isRedLightOn = false;
        }
        if (pillar.GetComponent<LightPillar>().PillarBlue)
        {
            isBlueLightOn = false;
        }
        if (pillar.GetComponent<LightPillar>().PillarGreen)
        {
            isGreenLightOn = false;
        }
    }

    private void TurnAllLightsOff()
    {
        foreach (GameObject pillar in pillarList)
        {
            pillar.GetComponent<LightPillar>().SetLightsOff();

            isRedLightOn = false;
            isBlueLightOn = false;
            isGreenLightOn = false;
        }
    }
}
