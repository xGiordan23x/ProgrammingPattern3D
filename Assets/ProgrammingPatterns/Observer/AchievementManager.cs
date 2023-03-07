using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementManager : MonoBehaviour, IObserver
{
    private bool _collectorGained;
    public void OnPlayerScoreChanged(int newScore)
    {
        if(!_collectorGained &&  newScore >= 5)
        {
            Debug.Log("Collector ottenuto");
            _collectorGained = true;
        }
    }
    private void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        PlayerControlleConObserver player = playerObject.GetComponent<PlayerControlleConObserver>();
        player.AddObserver(this);
    }
}
