using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Singleton<PlayerController>
{
    private const float MOVE_SPEED_DEFAULT = 80.0f;
    private Player1 P_Player;
    private Ray P_ray;
    private RaycastHit P_hit;

    private GameObject HeadRigPoint;
    private GameObject BodyRigPoint;

    private float xAxis, zAxis;
    private float MoveSpeed;
    private bool IsAimming;

    private P_Timming P_Time;

    void Start()
    {
        P_Player = this.gameObject.GetComponent<Player1>();
        HeadRigPoint = this.gameObject.FindChildObj("HeadTarget");
        BodyRigPoint = this.gameObject.FindChildObj("BodyTarget");

        MoveSpeed = MOVE_SPEED_DEFAULT;
        xAxis = 0;
        zAxis = 0;

        IsAimming = false;
        P_Time = P_Timming.Fight;
    }

    void Update()
    {
        keyCon();
    }

    private void keyCon()
    {
        if (IsAimming == false)
        {
            //달리면서 회전
            if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.V))
            {
                xAxis = 1;
                zAxis = -1;
                MoveSpeed = MOVE_SPEED_DEFAULT * 2.2f;
                Player1.Instance.ChangeAniState(P_StateMachine.Run);
            }
            else if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.V))
            {
                xAxis = 1;
                zAxis = 1;
                MoveSpeed = MOVE_SPEED_DEFAULT * 2.2f;
                Player1.Instance.ChangeAniState(P_StateMachine.Run);
            }
            // 걸으면서 회전
            else if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.UpArrow))
            {
                xAxis = 1;
                zAxis = -1;
                MoveSpeed = MOVE_SPEED_DEFAULT;
                Player1.Instance.ChangeAniState(P_StateMachine.Walk);
            }
            else if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.UpArrow))
            {
                xAxis = 1;
                zAxis = 1;
                MoveSpeed = MOVE_SPEED_DEFAULT;
                Player1.Instance.ChangeAniState(P_StateMachine.Walk);
            }
            // 뒤로 회전
            else if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.DownArrow))
            {
                xAxis = -1;
                zAxis = -1;
                MoveSpeed = MOVE_SPEED_DEFAULT;
                Player1.Instance.ChangeAniState(P_StateMachine.BackWalk);
            }
            else if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.DownArrow))
            {
                xAxis = -1;
                zAxis = 1;
                MoveSpeed = MOVE_SPEED_DEFAULT;
                Player1.Instance.ChangeAniState(P_StateMachine.BackWalk);
            }
            // 달리기
            else if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.V))
            {
                xAxis = 1;
                MoveSpeed = MOVE_SPEED_DEFAULT * 2.2f;
                Player1.Instance.ChangeAniState(P_StateMachine.Run);
            }
            //걷기 뒤로 걷기
            else if (Input.GetKey(KeyCode.UpArrow))
            {
                xAxis = 1;
                MoveSpeed = MOVE_SPEED_DEFAULT;
                Player1.Instance.ChangeAniState(P_StateMachine.Walk);
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                xAxis = -1;
                MoveSpeed = MOVE_SPEED_DEFAULT * (0.8f);
                Player1.Instance.ChangeAniState(P_StateMachine.BackWalk);
            }
            //회전
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                zAxis = -1;
                MoveSpeed = MOVE_SPEED_DEFAULT;
                Player1.Instance.ChangeAniState(P_StateMachine.Turnning);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                zAxis = 1;
                MoveSpeed = MOVE_SPEED_DEFAULT;
                Player1.Instance.ChangeAniState(P_StateMachine.Turnning);
            }
            else
            {
                xAxis = 0; zAxis = 0;
            }

            if (xAxis == 0 && zAxis == 0)
            {
                Player1.Instance.ChangeAniState(P_StateMachine.Idle);
            }
        }
        else
        {
            //Aim turn?
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                zAxis = -1;
                MoveSpeed = MOVE_SPEED_DEFAULT;
                // Player1.Instance.ChangeAniState(P_StateMachine.Turnning);
                Player1.Instance.transform.Rotate(Vector3.up, GetTurnDir());
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                zAxis = 1;
                MoveSpeed = MOVE_SPEED_DEFAULT;
                // Player1.Instance.ChangeAniState(P_StateMachine.Turnning);
                Player1.Instance.transform.Rotate(Vector3.up, GetTurnDir());
            }

            //Rig Aim

            //반경 보는 방향 45도
        }

        // 확인 / 조준 / 습득 / 액션
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (P_Time == P_Timming.Question)
            {

            }
            else if (P_Time == P_Timming.Item)
            {

            }
            else if (P_Time == P_Timming.Action)
            {

            }
            else if (P_Time == P_Timming.Fight)
            {
                if (IsAimming == false && Player1.Instance.P_AniState == P_StateMachine.Idle)
                {
                    IsAimming = true;
                    Player1.Instance.ChangeAniState(P_StateMachine.AimReady);
                }
                else if (IsAimming == true && Player1.Instance.P_AniState == P_StateMachine.AimReady)
                {
                    IsAimming = false;
                    Player1.Instance.ChangeAniState(P_StateMachine.Idle);
                }
            }
        }

        // 취소 / 조준 시 발사
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (P_Time == P_Timming.Question)
            {

            }
            else if (P_Time == P_Timming.Fight)
            {
                if (IsAimming == true && Player1.Instance.P_AniState == P_StateMachine.AimReady)
                {
                    Player1.Instance.ChangeAniState(P_StateMachine.Hit);

                    StartCoroutine(HitAndRePos());
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Player1.Instance.TestChangeWeapon();
        }

        // 사운드 체크 테스트
        if (Input.GetKeyDown(KeyCode.P))
        {
            AudioManager.Instance.PlayBgm(AudioManager.RACCONCITY_N + 0);
        }

        // 이펙트 체크 테스트
        if (Input.GetMouseButtonDown(0))
        {
            EffectTest();
        }
    }

    IEnumerator HitAndRePos()
    {
        float delay = 0.0f;

        switch (Player1.Instance.P_weapon)
        {
            case P_WeaponStyle.knife:
                delay = 0.8f;
                break;
            case P_WeaponStyle.pistol:
                delay = 0.5f;
                break;
            case P_WeaponStyle.rifle:
                delay = 0.2f;
                break;
        }
        yield return new WaitForSeconds(delay);
        Player1.Instance.ChangeAniState(P_StateMachine.AimReady);
    }

    private void EffectTest()
    {
        P_ray.origin = this.transform.position;
        P_ray.direction = this.transform.forward;

        if (Physics.Raycast(P_ray, out P_hit))
        {
            if (P_hit.point != null)
            {
                EffectManager.Instance.PlayEffect(P_hit.point, P_hit.normal, false, EffectType.BloodSpot);
            }
        }
    }

    public Vector3 GetMoveMent()
    {
        Vector3 movement = this.transform.forward * xAxis;
        return movement * MoveSpeed * Time.deltaTime;
    }

    public float GetTurnDir()
    {
        return zAxis;
    }

    public void SetHead_P(Vector3 pos)
    {
        HeadRigPoint.transform.localPosition = pos;
    }
    public void SetBody_P(Vector3 pos)
    {
        BodyRigPoint.transform.localPosition = pos;
    }
}
public enum P_StateMachine
{
    None = -1, Idle, Walk, BackWalk, Turnning, Run, AimReady, Hit
}

public enum P_WeaponStyle
{
    None, knife, pistol, rifle  //, shotgun, greade
}

public enum P_Timming
{
    None = -1, Question, Item, Action, Fight
}