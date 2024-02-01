using System.Collections.Generic;
using UnityEngine;

public class Rizzle3Master : MonoBehaviour
{
    private SoundManager soundManager;

    private GameObject winScreenPanel;

    [SerializeField] private List<GameObject> statueList;

    [SerializeField] private bool isWon = false;

    void Start()
    {
        soundManager = GameObject.Find("Main Camera").GetComponent<SoundManager>();
        winScreenPanel = GameObject.Find("WinScreen").transform.GetChild(0).gameObject;

        FindStatues();
    }

    private void Update()
    {
        CheckPoints();
    }

    private void FindStatues()
    {
        foreach (GameObject statue in GameObject.FindGameObjectsWithTag("Statue"))
        {
            AddToList(statue);
        }
    }

    private void AddToList(GameObject statue)
    {
        statueList.Add(statue);
    }

    private void CheckPoints()
    {
        if (isWon)
        {
            return;
        }

        int count = 0;

        foreach (GameObject statue in statueList)
        {
            if (statue.GetComponent<Statue>().IsOnRightSpot)
            {
                count++;
            }
        }

        if (count == statueList.Count)
        {
            isWon = true;
            soundManager.PlayWinSound();
            winScreenPanel.SetActive(true);
        }
    }
}
