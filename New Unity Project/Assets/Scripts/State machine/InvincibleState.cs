using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibleState : IPowerupState
{
    // Private variables
    private readonly StatePatternPlayer player;
    private ParticleSystem ps;
    private bool running = true;
    private float powerupTimer;
    private int powerupLength = 5;

    // Constructor
    public InvincibleState(StatePatternPlayer p)
    {
        player = p;
    }

    // Active function
    public void PowerupEffect()
    {
        powerupTimer += Time.deltaTime;

        while (running) // Runs once on state activation
        {
            player.GetComponent<Health>().CanDie = false;
            ps = GameObject.Instantiate(player.InvincibleEffect, player.transform.position, Quaternion.identity);
            running = false;
        }

        ps.transform.position = player.transform.position;

        if (powerupTimer > powerupLength) // Exit conditions
        {
            ToNormalPlayer();
            running = true;
            GameObject.Destroy(ps);
        }
    }

    // Return function
    public void ToNormalPlayer()
    {
        player.CurrentState = player.NormalState; 
    }
}
