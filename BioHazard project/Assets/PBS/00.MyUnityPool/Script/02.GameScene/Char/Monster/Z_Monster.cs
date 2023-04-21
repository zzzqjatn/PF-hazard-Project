using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Z_Monster : MonoBehaviour
{
    public Rigidbody Z_RB { get; private set; }
    public Animator Z_Ani { get; private set; }
    public CapsuleCollider Z_Collider { get; private set; }
    public Z_MonsterStateMachine Z_State { get; private set; }
    public Z_StateMachine Z_AniState { get; private set; }

    void Start()
    {
        Z_RB = this.gameObject.GetComponent<Rigidbody>();
        Z_Ani = this.gameObject.GetComponent<Animator>();
        Z_Collider = this.gameObject.GetComponent<CapsuleCollider>();
        InitStateMachine();
    }

    void Update()
    {
        Z_State?.UpdateState();
    }

    private void FixedUpdate()
    {
        Z_State?.FixedUpdateState();
    }

    private void InitStateMachine()
    {
        Z_MonsterController Z_contorllor = GetComponent<Z_MonsterController>();

        Z_IdleState idle = new Z_IdleState();
        Z_WalkState walk = new Z_WalkState();
        Z_RunState run = new Z_RunState();

        idle.SetController(this, Z_contorllor);
        walk.SetController(this, Z_contorllor);
        run.SetController(this, Z_contorllor);

        Z_State = new Z_MonsterStateMachine(Z_StateMachine.Idle, idle);
        Z_State.AddState(Z_StateMachine.Walk, walk);
        Z_State.AddState(Z_StateMachine.Run, run);
    }

    public void ChangeAniState(Z_StateMachine changeInput)
    {
        Z_AniState = changeInput;
        Z_State.ChangeState(Z_AniState);
    }
}