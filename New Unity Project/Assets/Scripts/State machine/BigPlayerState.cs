using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigState : IPowerupState
{
    private readonly StatePatternPlayer player;
    private ParticleSystem ps;
    bool running = true;

    public BigState(StatePatternPlayer p)
    {
        player = p;
    }

    public void PowerupEffect()
    {
        while (running)
        {
            Transform pTransform = player.GetComponent<Transform>();

            pTransform.localScale = new Vector2(pTransform.localScale.x, pTransform.localScale.y) * 1.5f;
            player.GetComponent<Health>().hp = 2;
            ps = GameObject.Instantiate(player.BigPlayerEffect, player.transform.position, Quaternion.identity);

            running = false;
        }

        ps.transform.position = player.transform.position;


        if (player.GetComponent<Health>().hp == 1)
        {
            ToNormalPlayer();
            GameObject.Destroy(ps);
        }
    }


    public void ToBigPlayer()
    {
        Debug.Log("Can't transition to same state");
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
        player.CurrentState = player.ShootingState;
    }
}
