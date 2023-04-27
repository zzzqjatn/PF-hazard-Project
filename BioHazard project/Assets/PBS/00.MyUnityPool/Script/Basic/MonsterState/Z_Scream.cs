using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Z_Scream : BaseMachine
{
    Z_Monster Z_monster;
    Z_MonsterController Z_control;
    public override void OnEnterState()
    {
        Z_monster.Z_Ani.SetBool("Scream", true);
        Z_control.SetNavOffsetY(-0.05f);
    }

    public override void OnUpdateState()
    {

    }

    public override void OnFixedUpdateState()
    {
        if (Z_control.IsFind == false)
        {
            AniEnd();
        }
    }

    public override void OnExitState()
    {
        Z_monster.Z_Ani.SetBool("Scream", false);
    }

    private void AniEnd()
    {
        if (Z_monster.Z_Ani.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.9f)
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
