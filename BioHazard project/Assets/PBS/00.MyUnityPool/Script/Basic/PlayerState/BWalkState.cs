using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BWalkState : BaseMachine
{

    public override void OnEnterState()
    {
        Player1.Instance.P_Ani.SetBool("BWalk", true);
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
        Player1.Instance.P_Ani.SetBool("BWalk", false);
        Player1.Instance.P_RB.velocity = Vector3.zero;
    }

    private void Move()
    {
        Player1.Instance.P_RB.velocity = PlayerController.Instance.GetMoveMent();
    }
}
