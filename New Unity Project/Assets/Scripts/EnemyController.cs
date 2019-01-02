using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Serialize variables
    [SerializeField] float speed;
    [SerializeField] int damage;
    [SerializeField] LayerMask whatIsWall;
    [SerializeField] Transform wallCheck;
    [SerializeField] float wallCheckRadius;

    // Private variables
    private Rigidbody2D rb;
    private float moveDir;
    private bool facingRight;
    private bool hittingWall;

    // Unity functions
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveDir = 1;
    }

    private void Update()
    {
        hittingWall = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, whatIsWall);

        if (hittingWall)
        {
            ChangeDirection();
        }

        if (!facingRight && moveDir > 0)
            Flip();

        else if (facingRight && moveDir < 0)
            Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDir * speed, rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.CompareTag("Wall"))
        {
            ChangeDirection();
        }
        else
        {
            hitInfo.gameObject.GetComponent<Health>().TakeDamage(damage);

            if (hitInfo.transform.position.x < transform.position.x)
            {
                hitInfo.gameObject.GetComponent<PlayerController>().Knockback(true);
            }
            else if (hitInfo.transform.position.x > transform.position.x)
            {
                hitInfo.gameObject.GetComponent<PlayerController>().Knockback(false);
            }
        }
    }

    // Private functions
    private void Flip()
    {
        facingRight = !facingRight;
        Vector2 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

    private void ChangeDirection()
    {
        moveDir = -moveDir;
    }
}
