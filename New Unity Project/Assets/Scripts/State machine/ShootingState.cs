using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingState : IPowerupState
{
    private readonly StatePatternPlayer player;
    private float powerupLength = 10;
    private float powerupTimer;
    private bool running = true;
    private ParticleSystem ps;

    public ShootingState(StatePatternPlayer p)
    {
        player = p;
    }


    public void PowerupEffect()
    {
        
        powerupTimer += Time.deltaTime;

        while (running)
        {
            player.GetComponent<Weapon>().canFire = true;
            running = false;
            ps = GameObject.Instantiate(player.CanShootEffect, player.transform.position, Quaternion.identity);
        }

        ps.transform.position = player.transform.position;

        if (powerupTimer > powerupLength)
        {
            ToNormalPlayer();
            GameObject.Destroy(ps);
        }
    }

    // 
    public void ToBigPlayer()
    {
        player.CurrentState = player.BigState;
    }

    public void ToInvinciblePlayer()
    {
        player.CurrentState = player.InvincibleState;
    }

    public void ToNormalPlayer()
    {
        player.CurrentState = player.NormalState;
    }

    public void ToShootingPlayer()
    {
        Debug.Log("Can't transition to same state");
    }
}
