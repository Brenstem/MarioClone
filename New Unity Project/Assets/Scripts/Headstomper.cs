﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Headstomper : MonoBehaviour
{
    // Inspector variables
    [SerializeField] int damage;
    [SerializeField] float force;

    // Unity functino
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Health>().TakeDamage(damage);
            transform.parent.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.parent.GetComponent<Rigidbody2D>().velocity.x, force);
        }
    }
}
