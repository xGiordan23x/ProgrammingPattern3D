using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerObserverEvents : MonoBehaviour
{
    private static PlayerControllerObserverEvents _instance;
    public static PlayerControllerObserverEvents Instance 
    {
        get
        {
            if(_instance == null)
            {
                GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
                _instance = playerObject.GetComponent<PlayerControllerObserverEvents>();
            }
            return _instance;
        }
    }

    [SerializeField] private float speed = 0.3f;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float jumpForce = 400;
    private int _score;
    public int Score 
    { 
        get=> _score;
        set
        {
            _score = value;
            OnScoreChanged.Invoke(_score);
        }
    }
    public delegate void OnScoreChangedFunction(int newScore);
    public event OnScoreChangedFunction OnScoreChanged;

    private void IncreaseScale(int score)
    {
        transform.localScale = 
            new Vector3(1f+ 1*score, 1f + 1 * score, 1f + 1 * score);
    }

    private void Awake()
    {

        rb = GetComponent<Rigidbody>();

    }

    private void Start()
    {
        OnScoreChanged += IncreaseScale;
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
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            Score++;
            Destroy(other.gameObject);
        }
    }
}
