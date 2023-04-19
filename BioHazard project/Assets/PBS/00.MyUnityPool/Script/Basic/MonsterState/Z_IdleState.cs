using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Z_IdleState : BaseMachine
{
    public override void OnEnterState()
    {
        Player.Instance.P_Ani.SetBool("Idle", true);
    }

    public override void OnUpdateState()
    {

    }

    public override void OnFixedUpdateState()
    {

    }

    public override void OnExitState()
    {
        Player.Instance.P_Ani.SetBool("Idle", false);
        Player.Instance.P_RB.velocity = Vector3.zero;
    }
}
