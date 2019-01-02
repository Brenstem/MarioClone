using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingState : IPowerupState
{
    private readonly StatePatternPlayer player;

    public ShootingState(StatePatternPlayer p)
    {
        player = p;
    }

    public void OnTriggerEnter2D(Collider2D hitinfo)
    {
        throw new System.NotImplementedException();
    }

    public void PowerupEffect()
    {
        throw new System.NotImplementedException();
    }

    public void PowerupExpiration()
    {
        throw new System.NotImplementedException();
    }

    // 
    public void ToBigPlayer()
    {
        player.currentState = player.bigState;
    }

    public void ToIncinviblePlayer()
    {
        player.currentState = player.invincibleState;
    }

    public void ToNormalPlayer()
    {
        player.currentState = player.normalState;
    }

    public void ToShootingPlayer()
    {
        Debug.Log("Can't transition to same state");
    }
}
