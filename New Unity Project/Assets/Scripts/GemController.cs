using UnityEngine;

public class GemController : MonoBehaviour
{
    // Enums
    enum Powerups
    {
        Shoot,
        Invincible,
        Big
    } // all different available powerups

    // Serialized variables
    [SerializeField] Powerups currentPowerup;

    // Unity function
    private void OnTriggerEnter2D(Collider2D hitInfo) // Switches the player state to the corresponding powerup state
    {
        if (hitInfo.gameObject.CompareTag("Player"))
        {
            switch (currentPowerup)
            {
                case Powerups.Shoot:
                    hitInfo.GetComponent<StatePatternPlayer>().ToShootingPlayer();
                    break;
                case Powerups.Invincible:
                    hitInfo.GetComponent<StatePatternPlayer>().ToInvinciblePlayer();
                    break;
                case Powerups.Big:
                    hitInfo.GetComponent<StatePatternPlayer>().ToBigPlayer();
                    break;
                default:
                    break;
            }

            Destroy(this.gameObject);
        }
    }
}
