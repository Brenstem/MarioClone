using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigState : IPowerupState
{
    // Private variables
    private readonly StatePatternPlayer player;
    private ParticleSystem ps;
    private bool running = true;

    // Constructor
    public BigState(StatePatternPlayer p)
    {
        player = p;
    }

    // Active function
    public void PowerupEffect()
    {
        while (running) // Runs once on state activation
        {
            Transform pTransform = player.GetComponent<Transform>();

            pTransform.localScale = new Vector2(pTransform.localScale.x, pTransform.localScale.y) * 1.5f;
            player.GetComponent<Health>().hp = 2;
            ps = GameObject.Instantiate(player.BigPlayerEffect, player.transform.position, Quaternion.identity);

            running = false;
        }

        ps.transform.position = player.transform.position;

        if (player.GetComponent<Health>().hp == 1) // Exit condition
        {
            ToNormalPlayer();
            running = true;
            GameObject.Destroy(ps);
        }
    }

    // Exit function
    public void ToNormalPlayer()
    {
        player.CurrentState = player.NormalState;
    }
}
