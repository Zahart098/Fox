using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private float horizontalmove = 0f;
    public float speed = 1f; 
    private bool facingRight = true;
    public float jumpstrenght = 5f;
    private bool isGrounded = false;
    public float checkGroundOffsetY = -1.1f;
    public float checkGroundRadius = 0.3f;
    


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        horizontalmove = Input.GetAxisRaw("Horizontal") * speed;
        if(horizontalmove < 0 && facingRight)
        {
            Flip();
        }
       else if (horizontalmove > 0 && !facingRight)
        {
            Flip();
        }
        if(isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.up * jumpstrenght, ForceMode2D.Impulse);
        }
    }
    private void FixedUpdate()
    {
        Vector2 targetVelocity = new Vector2(horizontalmove * 2f, rb.velocity.y);
        rb.velocity = targetVelocity;
        CheckGround();
    }
   private void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    private void CheckGround()
    {
        Collider2D[] collider2Ds = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y + checkGroundOffsetY), checkGroundRadius);
        if (ñolliders.Lenght > 1)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
}
