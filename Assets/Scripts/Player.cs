using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    private float horizontalmove = 0f;
    public float speed = 1f; 
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        horizontalmove = Input.GetAxisRaw("Horizontal") * speed;
    }
    private void FixedUpdate()
    {
        Vector2 targetVelocity = new Vector2(horizontalmove * 5f, rb.velocity.y);
        rb.velocity = targetVelocity;
    }
}
