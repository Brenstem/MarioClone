using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalState : IPowerupState
{
    private readonly StatePatternPlayer player;
    private bool running = true;
    public NormalState(StatePatternPlayer p)
    {
        player = p;
    }

    public void PowerupEffect()
    {
        while (running)
        {
            player.GetComponent<Health>().hp = 1;
            player.GetComponent<Health>().CanDie = true;
            player.GetComponent<Weapon>().canFire = false;
            player.GetComponent<Transform>().localScale = new Vector2(player.GetComponent<Transform>().localScale.x, player.GetComponent<Transform>().localScale.y) / 1.5f;

            running = false;
        }
    }

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
        Debug.Log("Can't transition to same state");
    }

    public void ToShootingPlayer()
    {
        player.CurrentState = player.ShootingState;
    }
}
