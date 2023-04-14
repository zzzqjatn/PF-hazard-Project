using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Singleton<PlayerController>
{
    private const float MOVE_SPEED_DEFAULT = 80.0f;
    private Player P_Player;
    private Ray P_ray;
    private RaycastHit P_hit;

    private float xAxis, zAxis;
    private float MoveSpeed;

    void Start()
    {
        P_Player = this.gameObject.GetComponent<Player>();

        MoveSpeed = MOVE_SPEED_DEFAULT;
        xAxis = 0;
        zAxis = 0;
    }

    void Update()
    {
        keyCon();
    }

    private void FixedUpdate()
    {

    }

    private void keyCon()
    {
        if (xAxis == 0 && zAxis == 0)
        {
            Player1.Instance.P_AniState = P_StateMachine.Idle;
        }

        if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.V))
        {
            xAxis = 1;
            Player1.Instance.P_AniState = P_StateMachine.Run;
            MoveSpeed = MOVE_SPEED_DEFAULT * 2.2f;
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            xAxis = 1;
            Player1.Instance.P_AniState = P_StateMachine.Walk;
            MoveSpeed = MOVE_SPEED_DEFAULT;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            xAxis = -1;
            Player1.Instance.P_AniState = P_StateMachine.BackWalk;
            MoveSpeed = MOVE_SPEED_DEFAULT * (0.8f);
        }
        else xAxis = 0;


        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.V))
        {
            zAxis = -1;
            transform.Rotate(Vector3.up, zAxis);
            Player1.Instance.P_AniState = P_StateMachine.Run;
            MoveSpeed = MOVE_SPEED_DEFAULT * 2.2f;
        }
        else if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.V))
        {
            zAxis = 1;
            transform.Rotate(Vector3.up, zAxis);
            Player1.Instance.P_AniState = P_StateMachine.Turnning;
            MoveSpeed = MOVE_SPEED_DEFAULT * 2.2f;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            zAxis = -1;
            transform.Rotate(Vector3.up, zAxis);
            Player1.Instance.P_AniState = P_StateMachine.Turnning;
            MoveSpeed = MOVE_SPEED_DEFAULT;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            zAxis = 1;
            transform.Rotate(Vector3.up, zAxis);
            Player1.Instance.P_AniState = P_StateMachine.Turnning;
            MoveSpeed = MOVE_SPEED_DEFAULT;
        }
        else zAxis = 0;

        if (Input.GetKeyDown(KeyCode.P))
        {
            AudioManager.Instance.PlayBgm(AudioManager.RACCONCITY_N + 0);
        }

        if (Input.GetMouseButtonDown(0))
        {
            EffectTest();
        }
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
}