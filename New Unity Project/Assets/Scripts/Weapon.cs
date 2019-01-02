using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Inspector variables 
    [SerializeField] Transform firepoint;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float fireRate;
    [SerializeField] bool autoFire;

    // Properties
    private bool mCanFire = false;
    public bool CanFire { get { return mCanFire; } set { mCanFire = value; } }

    // private variables
    private float fireTimer = 0;
    private Vector2 firePosition;

    // Unity functions
    private void Update()
    {
        if (CanFire)
        {
            Shoot();
        }
    }

    // Instantiates bullets at firepoint if it's been long enough since the last shot
    public void Shoot()
    {
        if (CanFire)
        {
            fireTimer += Time.deltaTime;
            float fire = Input.GetAxisRaw("Fire1");

            if (!autoFire)
            {
                if (fire == 1 && fireTimer > fireRate)
                {
                    Instantiate(bulletPrefab, firepoint.position, transform.rotation);
                    fireTimer = 0;
                }
            }
            else if (autoFire)
            {
                if (fireTimer > fireRate)
                {
                    Instantiate(bulletPrefab, firepoint.position, transform.rotation);
                    fireTimer = 0;
                }
            }
        }
    }
}
