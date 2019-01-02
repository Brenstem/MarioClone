using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatePatternPlayer : MonoBehaviour
{
    // Serialized variables
    [SerializeField] private ParticleSystem bigPlayerEffect;
    [SerializeField] private ParticleSystem invincibleEffect;
    [SerializeField] private ParticleSystem canShootEffect;

    // Properties
    private IPowerupState mCurrentState;
    public IPowerupState CurrentState { get { return mCurrentState; } set { mCurrentState = value; } }
    public ParticleSystem BigPlayerEffect { get { return bigPlayerEffect; } set { bigPlayerEffect = value; } }
    public ParticleSystem InvincibleEffect { get { return invincibleEffect; } set { invincibleEffect = value; } }
    public ParticleSystem CanShootEffect { get { return canShootEffect; } set { canShootEffect = value; } }
    private BigState mBigState;
    public BigState BigState { get { return mBigState; } set { mBigState = value; } }
    private NormalState mNormalState;
    public NormalState NormalState { get { return mNormalState; } set { mNormalState = value; } }
    private ShootingState mShootingState;
    public ShootingState ShootingState { get { return mShootingState; } set { mShootingState = value; } }
    private InvincibleState mInvincibleState;
    public InvincibleState InvincibleState { get { return mInvincibleState; } set { mInvincibleState = value; } }

    // Unity functions
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

        CurrentState = NormalState;
    }

    private void Update()
    {
        CurrentState.PowerupEffect();

        if (CurrentState != NormalState)
        {
            NormalState.Running = true;
        }
    }

    // Public function
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
        Debug.Log("To normal state");
    }

    public void ToShootingPlayer()
    {
        CurrentState = ShootingState;
    }
}
