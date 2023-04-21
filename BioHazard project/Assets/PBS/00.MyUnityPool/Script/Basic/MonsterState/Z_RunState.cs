using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Z_RunState : BaseMachine
{
    Z_Monster Z_monster;
    Z_MonsterController Z_control;

    Quaternion targetRot;
    float F_Angle;
    public override void OnEnterState()
    {
        Z_monster.Z_Ani.SetBool("Run", true);
        Z_control.SetNavOffsetY(-0.1f);

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
        Z_monster.Z_Ani.SetBool("Run", false);
    }

    private void MoveMonster()
    {
        Vector3 targetDir = (Z_control.targetPos.position - Z_control.Trans.position).normalized;
        Quaternion targetRot = Quaternion.FromToRotation(Z_control.Trans.forward, targetDir) * Z_control.Trans.rotation;

        F_Angle = Quaternion.Angle(Z_control.Trans.rotation, targetRot);
        //distance
        // Z_control.SetTranRot(Quaternion.Slerp(Z_control.Z_Trans.rotation, targetRot, Time.deltaTime * 2.0f));

        // if (F_Angle <= 0.1f)
        // {

        // }
        // else
        // {
        //     F_Angle = Quaternion.Angle(Z_control.Z_Trans.rotation, targetRot);
        //     Z_control.SetTranRot(Quaternion.Slerp(Z_control.Z_Trans.rotation, targetRot, Time.deltaTime * 2.0f));
        // }
    }
    public void SetController(Z_Monster zMon, Z_MonsterController zCon)
    {
        Z_monster = zMon;
        Z_control = zCon;
    }
}
