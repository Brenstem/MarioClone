using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    // Inpsector variables
    [SerializeField] int healthPoints;
    private bool mCanDie = true ;
    public bool CanDie { get { return mCanDie; } set { mCanDie = value; } }

    // Properties
    public int hp { get { return healthPoints; } set { healthPoints = value; } }

    // Function for making the player take damage
    public void TakeDamage(int dmg)
    {
        hp -= dmg;
        if (hp <= 0 && CanDie)
            Die();
    }

    // Kills the player by setting it's active to false or destroying it if it's not the player
    private void Die()
    {
        if (transform.gameObject.CompareTag("Player"))
            transform.gameObject.SetActive(false);

        else
            Destroy(this.gameObject);
    }
}
