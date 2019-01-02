﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Headstomper : MonoBehaviour
{
    [SerializeField] int damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
