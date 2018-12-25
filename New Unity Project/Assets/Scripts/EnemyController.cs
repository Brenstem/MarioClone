using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Serialize variables
    [SerializeField] float speed;
    [SerializeField] int damage;

    // Private variables
    private Rigidbody2D rb;
    private float moveDir;
    private bool facingRight;

    // Unity functions
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveDir = -1;
    }

    private void Update()
    {
        if (!facingRight && moveDir > 0)
            Flip();

        else if (facingRight && moveDir < 0)
            Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDir * speed, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D hitInfo)
    {
        if (!hitInfo.gameObject.CompareTag("Player"))
        { 
            ChangeDirection();
        }
        else
        {
            GameObject player = hitInfo.gameObject;
            player.GetComponent<Health>().TakeDamage(damage);

            if (player.GetComponent<Transform>().position.x < transform.position.x)
            {
                player.GetComponent<Rigidbody2D>().MovePosition(Vector2.left);
            }
            else if (player.GetComponent<Transform>().position.x > transform.position.x)
            {
                Debug.Log("meme");

                player.GetComponent<Rigidbody2D>().MovePosition(Vector2.right);
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

    private void KnockBack()
    {

    }


}
