using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinConObserver : MonoBehaviour
{
    [SerializeField] private float RotationSpeed = 100;
    public bool alreadyTaken;
    private void Update()
    {
        transform.Rotate(Vector3.up * RotationSpeed * Time.deltaTime);
    }
}
