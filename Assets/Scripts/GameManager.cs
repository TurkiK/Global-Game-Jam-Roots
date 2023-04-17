using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

[System.Serializable]
public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    [Header("Game Objectives")]
    public Objectives[] gameObjectives;
    public int currentObj = 0;
    public GameObject treasureChest;

    [Header("UI")]
    public TMP_Text objectiveUI;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }

        treasureChest.SetActive(false);
    }

    private void Update()
    {
        switch (currentObj)
        {
            case 0: objectiveUI.text = (currentObj + 1) + ") Talk to your father";
                break;
            case 1: objectiveUI.text = (currentObj + 1) + ") Go to the village elder's house to learn more about your roots";
                break;
            case 2:
                objectiveUI.text = (currentObj + 1) + ") Look for the hidden treasure";
                treasureChest.SetActive(true);
                break;
            case 3:
                objectiveUI.text = (currentObj + 1) + ") Go to the tree of life";
                break;
        }
    }

    public void NextObjective()
    {
        currentObj++;
    }

    public void End()
    {
        objectiveUI.text = "The demo is over, congratulations!";
        Time.timeScale = 0;
    }
}
