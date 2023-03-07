using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMangerConObserver : MonoBehaviour, IObserver

{
    
    [SerializeField] private TextMeshProUGUI scoreTextMesh;

    private void Start()
    {
       
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        PlayerControlleConObserver player = playerObject.GetComponent<PlayerControlleConObserver>();
        player.AddObserver(this);
    }

    public void OnPlayerScoreChanged(int newScore)
    {
        scoreTextMesh.text = newScore.ToString();
    }
}
