using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Serialized variables
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    [SerializeField] int mDamage;

    [SerializeField] LayerMask whatIsGround;
    [SerializeField] Transform groundCheck;
    [SerializeField] float groundCheckRadius;

    [SerializeField] float knockbackForce;
    [SerializeField] float knockbackLength;
    [SerializeField] int extraJumps;

    private bool mCanFire = false;
    public bool CanFire { get { return mCanFire; } set { mCanFire = value; } }

    // Private varibales
    private Rigidbody2D rb;
    private Weapon weapon; 
    private float moveInput;
    private bool mFacingRight;
    public int Damage { get { return mDamage; } }
    public bool FacingRight { get { return mFacingRight; } set { mFacingRight = value; } }
    private bool grounded;

    private float knockbackTimer;
    private bool knockedFromRight;
    private int jumpsLeft;


    // Unity functions
    private void Start()
    {
        jumpsLeft = extraJumps;
        rb = GetComponent<Rigidbody2D>();
        weapon = GetComponent<Weapon>();
    }

    private void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal") * speed;
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        weapon.Shoot();

        if (!FacingRight && moveInput < 0)
            Flip(); 

        else if (FacingRight && moveInput > 0)
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

        if (grounded)
        {
            jumpsLeft = extraJumps;
        }

        if (Input.GetKeyDown(KeyCode.Space) && jumpsLeft > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            jumpsLeft--;
        }
    }

    // Private functions
    private void Flip()
    {
        FacingRight = !FacingRight;
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
