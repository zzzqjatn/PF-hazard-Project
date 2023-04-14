using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    private const float SPEED_DEFAULT = 80.0f;
    public float xAxis, zAxis;
    private float speed;
    private Rigidbody P_RB;
    private Animator P_Ani;
    private PlayerStateType1 P_State;
    private Ray P_ray;
    private RaycastHit P_hit;

    void Start()
    {
        // InputManager.Instance.SetNow(NowKeyState.InGame);
        P_RB = this.gameObject.GetComponent<Rigidbody>();
        P_State = PlayerStateType1.None;
        P_Ani = this.gameObject.GetComponent<Animator>();
        P_Ani.SetBool("Idle", true);
        speed = SPEED_DEFAULT;

        xAxis = 0;
        zAxis = 0;
    }

    void Update()
    {
        // InputUpDate();
        keyCon();
    }

    private void FixedUpdate()
    {
        // P_Move();
        Move();
    }

    private void keyCon()
    {
        if (xAxis == 0 && zAxis == 0)
        {
            P_State = PlayerStateType1.Idle;
            P_Ani.SetBool("Idle", true);
            P_Ani.SetBool("BWalk", false);
            P_Ani.SetBool("Walk", false);
            P_Ani.SetBool("Run", false);

            P_RB.velocity = Vector3.zero;
        }

        if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.V))
        {
            xAxis = 1;
            P_State = PlayerStateType1.Run;
            P_Ani.SetBool("Idle", false);
            P_Ani.SetBool("BWalk", false);
            P_Ani.SetBool("Walk", false);
            P_Ani.SetBool("Run", true);

            speed = SPEED_DEFAULT * 2.2f;
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            xAxis = 1;
            P_State = PlayerStateType1.Walk;
            P_Ani.SetBool("Idle", false);
            P_Ani.SetBool("BWalk", false);
            P_Ani.SetBool("Walk", true);
            P_Ani.SetBool("Run", false);

            speed = SPEED_DEFAULT;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            xAxis = -1;
            P_State = PlayerStateType1.BackWalk;
            P_Ani.SetBool("Idle", false);
            P_Ani.SetBool("BWalk", true);
            P_Ani.SetBool("Walk", false);
            P_Ani.SetBool("Run", false);

            speed = SPEED_DEFAULT * (0.8f);
        }
        else xAxis = 0;


        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.V))
        {
            zAxis = -1;
            transform.Rotate(Vector3.up, zAxis);
            P_State = PlayerStateType1.Turnning;
            P_Ani.SetBool("Idle", false);
            P_Ani.SetBool("BWalk", false);
            P_Ani.SetBool("Walk", false);
            P_Ani.SetBool("Run", true);

            speed = SPEED_DEFAULT * 2.2f;
        }
        else if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.V))
        {
            zAxis = 1;
            transform.Rotate(Vector3.up, zAxis);
            P_State = PlayerStateType1.Turnning;
            P_Ani.SetBool("Idle", false);
            P_Ani.SetBool("BWalk", false);
            P_Ani.SetBool("Walk", false);
            P_Ani.SetBool("Run", true);

            speed = SPEED_DEFAULT * 2.2f;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            zAxis = -1;
            transform.Rotate(Vector3.up, zAxis);
            P_State = PlayerStateType1.Turnning;
            P_Ani.SetBool("Idle", false);
            P_Ani.SetBool("BWalk", false);
            P_Ani.SetBool("Walk", true);
            P_Ani.SetBool("Run", false);

            speed = SPEED_DEFAULT;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            zAxis = 1;
            transform.Rotate(Vector3.up, zAxis);
            P_State = PlayerStateType1.Turnning;
            P_Ani.SetBool("Idle", false);
            P_Ani.SetBool("BWalk", false);
            P_Ani.SetBool("Walk", true);
            P_Ani.SetBool("Run", false);

            speed = SPEED_DEFAULT;
        }
        else
        {
            P_RB.angularVelocity = Vector3.zero;
            zAxis = 0;
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            AudioManager.Instance.PlayBgm(AudioManager.RACCONCITY_N + 0);
        }

        if (Input.GetMouseButtonDown(0))
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

        // if (Input.GetKey(KeyCode.LeftArrow))
        // {
        //     yAxis = 1;
        //     transform.rotation = Quaternion.EulerAngles(
        //         new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + yAxis, transform.eulerAngles.z));
        // }
        // else yAxis = 0;

        // if (Input.GetKey(KeyCode.RightArrow))
        // {
        //     yAxis = -1;
        //     transform.rotation = Quaternion.EulerAngles(
        //         new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + yAxis, transform.eulerAngles.z));
        // }
        // else yAxis = 0;
    }

    private void Move()
    {
        // Vector3 movement = new Vector3(xAxis, 0.0f, zAxis);
        Vector3 movement = this.transform.forward * xAxis;
        // P_RB.AddForce(movement * speed * Time.deltaTime, ForceMode.Impulse);

        P_RB.velocity = movement * speed * Time.deltaTime;

        // Vector3 Fdir = transform.forward;
        // P_RB.velocity = new Vector3(Fdir.z * xAxis * speed * Time.deltaTime, P_RB.velocity.y, Fdir.x * xAxis * speed * Time.deltaTime);
    }

    public void AniStateSetting(PlayerStateType1 inputState)
    {
        switch (inputState)
        {
            case PlayerStateType1.None:
                break;
            case PlayerStateType1.Walk:
                break;
        }
    }

}
public enum PlayerStateType1
{
    None = -1, Idle, Walk, BackWalk, Turnning, Run, ShotReady, Fire, KnifeReady, Attack
}