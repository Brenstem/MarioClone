using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    // Serialized variables
    [SerializeField] float lifeLength;
    [SerializeField] float speed;

    // Private variables
    private Rigidbody2D rb;
    private PlayerController player;
    private float lifeTimer;

    // Unity functions
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();


        if (player.FacingRight)
        {
            rb.velocity = Vector2.left * speed;
        }
        else if (!player.FacingRight)
        {
            rb.velocity = Vector2.right * speed;
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

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.CompareTag("Enemy"))
        {
            hitInfo.gameObject.GetComponent<Health>().TakeDamage(player.BulletDamage);
            Destroy(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
