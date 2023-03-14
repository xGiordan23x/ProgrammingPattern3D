using UnityEngine;

public enum QuestType
{
    GoToLocation,
    Collect
}


public class Quest : MonoBehaviour
{
    [Header("QuestInfo")]
    public string questName;
    public string questDesciption;
    public QuestType questType;
    public int expToGive;
    public bool completed;
    [Header("Collect")]
    public string tagOfItemToCollect;
    public int quantity;
    [Header("GoToLocation")]
    public string tagOfLocationToReach;
    

   
}

