using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestManager : MonoBehaviour, InterfaceObserver
{
    public static QuestManager Instance;
    public TextMeshProUGUI questTitle;
    public TextMeshProUGUI questDescription;
    public TextMeshProUGUI questExpToGIve;
    public List<Quest> questList;
    public Quest currentQuest;
    public int currentQuestId;
   

    public void AfterQuestCompleted()
    {       
            
            currentQuest = questList[currentQuestId + 1];     
           
            UpdateQuestUI();
        
    }
    public void OnQuestCompleted()
    {
        Debug.Log("Quest Completata");

    }
    private void Awake()
    {
        if(Instance == null) 
        {
            Instance= this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        Player player = playerObject.GetComponent<Player>();
        player.AddObserver(this);
        currentQuestId= 0;

        currentQuest = questList[currentQuestId];
        UpdateQuestUI();    
        
       
        
    }

    

    public void UpdateQuestUI()
    {
        questTitle.text = currentQuest.questName.ToString();
        questDescription.text = currentQuest.questDesciption.ToString();
        questExpToGIve.text = currentQuest.expToGive.ToString();

    }
}
