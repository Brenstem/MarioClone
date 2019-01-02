using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatePatternPlayer : MonoBehaviour
{
    public IPowerupState currentState { get { return currentState; } set { currentState = value; } }
    public BigState bigState { get { return bigState; } set { bigState = value; } }
    public NormalState normalState { get { return normalState; } set { normalState = value; } }
    public ShootingState shootingState { get { return shootingState; } set { shootingState = value; } }
    public InvincibleState invincibleState { get { return invincibleState; } set { invincibleState = value; } }

    private void Awake()
    {
        normalState = new NormalState(this);
        bigState = new BigState(this);
        shootingState = new ShootingState(this);
        invincibleState = new InvincibleState(this);
    }

    private void Start()
    {
        currentState = normalState;
    }

    private void Update()
    {
        currentState.PowerupEffect();
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        currentState.OnTriggerEnter2D(hitInfo);
    }
}
