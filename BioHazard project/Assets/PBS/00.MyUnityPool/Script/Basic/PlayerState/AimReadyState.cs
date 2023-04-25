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
        Player.Instance.P_RB.velocity = new Vector3(0.0f, Player.Instance.P_RB.velocity.y, 0.0f);
    }

    public void ResetWeapon()
    {
        switch (Player.Instance.P_weapon)
        {
            case P_WeaponStyle.None:
                Player.Instance.P_Ani.SetBool("IsKick", true);
                Player.Instance.P_Ani.SetBool("Isknife", false);
                Player.Instance.P_Ani.SetBool("IsPistol", false);
                Player.Instance.P_Ani.SetBool("IsRifle", false);
                break;
            case P_WeaponStyle.knife:
                Player.Instance.P_Ani.SetBool("IsKick", false);
                Player.Instance.P_Ani.SetBool("Isknife", true);
                Player.Instance.P_Ani.SetBool("IsPistol", false);
                Player.Instance.P_Ani.SetBool("IsRifle", false);
                break;
            case P_WeaponStyle.pistol:
                Player.Instance.P_Ani.SetBool("IsKick", false);
                Player.Instance.P_Ani.SetBool("Isknife", false);
                Player.Instance.P_Ani.SetBool("IsPistol", true);
                Player.Instance.P_Ani.SetBool("IsRifle", false);
                break;
            case P_WeaponStyle.rifle:
                Player.Instance.P_Ani.SetBool("IsKick", false);
                Player.Instance.P_Ani.SetBool("Isknife", false);
                Player.Instance.P_Ani.SetBool("IsPistol", false);
                Player.Instance.P_Ani.SetBool("IsRifle", true);
                break;
        }
    }

    public void EndAim()
    {
        Player.Instance.P_Ani.SetBool("IsKick", false);
        Player.Instance.P_Ani.SetBool("Isknife", false);
        Player.Instance.P_Ani.SetBool("IsPistol", false);
        Player.Instance.P_Ani.SetBool("IsRifle", false);
    }
}
