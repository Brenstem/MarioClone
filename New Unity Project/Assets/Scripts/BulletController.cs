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


        if (player.FacingRight)
        {
            rb.velocity = Vector2.left;
        }
        else if (!player.FacingRight)
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
        if (hitInfo.gameObject.CompareTag("Enemy"))
        {
            hitInfo.gameObject.GetComponent<Health>().TakeDamage(player.Damage);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
