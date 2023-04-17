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
        Vector3 temp = PlayerController.Instance.GetMoveMent();
        Player1.Instance.P_RB.velocity = new Vector3(temp.x, Player1.Instance.P_RB.velocity.y, temp.z);
        Player1.Instance.transform.Rotate(Vector3.up, PlayerController.Instance.GetTurnDir() * (1.2f));
    }
}
