using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Serialized variables
    [SerializeField] float speed;
    [SerializeField] float jumpForce;

    [SerializeField] LayerMask whatIsGround;
    [SerializeField] Transform groundCheck;
    [SerializeField] float groundCheckRadius;

    [SerializeField] float knockbackForce;
    [SerializeField] float knockbackLength;

    // Private varibales
    private Rigidbody2D rb;
    private float moveInput;
    private float jumpInput;
    private bool facingRight = false;
    private bool grounded;

    private float knockbackTimer;
    private bool knockedFromRight;

    // Unity functions
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal") * speed;
        jumpInput = Input.GetAxisRaw("Jump");
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        if (!facingRight && moveInput < 0)
            Flip(); 

        else if (facingRight && moveInput > 0)
            Flip();
    }

    private void FixedUpdate()
    {
        if (knockbackTimer <= 0)
        {
            rb.velocity = new Vector2(moveInput, rb.velocity.y);
        }
        else
        {
            if (knockedFromRight)
            {
                rb.velocity = new Vector2(-knockbackForce, knockbackForce);
            }
            else if (!knockedFromRight)
            {
                rb.velocity = new Vector2(knockbackForce, knockbackForce);
            }
            knockbackTimer -= Time.deltaTime;
        }

        if (jumpInput == 1 && grounded)
            rb.velocity = Vector2.up * jumpForce;
    }

    // Private functions
    private void Flip()
    {
        facingRight = !facingRight;
        Vector2 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

    // Public functions
    public void Knockback(bool _knockedFromRight)
    {
        knockbackTimer = knockbackLength;
        knockedFromRight = _knockedFromRight;
    }
}
