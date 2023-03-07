using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManagerObserverEvents : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreTextMesh;
    private void Start()
    {
        PlayerControllerObserverEvents.Instance.OnScoreChanged += SetScore;
    }

    private void SetScore(int currentScore)
    {
        scoreTextMesh.text = currentScore.ToString();
    }
}
