using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : BaseMachine
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
        Move();
    }

    public override void OnExitState()
    {
        Player1.Instance.P_Ani.SetBool("Walk", false);
        Player1.Instance.P_RB.velocity = Vector3.zero;
    }

    private void Move()
    {
        Player1.Instance.P_RB.velocity = PlayerController.Instance.GetMoveMent();
    }
}
