using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalState : IPowerupState
{
    // Private variables
    private readonly StatePatternPlayer player;
    private bool running = true;

    // Properties
    public bool Running { get { return running; } set { running = value; } }

    // Constructor
    public NormalState(StatePatternPlayer p)
    {
        player = p;
    }

    // Active function
    public void PowerupEffect()
    {
        while (Running) // Runs on state activation
        {
            player.GetComponent<Health>().hp = 1;
            player.GetComponent<Health>().CanDie = true;
            player.GetComponent<Weapon>().CanFire = false;
            player.GetComponent<Transform>().localScale = new Vector2(1, 1);

            Running = false;
        }
    }

    // Not implimented from interface
    public void ToNormalPlayer()
    {
        Debug.Log("Can't transition to same state");
    }
}
