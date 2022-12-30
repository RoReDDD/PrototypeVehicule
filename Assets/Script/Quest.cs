using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    public bool IsActive;
    public GameObject nextQuest;
    public GameObject currentQuest;

    public string name, description;
    public Sprite sprite;

    public QuestGoal goal;

    public AudioSource sound1, sound2;

    public void Complete()
    {
        currentQuest.SetActive(false);
        IsActive = false;
        nextQuest.SetActive(true);
    }

}
