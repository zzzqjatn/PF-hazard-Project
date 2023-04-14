using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : BaseMachine
{
    public override void OnEnterState()
    {
        Player1.Instance.P_Ani.SetBool("Idle", true);
    }

    public override void OnUpdateState()
    {

    }

    public override void OnFixedUpdateState()
    {

    }

    public override void OnExitState()
    {
        Player1.Instance.P_Ani.SetBool("Idle", false);
        Player1.Instance.P_RB.velocity = Vector3.zero;
    }
}
