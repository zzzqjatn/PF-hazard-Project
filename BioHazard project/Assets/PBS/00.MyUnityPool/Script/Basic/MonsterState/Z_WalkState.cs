using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Z_WalkState : BaseMachine
{
    Z_Monster Z_monster;
    Z_MonsterController Z_control;
    // float F_Angle;

    public override void OnEnterState()
    {
        Z_monster.Z_Ani.SetBool("Walk", true);
        Z_control.SetNavOffsetY(-0.1f);

        Z_control.Agent.speed = 0.8f;
        Z_control.Agent.SetDestination(Z_control.targetPos.position);
    }

    public override void OnUpdateState()
    {

    }

    public override void OnFixedUpdateState()
    {
        MoveCheckMonster();
    }

    public override void OnExitState()
    {
        Z_monster.Z_Ani.SetBool("Walk", false);
    }

    private void MoveCheckMonster()
    {
        Vector3 targetDir = (Z_control.targetPos.position - Z_control.transform.position).normalized;
        targetDir.y = 0;

        // F_Angle = Vector3.Angle(targetDir, Z_control.transform.forward);
        // Z_control.SetTranRot(Quaternion.Slerp(Z_control.transform.rotation, Quaternion.LookRotation(targetDir), Time.deltaTime * 2.0f));

        float targetDis = Vector3.Distance(Z_control.targetPos.position, Z_control.transform.position);

        if (targetDis <= 0.3f)
        {
            Z_control.StopAndResetMotion();
        }
    }

    public void SetController(Z_Monster zMon, Z_MonsterController zCon)
    {
        Z_monster = zMon;
        Z_control = zCon;
    }
}
