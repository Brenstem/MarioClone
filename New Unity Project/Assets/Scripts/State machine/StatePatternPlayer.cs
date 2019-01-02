using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatePatternPlayer : MonoBehaviour
{
    public ParticleSystem BigPlayerEffect;
    public ParticleSystem InvincibleEffect;
    public ParticleSystem CanShootEffect;

    private IPowerupState mCurrentState;
    public IPowerupState CurrentState { get { return mCurrentState; } set { mCurrentState = value; } }
    private BigState mBigState;
    public BigState BigState { get { return mBigState; } set { mBigState = value; } }
    private NormalState mNormalState;
    public NormalState NormalState { get { return mNormalState; } set { mNormalState = value; } }
    private ShootingState mShootingState;
    public ShootingState ShootingState { get { return mShootingState; } set { mShootingState = value; } }
    private InvincibleState mInvincibleState;
    public InvincibleState InvincibleState { get { return mInvincibleState; } set { mInvincibleState = value; } }

    [HideInInspector] public float initXSize;
    [HideInInspector] public float initYSize;

    private void Awake()
    {
        NormalState = new NormalState(this);
        BigState = new BigState(this);
        ShootingState = new ShootingState(this);
        InvincibleState = new InvincibleState(this);
    }

    private void Start()
    {
        GetComponent<Transform>().localScale = new Vector2(GetComponent<Transform>().localScale.x, GetComponent<Transform>().localScale.y) * 1.5f;

        initXSize = GetComponent<Transform>().localScale.x;
        initYSize = GetComponent<Transform>().localScale.y;

        CurrentState = NormalState;
    }

    private void Update()
    {
        CurrentState.PowerupEffect();
    }

    public void ToBigPlayer()
    {
        CurrentState = BigState;
    }

    public void ToInvinciblePlayer()
    {
        CurrentState = InvincibleState;
    }

    public void ToNormalPlayer()
    {
        CurrentState = NormalState;
    }

    public void ToShootingPlayer()
    {
        CurrentState = ShootingState;
    }
}
