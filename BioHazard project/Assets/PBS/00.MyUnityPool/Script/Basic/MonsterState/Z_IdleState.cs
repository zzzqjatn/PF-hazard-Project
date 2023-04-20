using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Z_IdleState : BaseMachine
{
    public override void OnEnterState()
    {
        Z_Monster.Instance.Z_Ani.SetBool("Idle", true);
    }

    public override void OnUpdateState()
    {

    }

    public override void OnFixedUpdateState()
    {

    }

    public override void OnExitState()
    {
        Z_Monster.Instance.Z_Ani.SetBool("Idle", false);
    }
}
