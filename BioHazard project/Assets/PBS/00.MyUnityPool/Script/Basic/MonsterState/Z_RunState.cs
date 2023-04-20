using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Z_RunState : BaseMachine
{
    public override void OnEnterState()
    {
        Z_Monster.Instance.Z_Ani.SetBool("Run", true);
    }

    public override void OnUpdateState()
    {

    }

    public override void OnFixedUpdateState()
    {
        moving();
    }

    public override void OnExitState()
    {
        Z_Monster.Instance.Z_Ani.SetBool("Run", false);
    }
    private void moving()
    {
        Z_MonsterController.Instance.Z_Agent.SetDestination(Z_MonsterController.Instance.targetPos.position);
    }
}
