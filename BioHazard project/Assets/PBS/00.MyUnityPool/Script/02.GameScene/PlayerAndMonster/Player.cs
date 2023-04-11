using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float xAxis, yAxis;
    public float speed;
    Rigidbody P_RB;

    bool[] Dir;

    void Start()
    {
        InputManager.Instance.SetNow(NowKeyState.InGame);
        P_RB = this.gameObject.GetComponent<Rigidbody>();
        speed = 100.0f;

        xAxis = 0;
        yAxis = 0;

        Dir = new bool[4];
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
        if (Input.GetKey(KeyCode.UpArrow))
        {
            xAxis = 1;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            xAxis = -1;
        }
        else xAxis = 0;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            yAxis = -1;
            transform.Rotate(Vector3.up, yAxis);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            yAxis = 1;
            transform.Rotate(Vector3.up, yAxis);
        }
        else yAxis = 0;

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
        Vector3 Fdir = transform.forward;
        P_RB.velocity = new Vector3(Fdir.z * xAxis * speed * Time.deltaTime, P_RB.velocity.y, Fdir.x * xAxis * speed * Time.deltaTime);
    }


    private void InputUpDate()
    {
        if (InputManager.Instance.GetNow() == NowKeyState.InGame)
        {
            if (Input.anyKeyDown == true)
            {
                if (Input.GetKey(KeyCode.UpArrow) && Dir[1] != true)
                {
                    xAxis = 1;
                    Dir[0] = true;
                }

                if (Input.GetKey(KeyCode.DownArrow) && Dir[0] != true)
                {
                    xAxis = -1;
                    Dir[1] = true;
                }

                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    yAxis = 1;
                    transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + yAxis, 0);
                }

                if (Input.GetKey(KeyCode.RightArrow))
                {
                    yAxis = -1;
                    transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + yAxis, 0);
                }
            }
            else
            {
                if (Input.GetKeyUp(KeyCode.UpArrow))
                {
                    xAxis = 0;
                    Dir[0] = false;
                    if (Dir[1] == false) P_RB.velocity = new Vector3(0, P_RB.velocity.y, 0);
                }

                if (Input.GetKeyUp(KeyCode.DownArrow))
                {
                    xAxis = 0;
                    Dir[1] = false;
                    if (Dir[0] == false) P_RB.velocity = new Vector3(0, P_RB.velocity.y, 0);
                }
            }
        }
    }

    private void P_Move()
    {
        if (Dir[0] || Dir[1])
        {
            Vector3 Fdir = transform.forward.normalized;
            Debug.Log(xAxis);
            P_RB.AddForce(new Vector3(Fdir.z * xAxis * speed, P_RB.velocity.y, Fdir.x) * Time.deltaTime, ForceMode.VelocityChange);
        }
    }

}
