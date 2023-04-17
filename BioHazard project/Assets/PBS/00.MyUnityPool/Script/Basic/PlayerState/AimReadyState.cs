using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimReadyState : BaseMachine
{
    public override void OnEnterState()
    {
        ResetWeapon();
    }

    public override void OnUpdateState()
    {

    }

    public override void OnFixedUpdateState()
    {

    }

    public override void OnExitState()
    {
        EndAim();
        Player1.Instance.P_RB.velocity = Vector3.zero;
    }

    public void ResetWeapon()
    {
        switch (Player1.Instance.P_weapon)
        {
            case P_WeaponStyle.None:
                Player1.Instance.P_Ani.SetBool("IsKick", true);
                Player1.Instance.P_Ani.SetBool("Isknife", false);
                Player1.Instance.P_Ani.SetBool("IsPistol", false);
                Player1.Instance.P_Ani.SetBool("IsRifle", false);
                break;
            case P_WeaponStyle.knife:
                Player1.Instance.P_Ani.SetBool("IsKick", false);
                Player1.Instance.P_Ani.SetBool("Isknife", true);
                Player1.Instance.P_Ani.SetBool("IsPistol", false);
                Player1.Instance.P_Ani.SetBool("IsRifle", false);
                break;
            case P_WeaponStyle.pistol:
                Player1.Instance.P_Ani.SetBool("IsKick", false);
                Player1.Instance.P_Ani.SetBool("Isknife", false);
                Player1.Instance.P_Ani.SetBool("IsPistol", true);
                Player1.Instance.P_Ani.SetBool("IsRifle", false);
                break;
            case P_WeaponStyle.rifle:
                Player1.Instance.P_Ani.SetBool("IsKick", false);
                Player1.Instance.P_Ani.SetBool("Isknife", false);
                Player1.Instance.P_Ani.SetBool("IsPistol", false);
                Player1.Instance.P_Ani.SetBool("IsRifle", true);
                break;
        }
    }

    public void EndAim()
    {
        Player1.Instance.P_Ani.SetBool("IsKick", false);
        Player1.Instance.P_Ani.SetBool("Isknife", false);
        Player1.Instance.P_Ani.SetBool("IsPistol", false);
        Player1.Instance.P_Ani.SetBool("IsRifle", false);
    }
}
