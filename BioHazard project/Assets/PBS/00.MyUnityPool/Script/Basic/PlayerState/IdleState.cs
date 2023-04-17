using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : BaseMachine
{
    public override void OnEnterState()
    {
        Player.Instance.P_Ani.SetBool("Idle", true);
        // PlayerController.Instance.SetBody_P(new Vector3(0.0f, 1.50f, -0.5f));
        // PlayerController.Instance.SetHead_P(new Vector3(0.0f, 1.80f, -1.0f));
    }

    public override void OnUpdateState()
    {

    }

    public override void OnFixedUpdateState()
    {

    }

    public override void OnExitState()
    {
        Player.Instance.P_Ani.SetBool("Idle", false);
        Player.Instance.P_RB.velocity = Vector3.zero;
    }
}
