using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Z_WalkState : BaseMachine
{
    Z_Monster Z_monster;
    Z_MonsterController Z_control;
    float F_Angle;

    public override void OnEnterState()
    {
        Z_monster.Z_Ani.SetBool("Walk", true);
        Z_control.SetNavOffsetY(-0.1f);

        Z_control.Agent.speed = 0;
        Z_control.Agent.angularSpeed = 20;
        Z_control.Agent.SetDestination(Z_control.targetPos.position);
    }

    public override void OnUpdateState()
    {

    }

    public override void OnFixedUpdateState()
    {
        MoveMonster();
    }

    public override void OnExitState()
    {
        Z_monster.Z_Ani.SetBool("Walk", false);
    }

    private void MoveMonster()
    {
        Vector3 targetDir = (Z_control.targetPos.position - Z_control.Trans.position).normalized;

        F_Angle = Vector3.Angle(targetDir, Z_control.Trans.forward);
        Z_control.SetTranRot(Quaternion.Slerp(Z_control.Trans.rotation, Quaternion.LookRotation(targetDir), Time.deltaTime * 2.0f));
        Debug.Log(F_Angle);

        if (F_Angle <= 1.0f)
        {
            Z_control.Agent.speed = 1;
        }

        // float targetDis = Vector3.Distance(Z_control.targetPos, Z_control.Trans.position);
        // Debug.Log(targetDis);

        // if (targetDis <= 0.1f)
        // {
        //     Z_control.IsMoving = true;
        // }
    }

    public void SetController(Z_Monster zMon, Z_MonsterController zCon)
    {
        Z_monster = zMon;
        Z_control = zCon;
    }
}
