using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int coinValue = 10;
    [SerializeField] private float RotationSped;

    internal void PickedUp()
    {
        Debug.Log("giocatore ha raccolto una moneta");
        GameManager.Instance.Score++;
        GameManager.Instance.coinTaken += coinValue;
        Destroy(gameObject);
    }

    
    
    private void Start()
    {
        
            GameManager.Instance.coinInScene.Add(this.gameObject);
        
    }

    private void Update()
    {
        transform.Rotate(Vector3.up * RotationSped * Time.deltaTime); 
    }
}
