using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerControlleConObserver : MonoBehaviour, IObservable
{
    [SerializeField] private float speed = 0.3f;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float jumpForce = 400;

    private int _score;
    private List<IObserver> _observers = new();

    private int Score {

        get => _score;
        set
        {
            _score= value;
            foreach (IObserver observer in _observers)
            {
                observer.OnPlayerScoreChanged(_score);
            }
        }
    }

    private void Awake()
    {
       
        rb = GetComponent<Rigidbody>();

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
        Debug.Log("prova");
        if (other.GetComponent<CoinConObserver>() != null)
        {
            CoinConObserver coin = other.GetComponent<CoinConObserver>();
            if (coin.alreadyTaken == false)
            {
                coin.alreadyTaken = true;

                Score++;
                Destroy(other.gameObject);
                
            }
        }
    }

    
    public void AddObserver(IObserver observer)
    {
        _observers.Add(observer);
    }
    public void RemoveObserver(IObserver observer)
    {
        _observers.Remove(observer);
    }
}
