using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestGiver : MonoBehaviour
{
    public Quest quest;
    public Waypoint waypoint;
    public WheelController player;
    public GameObject objectifQuest; 
    public GameObject questWindow;

    public Text questGiverName, description;
    public Image sprite;

    
    

    public void Start()
    {
        var objectif = GameObject.Find("TrailerQuest").transform;
        waypoint.enabled = false;
    }


    IEnumerator OpenQuestWindow()
    {
        quest.sound1.Play();
        yield return new WaitForSeconds(1);
        questWindow.SetActive(true);
        questGiverName.text = quest.name;
        description.text = quest.description;
        sprite.sprite = quest.sprite;
        
    }

    public void AcceptQuest()
    {
        questWindow.SetActive(false);
        quest.IsActive = true;
        questWindow = null;
        player.quest = quest;
        waypoint.enabled = true;
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            StartCoroutine(OpenQuestWindow());
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            AcceptQuest();
            quest.sound2.Play();
        }
    }

    public void Update()
    {
        
    }
}
