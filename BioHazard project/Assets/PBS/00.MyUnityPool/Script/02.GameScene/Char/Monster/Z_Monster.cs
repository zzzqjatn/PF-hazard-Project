using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Z_Monster : Singleton<Player>
{
    public Rigidbody P_RB { get; private set; }
    public Animator P_Ani { get; private set; }
    public PlayerStateMachine P_State { get; private set; }
    public CapsuleCollider P_Collider { get; private set; }
    public P_StateMachine P_AniState { get; private set; }
    public P_WeaponStyle P_weapon { get; private set; }

    protected override void Init()
    {
        P_RB = this.gameObject.GetComponent<Rigidbody>();
        P_Ani = this.gameObject.GetComponent<Animator>();
        P_Collider = this.gameObject.GetComponent<CapsuleCollider>();
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
        P_weapon = P_WeaponStyle.None;
        P_State = new PlayerStateMachine(P_StateMachine.Idle, new IdleState());
        P_State.AddState(P_StateMachine.Walk, new WalkState());
        P_State.AddState(P_StateMachine.BackWalk, new BWalkState());
        P_State.AddState(P_StateMachine.Turnning, new TurnningState());
        P_State.AddState(P_StateMachine.Run, new RunState());
        P_State.AddState(P_StateMachine.AimReady, new AimReadyState());
    }

    public void ChangeAniState(P_StateMachine changeInput)
    {
        P_AniState = changeInput;
        P_State.ChangeState(P_AniState);
    }

    public void ChangeWeapon(P_WeaponStyle changeInput)
    {
        P_weapon = changeInput;
    }

    public void TestChangeWeapon()
    {
        P_weapon += 1;
        if ((int)P_weapon > 4) P_weapon = P_WeaponStyle.None;
    }
}