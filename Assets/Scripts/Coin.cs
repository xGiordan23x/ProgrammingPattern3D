using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int coinValue;
    [SerializeField] private float RotationSpeed =100;
    [SerializeField] public bool alreadyPicked = false;

    internal void PickedUp()
    {
        Debug.Log("giocatore ha raccolto una moneta");
        GameManager.Instance.Score += coinValue;
        GameManager.Instance.SetScore();
        GameManager.Instance.coinTaken += coinValue;
        alreadyPicked= true;
        Destroy(gameObject);
    }

    
    
    private void Start()
    {
        
            GameManager.Instance.coinInScene.Add(this.gameObject);
        
    }

    private void Update()
    {
        transform.Rotate(Vector3.up * RotationSpeed * Time.deltaTime); 
    }
}
