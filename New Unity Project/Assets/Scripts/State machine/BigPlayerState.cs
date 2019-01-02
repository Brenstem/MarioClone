using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigState : IPowerupState
{
    private readonly StatePatternPlayer player;

    public BigState(StatePatternPlayer p)
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
        Debug.Log("Can't transition to same state");
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
        player.currentState = player.shootingState;
    }
}
