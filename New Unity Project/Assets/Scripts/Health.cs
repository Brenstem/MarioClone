using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    // Inpsector variables
    [SerializeField] int healthPoints;

    // Properties
    public int hp { get { return healthPoints; } set { healthPoints = value; } }
    private bool mCanDie = true;
    public bool CanDie { get { return mCanDie; } set { mCanDie = value; } }

    // Function for making the player take damage
    public void TakeDamage(int dmg)
    {
        hp -= dmg;
        if (hp <= 0 && CanDie)
            Die();
    }

    // Kills the player by deactivating it, destroys any object not the player
    private void Die()
    {
        if (transform.gameObject.CompareTag("Player"))
            transform.gameObject.SetActive(false);

        else
            Destroy(this.gameObject);
    }
}
