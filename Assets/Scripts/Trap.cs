using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>() == null) return;

        Debug.Log("giocatore tocca trappola");
        GameManager.Instance.Health--;
        
    }
}
