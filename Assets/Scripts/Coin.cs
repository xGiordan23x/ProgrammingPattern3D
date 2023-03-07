using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int coinValue = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>() == null) return;

        Debug.Log("giocatore ha raccolto una moneta");
        GameManager.Instance.Score++;
        GameManager.Instance.coinTaken += coinValue;
        Destroy(gameObject);

    }
    private void Start()
    {
        GameManager.Instance.coinInScene.Add(this.gameObject);
    }
}
