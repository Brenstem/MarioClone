using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingState : IPowerupState
{
    // Private variables
    private readonly StatePatternPlayer player;
    private float powerupLength = 10;
    private float powerupTimer;
    private bool running = true;
    private ParticleSystem ps;

    // Constructor
    public ShootingState(StatePatternPlayer p)
    {
        player = p;
    }

    // Active function
    public void PowerupEffect()
    {
        
        powerupTimer += Time.deltaTime;

        while (running) // Runs once on state activation
        {
            player.GetComponent<Weapon>().CanFire = true;
            ps = GameObject.Instantiate(player.CanShootEffect, player.transform.position, Quaternion.identity);
            running = false;
        }

        ps.transform.position = player.transform.position;

        if (powerupTimer > powerupLength) // Exit conditions
        {
            ToNormalPlayer();
            GameObject.Destroy(ps);
        }
    }

    // Exit function
    public void ToNormalPlayer()
    {
        player.CurrentState = player.NormalState;
    }
}
