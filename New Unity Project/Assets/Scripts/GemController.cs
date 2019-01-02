using UnityEngine;

public class GemController : MonoBehaviour
{
    enum Powerup
    {
        Shoot,
        Invincible,
        Big
    }

    [SerializeField] Powerup currentPowerup;

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.CompareTag("Player"))
        {
            switch (currentPowerup)
            {
                case Powerup.Shoot:
                    hitInfo.GetComponent<StatePatternPlayer>().ToShootingPlayer();
                    break;
                case Powerup.Invincible:
                    hitInfo.GetComponent<StatePatternPlayer>().ToInvinciblePlayer();
                    break;
                case Powerup.Big:
                    hitInfo.GetComponent<StatePatternPlayer>().ToBigPlayer();
                    break;
                default:
                    break;
            }

            Destroy(this.gameObject);
        }
    }
}
