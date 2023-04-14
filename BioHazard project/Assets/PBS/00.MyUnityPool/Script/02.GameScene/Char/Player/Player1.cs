using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : Singleton<Player1>
{
    public Rigidbody P_RB;
    public Animator P_Ani;
    public PlayerStateMachine P_State;
    public CapsuleCollider P_Collider;
    public P_StateMachine P_AniState;

    protected override void Init()
    {
        P_RB = this.gameObject.GetComponent<Rigidbody>();
        P_Ani = this.gameObject.GetComponent<Animator>();
        P_Collider = this.gameObject.GetComponent<CapsuleCollider>();

        P_AniState = P_StateMachine.Idle;
    }

    void Start()
    {
        InitStateMachine();
    }

    void Update()
    {
        P_State?.UpdateState();
    }

    private void FixedUpdate()
    {
        P_State?.FixedUpdateState();
    }

    private void InitStateMachine()
    {
        PlayerController P_contorllor = GetComponent<PlayerController>();
        P_State = new PlayerStateMachine(P_StateMachine.Idle, new IdleState());
        P_State.AddState(P_StateMachine.Walk, new WalkState());
    }
}

public enum P_StateMachine
{
    None = -1, Idle, Walk, BackWalk, Turnning, Run, ShotReady, Fire, KnifeReady, Attack
}