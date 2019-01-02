using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibleState : IPowerupState
{
    private readonly StatePatternPlayer player;
    private bool running = true;
    private ParticleSystem ps;
    private float powerupTimer;
    private int powerupLength = 5;

    public InvincibleState(StatePatternPlayer p)
    {
        player = p;
    }

    public void PowerupEffect()
    {
        powerupTimer += Time.deltaTime;

        while (running)
        {
            player.GetComponent<Health>().CanDie = false;
            ps = GameObject.Instantiate(player.InvincibleEffect, player.transform.position, Quaternion.identity);
            running = false;
        }

        ps.transform.position = player.transform.position;

        if (powerupTimer > powerupLength)
        {
            ToNormalPlayer();
            GameObject.Destroy(ps);
        }
    }

    public void PowerupExpiration()
    {

    }

    public void ToBigPlayer()
    {
        player.CurrentState = player.BigState;
    }

    public void ToInvinciblePlayer()
    {
        Debug.Log("Can't transition to same state");
    }

    public void ToNormalPlayer()
    {
        player.CurrentState = player.NormalState;
    }

    public void ToShootingPlayer()
    {
        player.CurrentState = player.ShootingState;
    }
}
