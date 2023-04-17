using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnningState : BaseMachine
{
    public override void OnEnterState()
    {
        Player1.Instance.P_Ani.SetBool("Walk", true);
    }

    public override void OnUpdateState()
    {

    }

    public override void OnFixedUpdateState()
    {
        TurnMove();
    }

    public override void OnExitState()
    {
        Player1.Instance.P_Ani.SetBool("Walk", false);
        Player1.Instance.P_RB.velocity = Vector3.zero;
    }

    private void TurnMove()
    {
        Player1.Instance.transform.Rotate(Vector3.up, PlayerController.Instance.GetTurnDir());
    }
}
