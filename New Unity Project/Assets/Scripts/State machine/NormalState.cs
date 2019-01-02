using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalState : IPowerupState
{
    private readonly StatePatternPlayer player;

    public NormalState(StatePatternPlayer p)
    {
        player = p;
    }

    public void OnTriggerEnter2D(Collider2D hitinfo)
    {
        throw new System.NotImplementedException();
    }

    public void PowerupEffect()
    {

    }

    public void PowerupExpiration()
    {

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
        Debug.Log("Can't transition to same state");
    }

    public void ToShootingPlayer()
    {
        player.currentState = player.shootingState;
    }
}
