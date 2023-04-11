using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    public bool B_UpArrow = false;
    public bool B_DownArrow = false;
    public bool B_LeftArrow = false;
    public bool B_RightArrow = false;
    public bool B_Z = false;
    public bool B_X = false;
    public bool B_C = false;
    public bool B_V = false;
    public bool B_LCtrl = false;
    public bool B_Enter = false;
    public bool B_ESC = false;

    public NowKeyState nowWhere = NowKeyState.None;

    public KeyNumber InputDown()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            B_UpArrow = true;
            return KeyNumber.UpArrow;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            B_DownArrow = true;
            return KeyNumber.DownArrow;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            B_LeftArrow = true;
            return KeyNumber.LeftArrow;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            B_RightArrow = true;
            return KeyNumber.RightArrow;
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            B_Z = true;
            return KeyNumber.Z;
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            B_X = true;
            return KeyNumber.X;
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            B_C = true;
            return KeyNumber.C;
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            B_V = true;
            return KeyNumber.V;
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            B_LCtrl = true;
            return KeyNumber.LCtrl;
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            B_Enter = true;
            return KeyNumber.Enter;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            B_ESC = true;
            return KeyNumber.ESC;
        }

        return KeyNumber.None;
    }

    public void InputUp(KeyNumber keyNum)
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            B_UpArrow = false;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            B_DownArrow = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            B_LeftArrow = false;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            B_RightArrow = false;
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            B_Z = false;
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            B_X = false;
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            B_C = false;
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            B_V = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            B_LCtrl = false;
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            B_Enter = false;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            B_ESC = false;
        }
    }

    public NowKeyState GetNow()
    {
        return nowWhere;
    }
    public void SetNow(NowKeyState set)
    {
        nowWhere = set;
    }
}

public enum NowKeyState
{
    None = -1, InGame, Inven
}

public enum KeyNumber
{
    None, UpArrow, DownArrow, LeftArrow, RightArrow, Z, X, C, V, LCtrl, Enter, ESC
}