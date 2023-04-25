using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BWalkState : BaseMachine
{

    public override void OnEnterState()
    {
        Player.Instance.P_Ani.SetBool("BWalk", true);
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
        Player.Instance.P_Ani.SetBool("BWalk", false);
        Player.Instance.P_RB.velocity = new Vector3(0.0f, Player.Instance.P_RB.velocity.y, 0.0f);
    }

    private void Move()
    {
        Vector3 temp = PlayerController.Instance.GetMoveMent();
        Player.Instance.P_RB.velocity = new Vector3(temp.x, Player.Instance.P_RB.velocity.y, temp.z);
        Player.Instance.transform.Rotate(Vector3.up, PlayerController.Instance.GetTurnDir() * (1.2f));
    }
}
