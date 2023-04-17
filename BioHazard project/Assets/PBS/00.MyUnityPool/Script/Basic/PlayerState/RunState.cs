using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : BaseMachine
{
    public override void OnEnterState()
    {
        Player1.Instance.P_Ani.SetBool("Run", true);
    }

    public override void OnUpdateState()
    {

    }

    public override void OnFixedUpdateState()
    {
        Run();
    }

    public override void OnExitState()
    {
        Player1.Instance.P_Ani.SetBool("Run", false);
        Player1.Instance.P_RB.velocity = Vector3.zero;
    }

    private void Run()
    {
        Vector3 temp = PlayerController.Instance.GetMoveMent();
        Player1.Instance.P_RB.velocity = new Vector3(temp.x, Player1.Instance.P_RB.velocity.y, temp.z);
        Player1.Instance.transform.Rotate(Vector3.up, PlayerController.Instance.GetTurnDir() * (1.2f));
    }
}
