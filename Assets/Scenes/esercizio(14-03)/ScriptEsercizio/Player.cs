using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, InterfaceObservable
{
    
    [SerializeField] private float speed = 0.3f;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float jumpForce = 400;
    private List<InterfaceObserver> _observers = new();
    [Header("Quest")]
    public QuestManager questManager;
    
   
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        questManager = QuestManager.Instance;

    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal") * speed;
        float vertical = Input.GetAxis("Vertical") * speed;

        transform.Translate(horizontal, 0, vertical);

        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce);
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            questManager.currentQuest.completed = true;
            CheckForQuestCompletation();
        }
    }

    public void CheckForQuestCompletation()
    {
        if (questManager.currentQuest.completed)
        {
            
            foreach (InterfaceObserver observer in _observers)
            {
                observer.OnQuestCompleted();
                observer.AfterQuestCompleted();
            }
        }
    }
    public void AddObserver(InterfaceObserver observer)
    {
        _observers.Add(observer);
    }
    public void RemoveObserver(InterfaceObserver observer)
    {
        _observers.Remove(observer);
    }

    
    private void OnTriggerEnter(Collider other)
    {
        switch (questManager.currentQuest.questType)
        {
            case QuestType.GoToLocation:
                {
                    if (other.CompareTag(questManager.currentQuest.tagOfLocationToReach.ToString()))
                    {
                        Debug.Log("Destinazone Raggiunta");
                        questManager.currentQuest.completed = true;
                        CheckForQuestCompletation();
                    }
                }
                break;


            case QuestType.Collect:
                {
                    if (other.CompareTag(questManager.currentQuest.tagOfItemToCollect.ToString()))
                    {
                        questManager.currentQuest.quantity--;
                        Destroy(other.gameObject);
                        if(questManager.currentQuest.quantity <= 0)
                        {
                            Debug.Log("Tutti gli item raccolti");
                            questManager.currentQuest.completed = true;
                            CheckForQuestCompletation();

                        }
                    }
                }
                break;
        }
    }
}
