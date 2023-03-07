using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int health;
    public int Health
    {
        get => health;
        set => health = Mathf.Min(value, 100);
    }

    [SerializeField] private int score;
    public int Score
    {
        get => score;
        set => score = value;
    }

    [SerializeField] public List<GameObject> coinInScene;
    [SerializeField] public int coinTaken;
    [SerializeField] private TextMeshProUGUI textScore;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        DontDestroyOnLoad(textScore.gameObject.transform.parent);

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }
    //SingleTone
    //nello strt:

    //    if (Instance == null)
    //        {
    //            Instance = this;
    //        }
    //        else
    //{
    //    Destroy(gameObject);
    //}

    public static GameManager Instance;



    private void Update()
    {
        textScore.text = score.ToString();
        if (coinInScene.Count != 0)
        {

            if (coinTaken == coinInScene.Count)
            {
                ChangeScene(1);
            }
        }

    }
    public void ChangeScene(int levelDeestination)
    {
        coinInScene.Clear();
        coinTaken = 0;
        SceneManager.LoadScene(levelDeestination);
    }


}
