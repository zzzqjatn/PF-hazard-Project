using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimReadyState : BaseMachine
{
    public override void OnEnterState()
    {
        Player1.Instance.P_Ani.SetBool("IsPistol", true);
    }

    public override void OnUpdateState()
    {

    }

    public override void OnFixedUpdateState()
    {

    }

    public override void OnExitState()
    {
        Player1.Instance.P_Ani.SetBool("IsPistol", false);
        Player1.Instance.P_RB.velocity = Vector3.zero;
    }
}
