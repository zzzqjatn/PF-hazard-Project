using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Z_Turnning : BaseMachine
{
    Z_Monster Z_monster;
    Z_MonsterController Z_control;

    private int RandomTurn;
    public override void OnEnterState()
    {
        RandomTurn = Random.Range(1, 3);

        if (RandomTurn == 1)
        {
            Z_monster.Z_Ani.SetBool("Turnning", true);
        }
        else if (RandomTurn == 2)
        {
            Z_monster.Z_Ani.SetBool("TurnningL", true);
        }
        Z_control.SetNavOffsetY(-0.05f);
    }

    public override void OnUpdateState()
    {

    }

    public override void OnFixedUpdateState()
    {
        TurnningMove();
    }

    public override void OnExitState()
    {
        if (RandomTurn == 1)
        {
            Z_monster.Z_Ani.SetBool("Turnning", false);
        }
        else if (RandomTurn == 2)
        {
            Z_monster.Z_Ani.SetBool("TurnningL", false);
        }
    }

    private void TurnningMove()
    {
        if (Z_monster.Z_Ani.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.8f)
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
