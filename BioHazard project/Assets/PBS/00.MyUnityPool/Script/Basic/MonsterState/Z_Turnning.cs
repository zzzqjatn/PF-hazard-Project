using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Z_Turnning : BaseMachine
{
    Z_Monster Z_monster;
    Z_MonsterController Z_control;

    public override void OnEnterState()
    {
        Z_monster.Z_Ani.SetBool("Turnning", true);
        Z_control.SetNavOffsetY(-0.05f);
    }

    public override void OnUpdateState()
    {

    }

    public override void OnFixedUpdateState()
    {

    }

    public override void OnExitState()
    {
        Z_monster.Z_Ani.SetBool("Turnning", false);
    }

    public void SetController(Z_Monster zMon, Z_MonsterController zCon)
    {
        Z_monster = zMon;
        Z_control = zCon;
    }
}
