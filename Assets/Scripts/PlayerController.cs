using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 0.3f;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float jumpForce = 400;
    private void Awake()
    {
        DontDestroyOnLoad(this);
        
        rb= GetComponent<Rigidbody>();   

    }
    private void Start()
    {
        
    }
    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal") * speed;
        float vertical = Input.GetAxis("Vertical") * speed;

        transform.Translate(horizontal,0,vertical);

        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce);
        }
    }
}
