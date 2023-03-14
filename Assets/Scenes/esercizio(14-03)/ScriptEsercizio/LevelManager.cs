using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelManager : MonoBehaviour, InterfaceObserver
{
    public static LevelManager Instance;
    public int playerLvl = 1;
    public int currentExp = 0;
    public int totalLevelExp = 10000;
    public TextMeshProUGUI LvlText;
    public TextMeshProUGUI currentExpTextAndTotalLEvelExp;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
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
        UpdateCanvas();
    }
    public void OnQuestCompleted()
    {
        currentExp += QuestManager.Instance.currentQuest.expToGive;
        if(totalLevelExp <= currentExp)
        {
            int remaingExp = currentExp - totalLevelExp;
            LevelUp();
            currentExp += remaingExp;
        }
        UpdateCanvas();
    }
    public void AfterQuestCompleted()
    {

    }

    private void LevelUp()
    {
        LvlText.GetComponent<Animator>().SetTrigger("LevelUp");
        playerLvl++;
        totalLevelExp += 20000;
        currentExp= 0;
        
    }

    private void UpdateCanvas()
    {
        LvlText.text = playerLvl.ToString();
        currentExpTextAndTotalLEvelExp.text = (currentExp.ToString() + "/" + totalLevelExp.ToString());
    }

    public void IncreaseLevel()
    {
       
    }
}
