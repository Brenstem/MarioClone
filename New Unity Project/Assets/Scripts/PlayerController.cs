using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Serialized variables
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] LayerMask whatIsGround;
    [SerializeField] Transform groundCheck;
    [SerializeField] float groundCheckRadius;

    // Private varibales
    private Rigidbody2D rb;
    private float moveInput;
    private float jumpInput;
    private bool facingRight = false;
    private bool grounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal") * speed;
        jumpInput = Input.GetAxisRaw("Jump") * jumpForce;
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        Debug.Log(grounded);

        if (!facingRight && moveInput < 0)
            Flip();

        else if (facingRight && moveInput > 0)
            Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput, rb.velocity.y);

        if (jumpInput == 1 && grounded)
        {
            Debug.Log("can jump");
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector2 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}
