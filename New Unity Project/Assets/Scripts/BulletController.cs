using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] float lifeLength;

    private Rigidbody2D rb;
    private PlayerController player;
    private float lifeTimer;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();


        if (player.facingRight)
        {
            rb.velocity = Vector2.left;
        }
        else if (!player.facingRight)
        {
            rb.velocity = Vector2.right;
        }

    }

    private void Update()
    {
        lifeTimer += Time.fixedDeltaTime;

        if (lifeTimer > lifeLength)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D hitInfo)
    {
        Debug.Log("hit");

        if (hitInfo.gameObject.CompareTag("Enemy"))
        {
            hitInfo.gameObject.GetComponent<Health>().TakeDamage(player.damage);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
